using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfl_parser
{
     public class SFL_Record
     {
          // This is a class that holds one record
          private String Header_String { get; set; }
          private String Data_String { get; set; }
          private String Mod_Date { get; set; }

          private String Ports_Avail { get; set; }
          private String Ports_Active { get; set; }

          private String Minutes { get; set; }
          private String Hour { get; set; }
          private String Day { get; set; }
          private String Month { get; set; }
          private String Year { get; set; }

          private String Date_Time_Str { get; set; }

          private String Site { get; set; }
          private String Site_Name_Str { get; set; }

          private String Logger_Number { get; set; }
          private String Altitude { get; set; }
          private String Longitude { get; set; }
          private String Latitude { get; set; }
          private List<SFL_Record_Data> Record_Data { get; set; }

          public SFL_Record(String input_record, int rec_length, int port_count)
          {
               DateTime now = DateTime.Now;
               Mod_Date = "Modified: " + now.ToString("MM-dd-yyyy--HH:mm");
               Console.WriteLine(Mod_Date);
               Header_String = input_record.Substring(0, Globals.header_length);
               Data_String = input_record.Substring((Globals.header_length), (rec_length - (Globals.header_length)));
               //Try to fill in all the header data
               Parse_Header();
               //Now fill in the port data for each port
               Record_Data = Parse_Data(port_count);
          }

          private void Parse_Header()
          {
               try
               {
                    Minutes = Header_String.Substring(0, 2);
                    Hour = Header_String.Substring(2, 2);
                    Day = Header_String.Substring(4, 2);
                    Month = Header_String.Substring(6, 2);
                    //Do some logic hear for pre y2k stuffs.
                    Year = Header_String.Substring(8, 2);
                    Site = Header_String.Substring(10, 2);
                    String tmp_name;
                    Globals.Site_Maping.TryGetValue(Site, out tmp_name);
                    Site_Name_Str = tmp_name;
                    Logger_Number = Header_String.Substring(12, 4);
                    Altitude = Header_String.Substring(16, 8);
                    Longitude = Header_String.Substring(24, 8);
                    Latitude = Header_String.Substring(32, 8);

               }
               catch (Exception e)
               {
                    Console.WriteLine("Error parsign and saveing record data.");
                    Console.WriteLine("Error {0}", e);
               }
          }

          private List<SFL_Record_Data> Parse_Data(int port_count)
          {
               IEnumerable<String> cur_data = Globals.Split(Data_String, Globals.data_length);

               List<String> port_data_ea = new List<string>(cur_data);

               List<SFL_Record_Data> out_data_list = new List<SFL_Record_Data>();


               foreach(String dat in port_data_ea)
               {
                    bool port_has_dat = false;
                    int active_port_counter = 0;

                    SFL_Record_Data cur_rec_data = new SFL_Record_Data();

                    cur_rec_data.Data_Code = dat.Substring(0, 4);

                    cur_rec_data.Inst_Num = dat.Substring(4, 10);

                    cur_rec_data.Sensitivity = dat.Substring(14, 8);

                    cur_rec_data.POD = dat.Substring(22, 4);

                    cur_rec_data.Countes_MV = dat.Substring(26, 8);

                    cur_rec_data.Zero_Offset = dat.Substring(34, 8);

                    out_data_list.Add(cur_rec_data);

                    active_port_counter ++;

                }

               return out_data_list;
          }
     }
}
