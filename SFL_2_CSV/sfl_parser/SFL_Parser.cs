using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfl_parser
{
     public class SFL_Parser
     {
          //complete copy of the sfl file without the filename and path attached
          private string sfl_to_parse { set; get; }
          //The actual SFL file name
          private string sfl_file_name { get; set; }
          //The time stired to seperate strings
          private string min;

          public void Get_File_Name(string sfl_file)
          {
               int start, end, delta;
               //Grab the indicies of the last slash and first comma of the string
               //what lies between is the file name.
               start = sfl_file.LastIndexOf("\\");
               end = sfl_file.LastIndexOf(",");
               delta = sfl_file.Length - end;
               // Set the name of this sensor reading
               sfl_file_name = sfl_file.Substring(start, end + 1);
               //Set the inital string with all readings from the sensor
               // the substring starts a the character after the comma I added
               // The delta is 
               sfl_to_parse = sfl_file.Substring(end + 1, sfl_file.Length - delta);
          }

     }
}
