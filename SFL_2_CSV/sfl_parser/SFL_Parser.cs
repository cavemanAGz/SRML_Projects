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
          ////The following constants are based on the orignal program file SFMOD. 
          ////The header is the firs 50 chars, with informational values
          ////(Change this if the header length changes. Count is charachters)
          //private static readonly int header_length = 50;
          ////The data si the information from the instruments ports, the length is static, the number of ports
          ////is not and will be dertermined at run time. (Change this if the data length changes. Count is charachters)
          //private static readonly int data_length = 42;

          ////This array holds all possible record sizes folowing this formula:
          //// Report_Length = (Header_Lenght + (Data_Lenght * Port_Count))
          //private static readonly int[] Record_Lengths = {
          //     (header_length + (data_length * 4)),
          //     (header_length + (data_length * 8)),
          //     (header_length + (data_length * 16)),
          //     (header_length + (data_length * 24)),
          //     (header_length + (data_length * 32)),
          //     (header_length + (data_length * 48)),
          //     (header_length + (data_length * 64)) };

          ////This is just to do the translation of Record lentght ot port count
          //private int[] Port_Values = { 4, 8, 16, 24, 32, 48, 64};
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
          private List<String> Record_Strings { get; set; }
          private SFL_Record[] Cur_File_Records { get; set; }

          /****************************************************************************************
          * Function:Parse_SFL 
          * Purpose: This method will parse the entire SFL File and is the main methog of this
          *          class          
          * Input: A string that contains a valid SFL file meeting the standard format as of 
          *        3/3/2018        
          * Output: A CSV of the SFL file parsed in teh output directory selected or an error. 
          ****************************************************************************************/
          public void Parse_SFL(string sfl_file_string)
          {
               //Call method to set file information. 
               Get_File_Info(sfl_file_string);

               Determine_Record_Prams();

               //Now we know how many ports the device has, how ong each recode is and the record count
               //SFL_Record tst_rec = new SFL_Record(SFL_to_parse, Record_Length, Port_Count);               
               Record_Strings = Make_List_Of_Records();

               int i = 1;
               foreach (String Rec in Record_Strings)
               {
                    Console.WriteLine("Record " + i + ": " + Rec);
                    i ++;
               }

               i = 1;


               //return SFL_file_path + SFL_file_name;
          }

          /****************************************************************************************
           * Function: Get_File_Info
           * Purpose: This function will set the File related variables for the class. These are the 
           *          SFL file name by itself, the file path, and a strign without these to be parsed
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
               Console.WriteLine("The file name is: " + SFL_file_name);
               //Set the inital string with all readings from the sensor
               // the substring starts a the character after the comma I added
               // The delta is 
               delta = sfl_file_string_in.Length - (end + 1);
               SFL_to_parse = sfl_file_string_in.Substring(end + 1, delta);

               delta = 0;

               //Console.WriteLine("The File string is: " + SFL_to_parse);
               Console.WriteLine("The file length is: " + SFL_to_parse.Length.ToString());

               SFL_file_path = sfl_file_string_in.Substring(0, sfl_file_string_in.LastIndexOf("\\")+1);
               Console.WriteLine("The file path is: " + SFL_file_path);
          }

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
                         Port_Count = Globals.Port_Values[i];
                         Record_Length = Globals.Record_Lengths[i];
                         Console.WriteLine("The port Count is: " + Port_Count.ToString());
                         Console.WriteLine("The Record length is: " + Record_Length.ToString());
                         break;
                    }
                    else if(Mod_Result == 2)
                    {
                         Port_Count = Globals.Port_Values[i];
                         Record_Length = Globals.Record_Lengths[i];
                         Console.WriteLine("The port Count is: " + Port_Count.ToString());
                         Console.WriteLine("The Record length is: " + Record_Length.ToString());
                         Console.WriteLine("Error! Slight Correction made, data might be bad!");
                         break;
                    }

                    if(i == Globals.Record_Lengths.Length - 1)
                    {
                         Port_Count = 16;
                         Console.WriteLine("The port Count is: " + Port_Count.ToString());
                         Console.WriteLine("Error! Couldnt determin port count, revert to pre 3/3/2018 default of 16 ports");
                         break;
                    }
               }
          }

          // This function needs to knwo the record Length so it must run after the valus is initialized
          private List<String> Make_List_Of_Records()
          {
               //String reg_ex_frag = @"\d{" + Record_Length.ToString() + "}";
               //List<String> rec_list = (from Match m in Regex.Matches(SFL_to_parse, @reg_ex_frag) select m.Value).ToList();

               IEnumerable<String> test = Split(SFL_to_parse, Record_Length);

               List<String> rec_list = new List<string>(test);

               return rec_list;
          }

          // This method was pulled from teh accepted solution on stack exchange at the following URL
          //https://stackoverflow.com/questions/1450774/splitting-a-string-into-chunks-of-a-certain-size
          static IEnumerable<string> Split(string str, int chunkSize)
          {
               return Enumerable.Range(0, str.Length / chunkSize)
                   .Select(i => str.Substring(i * chunkSize, chunkSize));
          }

     }
}
