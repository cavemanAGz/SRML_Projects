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
          public String Header_String { get; private set; }                       //Initialized in Constructor Body
          public String Data_String { get; private set; }                         //Initialized in Constructor Body
          public String Mod_Date { get; private set; }                            //Initialized in Constructor Body

          //These get passed in as arguments to a SFL_Record constructor
          public String SFL_File_Name { get; private set; }                       //Initialized in Constructor Body
          public String SFL_File_Path { get; private set; }                       //Initialized in Constructor Body
          public int Cur_Record_Count { get; private set; }                       //Initialized in Constructor Body
          public int Total_Records_Count { get; private set; }                    //Initialized in Constructor Body
          public int Ports_Avail { get; private set; }                            //Initialized in Constructor Body

          public String Minute { get; private set; }                              //Initialized in Parse_HEader()
          public String Hour { get; private set; }                                //Initialized in Parse_HEader()
          public String Day { get; private set; }                                 //Initialized in Parse_HEader()
          public String Month { get; private set; }                               //Initialized in Parse_HEader()
          public String Year { get; private set; }                                //Initialized in Parse_HEader()

          public String Date_Str { get; private set; }                            //Initialized in Parse_Header()
          public String Time_Str { get; private set; }                            //Initialized in Parse_Header()
          public String Date_Time_Str { get; private set; }                       //Initialized in Parse_Header()
          public String CSV_Date_Time_Str { get; private set; }                   //Initialized in Parse_Header()

          public String Site { get; private set; }                                //Initialized in Parse_Header()
          public String Site_Name_Str { get; private set; }                       //Initialized in Parse_Header()

          public String Logger_Number { get; private set; }                       //Initialized in Parse_Header()
          public String Altitude { get; private set; }                            //Initialized in Parse_Header()
          public String Longitude { get; private set; }                           //Initialized in Parse_Header()
          public String Latitude { get; private set; }                            //Initialized in Parse_Header()

          public List<SFL_Record_Data> Record_Data { get; private set; }          //Initialized in Parse_Data()
          public int Active_Port_Count { get; private set; }                      //Initialized in Parse_Data()

          /****************************************************************************************
          * Function: 
          * Purpose: 
          * Input: 
          * Output: 
          * Var State Changes: 
          * Dependancies: 
          ****************************************************************************************/
          //The only wa to buld a record is to pass it All the data it needs at once. 
          public SFL_Record(String input_record, String file_name_in , String file_path_in,  int rec_length, int port_count, int cur_rec_Count, int all_rec_count)
          {
               try
               {
                    DateTime now = DateTime.Now;
                    Header_String = input_record.Substring(Globals.Header_Start_Index, Globals.Header_Length);
                    //Data_String will contain the data for ALL ports on teh device and will be parsed seperatly
                    Data_String = input_record.Substring((Globals.Data_Start_Index), (rec_length - (Globals.Header_Length)));
                    Mod_Date = now.ToString("dd-MM-yyyy     HH:mm");
                    SFL_File_Name = file_name_in;
                    SFL_File_Path = file_path_in;
                    Total_Records_Count = all_rec_count;
                    Cur_Record_Count = cur_rec_Count;
                    Ports_Avail = port_count;

                    //Try to fill in all the header data
                    Parse_Header();
                    //Now fill in the port data for each port
                    Record_Data = Parse_Data();

                    Print_Curet_Record(this);

               }
               catch (Exception e)
               {
                    Console.WriteLine("Error parsing and saving record data. SFL_Record Constructor");
                    Console.WriteLine("Error {0}", e);
               }
          }

          /****************************************************************************************
          * Function: 
          * Purpose: 
          * Input: 
          * Output: 
          * Var State Changes: 
          * Dependancies: 
          ****************************************************************************************/
          private void Parse_Header()
          {
               try
               {
                    Minute = Header_String.Substring(Globals.Minute_Start_Index, Globals.Min_Length);
                    Hour = Header_String.Substring(Globals.Hour_Start_Index, Globals.Hour_Length);
                    Day = Header_String.Substring(Globals.Day_Start_Index, Globals.Day_Length);
                    Month = Header_String.Substring(Globals.Month_Start_Index, Globals.Month_Length);
                    //Do some logic hear for pre y2k stuffs.
                    Year = Header_String.Substring(Globals.Year_Start_Index, Globals.Year_Length);
                    //DD/MM/YY
                    Date_Str = Day + @"/" + Month + @"/" + Year;
                    //HH:MM
                    Time_Str = Hour + ":" + Minute;
                    Date_Time_Str = Date_Str + @"       " + Time_Str;
                    // YYYY - MM - DD --HH:MM
                    CSV_Date_Time_Str = Year+@"/"+Month+ @"/" +Day + @" --" + Hour + @":" + Minute;
                    Site = Header_String.Substring(Globals.Site_Start_Index, Globals.Site_Length);
                    String tmp_name;
                    Globals.Site_Maping.TryGetValue(Site, out tmp_name);
                    Site_Name_Str = tmp_name;
                    Logger_Number = Header_String.Substring(Globals.Logger_Num_Start_Index, Globals.Logger_Num_Length);
                    Altitude = Header_String.Substring(Globals.Altitude_Start_Index, Globals.Altitude_Length);
                    Longitude = Header_String.Substring(Globals.Longitude_Start_Index, Globals.Longitude_Length);
                    Latitude = Header_String.Substring(Globals.Latitude_Start_Index, Globals.Longitude_Length);

               }
               catch (Exception e)
               {
                    Console.WriteLine("Error parsing and saving record data.");
                    Console.WriteLine("Error {0}", e);
               }
          }

          /****************************************************************************************
          * Function: Parse_Data
          * Purpose: This function uses the 
          * Input: None
          * Output: 
          * Var State Changes: 
          * Dependancies: 
          ****************************************************************************************/
          private List<SFL_Record_Data> Parse_Data()
          {
               //Break the data files up into their respective data sets
               IEnumerable<String> cur_data = Globals.Split(Data_String, Globals.Data_Length);
               //Put them in a string
               List<String> port_data_ea = new List<string>(cur_data);

               //Create a list to store the Data Records
               List<SFL_Record_Data> out_data_list = new List<SFL_Record_Data>();

               int active_port_counter = 0;

               foreach (String dat in port_data_ea)
               {

                    try
                    {
                         SFL_Record_Data cur_rec_data = new SFL_Record_Data();

                         cur_rec_data.Data_Code = dat.Substring(Globals.Data_Code_Start_Index, Globals.Data_Code_Length);
                         cur_rec_data.Inst_Num = dat.Substring(Globals.Inst_Start_Index, Globals.Inst_Length);
                         cur_rec_data.Sensitivity = dat.Substring(Globals.Sensitivity_Start_Index, Globals.Sensitivity_Length);
                         cur_rec_data.POD = dat.Substring(Globals.POD_Start_Index, Globals.POD_Length);
                         cur_rec_data.Countes_MV = dat.Substring(Globals.Counts_MV_Start_Index, Globals.Counts_MV_Length);
                         cur_rec_data.Zero_Offset = dat.Substring(Globals.Zero_Offset_Start_Index, Globals.Zero_Offset_Length);
                         if (cur_rec_data.Data_Code == "0000" &&
                               cur_rec_data.Zero_Offset == Globals.Zero_Offset_Empty_Str)
                         {
                              //Got the Empty List
                              break;
                         }
                         else
                         {
                              active_port_counter++;
                              out_data_list.Add(cur_rec_data);
                         }
                    }
                    catch (Exception e)
                    {
                         Console.WriteLine("Doh! The error is in the Data parse foreach");
                         Console.WriteLine("Error {0}", e);
                    }
                }

               Active_Port_Count = active_port_counter;

               return out_data_list;
          }

          public void Print_Curet_Record(SFL_Record cur_rec)
          {
               //Lets just print all the Records properties to the console 
               String boarder = new System.String('=', 80);
               Console.WriteLine(boarder);
               //Line 1
               Console.WriteLine("{0}{1}",
                    cur_rec.SFL_File_Path,
                    cur_rec.SFL_File_Name);
               Console.WriteLine("Record {0} of {1}\t\tModified: {2}",
                    cur_rec.Cur_Record_Count,
                    cur_rec.Total_Records_Count,
                    cur_rec.Mod_Date);
               Console.WriteLine(boarder);
               //Line 2
               Console.WriteLine("Site Code: {0}\t\tSite Name: {1}\tDate: {2} at {3}",
                    cur_rec.Site,
                    cur_rec.Site_Name_Str,
                    cur_rec.Date_Str,
                    cur_rec.Time_Str
                    );
               //Line 3
               Console.WriteLine("Logger " + @"# " + "{0}\t\tActive Ports: {1} of {2}",
                    cur_rec.Logger_Number,
                    cur_rec.Active_Port_Count,
                    cur_rec.Ports_Avail);
               //line 4
               Console.WriteLine("Latitude: {0}\t\tLongitude: {1}\t\tAltitude: {2}",
                    cur_rec.Latitude,
                    cur_rec.Longitude,
                    cur_rec.Altitude
                    );
               Console.WriteLine("Port\tCode\tInstrument\tSensitivity\tPod#\tZero Offse\tCounts/mv");

               int counter = 1;
               bool flipper = true;

               foreach (SFL_Record_Data cur in cur_rec.Record_Data)
               {
                    
                    if(flipper)
                    {
                         ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.Yellow);
                         Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                              counter,
                              cur.Data_Code,
                              cur.Inst_Num,
                              cur.Sensitivity,
                              cur.POD, cur.Zero_Offset,
                              cur.Countes_MV);
                         ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.White);
                         flipper = !flipper;
                         counter++;
                    }
                    else
                    {
                         ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.Green);
                         Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                              counter,
                              cur.Data_Code,
                              cur.Inst_Num,
                              cur.Sensitivity,
                              cur.POD, cur.Zero_Offset,
                              cur.Countes_MV);
                         ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.White);
                         flipper = !flipper;
                         counter++;
                    }
                    
               }
          }       

     }
}
