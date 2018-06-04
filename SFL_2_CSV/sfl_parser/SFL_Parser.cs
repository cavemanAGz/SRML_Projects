using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sfl_parser
{
     public class SFL_Parser
     {
          ///************************Start File props**********************************************************/

          //complete copy of the sfl file without the filename and path attached
          private string SFL_to_parse { set; get; }
          //The path of the file being parsed
          private string SFL_file_path { get; set; }
          //The actual SFL file name
          private string SFL_file_name { get; set; }

          /************************End file props**********************************************************/

          /************************Start Record props******************************************************/
          private int File_Length { get; set; }

          private int Record_Count { get; set; }

          private int Record_Length { get; set; }

          private int Port_Count { get; set; }

          /****************************End Record props*****************************************************/
          //The Record_String is 
          private List<String> Record_Strings { get; set; }
          private List<SFL_Record> Records { get; set; }

          /****************************************************************************************
          * Function:Parse_SFL 
          * Purpose: This method will parse the entire SFL File and is the main methog of this
          *          class
          *          Method Order:
          *          1. Get_File_Info
          *          2. Determine_Record_Prams();
          *          3. 
          * Input: A string that contains a valid SFL file meeting the standard format as of 
          *        3/3/2018        
          * Output: A CSV of the SFL file parsed in teh output directory selected or an error. 
          ****************************************************************************************/
          public void Parse_SFL(string sfl_file_string)
          {
               //Initialize the Record... DUH!
               Records = new List<SFL_Record>();
               //Call method to set file information. 
               Get_File_Info(sfl_file_string);

               Determine_Record_Prams();

               //Now we know how many ports the device has, how ong each recode is and the record count
               //SFL_Record tst_rec = new SFL_Record(SFL_to_parse, Record_Length, Port_Count);               
               Record_Strings = Make_List_Of_Records();

               int rec_counter = 1;
               foreach(String rec in Record_Strings)
               {
                    SFL_Record tmp_record = new SFL_Record(rec, SFL_file_name, SFL_file_path, Record_Length, Port_Count, rec_counter, Record_Strings.Count());
                    Records.Add(tmp_record);
                    rec_counter++;
               }

               //We should now have acomplete record with whcih to create a csv
               Console.WriteLine("SFL File {0} Parsed", Records[0].SFL_File_Name);
               //This is where we should creat the CSV FILE

          }

          /****************************************************************************************
           * Function: Get_File_Info
           * Purpose: This function will set the File related variables for the class. These are the 
           *          SFL file name by itself, the file path, and a strign without these to be parsed
           *          
           *          *** THIS METHOD MUST BE CALLED FIRST IN PARSER ****
           *          
           * Input: A string containing the entire SFLE file
           * Output: No Output
           * Var State Changes: SFL_to_parse, SFL_file_path, and SFL_file_name will be set to
           *                    proper values
           ****************************************************************************************/
          private void Get_File_Info(string sfl_file_string_in)
          {
               int start, end, delta;
               //Grab the indicies of the last slash and first comma of the string
               //what lies between is the file name.
               start = sfl_file_string_in.LastIndexOf("\\");
               end = sfl_file_string_in.LastIndexOf(",");
               delta = end - start;
               // Set the name of this sensor reading
               SFL_file_name = sfl_file_string_in.Substring(start + 1, delta - 1);
               //Console.WriteLine("The file name is: " + SFL_file_name);
               //Set the inital string with all readings from the sensor
               // the substring starts a the character after the comma I added
               // The delta is 
               delta = sfl_file_string_in.Length - (end + 1);
               SFL_to_parse = sfl_file_string_in.Substring(end + 1, delta);

               delta = 0;

               //Console.WriteLine("The File string is: " + SFL_to_parse);
               //Console.WriteLine("The file length is: " + SFL_to_parse.Length.ToString());

               SFL_file_path = sfl_file_string_in.Substring(0, sfl_file_string_in.LastIndexOf("\\")+1);
               //Console.WriteLine("The file path is: " + SFL_file_path);
          }

          /****************************************************************************************
          * Function: Determine_Record_Prams()
          * Purpose: This function will set the classes Port count and record length.
          *          
          *          *** THIS METHOD MUST BE CALLED SECOND IN PARSER ****
          *          
          * Input: None
          * Output: None
          * Var State Changes: Record_Length and Port_Count will be set in the class. 
          * Dependancies: Globals class for constants AND ConsoleColors class for coloring cmd 
          *               line output.
          ****************************************************************************************/
          private void Determine_Record_Prams()
          {
               //This is a hacky appraoch for inconsistant record 
               //File_Length (+/- 2) =record_length * record_count
               File_Length = SFL_to_parse.Length;

               int Mod_Result = 5000;
               
               for (int i = 0; i < Globals.Record_Lengths.Length; i++)
               {
                    Mod_Result = File_Length % Globals.Record_Lengths[i];
                    if (Mod_Result == 0)
                    {
                         //ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.Cyan);
                         Port_Count = Globals.Port_Values[i];
                         Record_Length = Globals.Record_Lengths[i];
                         //ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.Cyan);
                         //Console.WriteLine("The port Count is: " + Port_Count.ToString());
                         //ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.Blue);
                         //Console.WriteLine("The Record length is: " + Record_Length.ToString());
                         //ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.White);
                         break;
                    }
                    else if(Mod_Result == 2)
                    {
                         Port_Count = Globals.Port_Values[i];
                         Record_Length = Globals.Record_Lengths[i];
                         //ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.Cyan);
                         //Console.WriteLine("The port Count is: " + Port_Count.ToString());
                         //ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.Blue);
                         //Console.WriteLine("The Record length is: " + Record_Length.ToString());
                         ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.Red);
                         Console.WriteLine("Error! Slight Correction made, data might be bad!");
                         ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.White);
                         break;
                    }

                    //This handles the case of no matching file length and conforms to the standard method 
                    // of record lengths using globals. 
                    if(i == Globals.Record_Lengths.Length - 1)
                    {
                         Port_Count = 16;
                         Record_Length = (Globals.Header_Length + (Globals.Data_Length * Port_Count));
                         ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.Red);
                         Console.WriteLine("The port Count is: " + Port_Count.ToString());
                         Console.WriteLine("The Record length is: " + Record_Length.ToString());
                         Console.WriteLine("Error! Couldnt determin port count, revert to pre 3/3/2018 default of 16 ports");
                         ConsoleColour.SetForeGroundColour(ConsoleColour.ForeGroundColour.White);
                         break;
                    }
               }
          }

          /****************************************************************************************
          * Function: Make_List_Of_Records()
          * Purpose: This function will use the SFL_to_Parse string to create a list of each 
          *          individual record in the current SFL file to be parsed and stored in Record. 
          *          
          *          *** THIS METHOD MUST BE CALLED THIRD IN PARSER ****
          *          
          * Input: None
          * Output: A list of strings that are Record_Length long
          * Var State Changes: None 
          * Dependancies: Globals class for splitting the string into its parts. 
          ****************************************************************************************/
          private List<String> Make_List_Of_Records()
          {
               try
               {
                    IEnumerable<String> test = Globals.Split(SFL_to_parse, Record_Length);

                    List<String> rec_list = new List<string>(test);

                    return rec_list;
               }
               catch (Exception e)
               {
                    Console.WriteLine("Error msaking a list of records. SFL_Paeser");
                    Console.WriteLine("Error {0}", e);
                    return null;
               }
          }
     }
}
