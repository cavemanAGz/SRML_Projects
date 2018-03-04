using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfl_parser
{
     public class SFL_Parser
     {

          //The following constants are based on the orignal program file SFMOD. 
          //The header is the firs 50 chars, with informational values
          //(Change this if the header length changes. Count is charachters)
          private static readonly int header_length = 50;
          //The data si the information from the instruments ports, the length is static, the number of ports
          //is not and will be dertermined at run time. (Change this if the data length changes. Count is charachters)
          private static readonly int data_length = 42;

          //This array holds all possible record sizes folowing this formula:
          // Report_Length = (Header_Lenght + (Data_Lenght * Port_Count))
          private static readonly int[] Record_Lengths = {
               (header_length + (data_length * 4)),
               (header_length + (data_length * 8)),
               (header_length + (data_length * 16)),
               (header_length + (data_length * 24)),
               (header_length + (data_length * 32)),
               (header_length + (data_length * 48)),
               (header_length + (data_length * 64)) };

          //This is just to do the translation of Record lentght ot port count
          private int[] Port_Values = { 4, 8, 16, 24, 32, 48, 64};
          /************************Start File props**********************************************************/

          //complete copy of the sfl file without the filename and path attached, 
          //should be empty at the end of the parse, DO A TEST FOR THIS
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


          /****************************************************************************************
          * Function:Parse_SFL 
          * Purpose: This method will parse the entire SFL File and is the main methog of this
          *          class          
          * Input: A string that contains a valid SFL file meeting the standard format as of 
          *        3/3/2018        
          * Output: A CSV of the SFL file parsed in teh output directory selected or an error. 
          ****************************************************************************************/
          public string Parse_SFL(string sfl_file_string)
          {
               //Call method to set file information. 
               Get_File_Info(sfl_file_string);

               Determine_Record_Prams();

               return SFL_file_path + SFL_file_name;
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
               //File_Length (+/- 2) =record_length * record_count
               File_Length = SFL_to_parse.Length;

               int Mod_Result = 5000;

               for (int i = 0; i < Record_Lengths.Length; i++)
               {
                    Mod_Result = File_Length % Record_Lengths[i];
                    if (Mod_Result == 0)
                    {
                         Port_Count = Port_Values[i];
                         Record_Length = Record_Lengths[i];
                         Console.WriteLine("The port Count is: " + Port_Count.ToString());
                         Console.WriteLine("The Record length is: " + Record_Length.ToString());
                         break;
                    }
                    else if(Mod_Result == 2)
                    {
                         Port_Count = Port_Values[i];
                         Record_Length = Record_Lengths[i];
                         Console.WriteLine("The port Count is: " + Port_Count.ToString());
                         Console.WriteLine("The Record length is: " + Record_Length.ToString());
                         Console.WriteLine("Error! Slight Correction made, data might be bad!");
                         break;
                    }

                    if(i == Record_Lengths.Length - 1)
                    {
                         Port_Count = 16;
                         Console.WriteLine("The port Count is: " + Port_Count.ToString());
                         Console.WriteLine("Error! Couldnt determin port count, revert to pre 3/3/2018 default of 16 ports");
                         break;
                    }
               }
          }

     }
}
