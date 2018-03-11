using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfl_parser
{
     public static class Globals
     {

          //The following constants are based on the orignal program file SFMOD. 
          //The header is the firs 50 chars, with informational values
          //(Change this if the header length changes. Count is charachters)
          public static readonly int header_length = 50;
          //The data si the information from the instruments ports, the length is static, the number of ports
          //is not and will be dertermined at run time. (Change this if the data length changes. Count is charachters)
          public static readonly int data_length = 42;

          //This array holds all possible record sizes folowing this formula:
          // Report_Length = (Header_Lenght + (Data_Lenght * Port_Count))
          public static readonly int[] Record_Lengths = {
               (header_length + (data_length * 4)),
               (header_length + (data_length * 8)),
               (header_length + (data_length * 16)),
               (header_length + (data_length * 24)),
               (header_length + (data_length * 32)),
               (header_length + (data_length * 48)),
               (header_length + (data_length * 64)) };

          //This is just to do the translation of Record lentght ot port count
          public static readonly int[] Port_Values = { 4, 8, 16, 24, 32, 48, 64 };

          //Add any new site code and site name pairs here as needed
          public static readonly Dictionary<String, String> Site_Maping = new Dictionary<string, string>
          {
               { "AB", "Aberdeen     " },
               { "AL", "Alturas      " },
               { "AS", "Ashland      " },
               { "AP", "Aprovecho    " },
               { "BE", "Bend         " },
               { "BO", "Boise        " },
               { "BH", "AEC PV Test Facility" },
               { "BD", "Bend-SSE     " },
               { "BU", "Burns        " },
               { "CA", "Cannon Beach " },
               { "CB", "Coos Bay     " },
               { "CD", "Coeur Dalene " },
               { "CH", "Christmas Valley" },
               { "CL", "Challis      " },
               { "CV", "Corvallis    " },
               { "CY", "Cheney       " },
               { "DI", "Dillon       " },
               { "EU", "Eugene       " },
               { "FG", "Forest Grove " },
               { "GL", "Gladstone    " },
               { "GP", "Grants Pass  " },
               { "GR", "Green River  " },
               { "HA", "Hanford      " },
               { "HE", "Hermiston    " },
               { "HR", "Hood River   " },
               { "KF", "Klamath Falls" },
               { "KL", "Kl Falls-OIT " },
               { "LG", "La Grande    " },
               { "MA", "Madras       " },
               { "MO", "Moab         " },
               { "PA", "Parma        " },
               { "PD", "Parkdale     " },
               { "PI", "Picabo       " },
               { "PS", "Portland PSU " },
               { "PT", "Portland     " },
               { "SA", "Salem        " },
               { "SI", "Silver Lake  " },
               { "ST", "Seattle UW   " },
               { "SV", "Sheldon Vil. " },
               { "TF", "Twin Falls   " },
               { "VA", "Vancouver    " },
               { "WB", "White Bluffs " },
               { "WH", "Whitehorse   " },
               { "WI", "Willamette   " },
               { "WR", "W. Hood River" }
          };

          // This method was pulled from teh accepted solution on stack exchange at the following URL
          //https://stackoverflow.com/questions/1450774/splitting-a-string-into-chunks-of-a-certain-size
          public static IEnumerable<string> Split(string str, int chunkSize)
          {
               return Enumerable.Range(0, str.Length / chunkSize)
                   .Select(i => str.Substring(i * chunkSize, chunkSize));
          }
     }
}
