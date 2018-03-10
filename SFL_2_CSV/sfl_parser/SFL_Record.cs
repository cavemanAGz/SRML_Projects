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
          private String Header { get; set; }
          private String Data { get; set; }
          private String Mod_Date { get; set; }

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
          private SFL_Record_Data[] Record_Data { get; set; }

          public SFL_Record(String input_record, int rec_length, int port_count)
          {
               DateTime now = DateTime.Now;
               Mod_Date = "Modified: " + now.ToString("MM-dd-yyyy--HH:mm");
               Console.WriteLine(Mod_Date);
               Header = input_record.Substring(0, Globals.header_length);
               Data = input_record.Substring((Globals.header_length + 1), (rec_length - (Globals.header_length + 1)));
               Parse_Header();
               Parse_Data(port_count);
          }

          private void Parse_Header()
          {

          }

          private void Parse_Data(int port_count)
          {

          }
     }
}
