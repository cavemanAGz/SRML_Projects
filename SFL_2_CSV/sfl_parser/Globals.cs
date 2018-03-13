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
          public static readonly int Header_Length = 50;
          public static readonly int Header_Start_Index = 0;
          //The data is the information from the instruments ports, the length is static, the number of ports
          //is not and will be dertermined at run time. (Change this if the data length changes. Count is charachters)
          public static readonly int Data_Length = 42;
          public static readonly int Data_Start_Index = 50;

          //This array holds all possible record sizes folowing this formula:
          // Report_Length = (Header_Lenght + (Data_Lenght * Port_Count))
          public static readonly int[] Record_Lengths = {
               (Header_Length + (Data_Length * 4)),
               (Header_Length + (Data_Length * 8)),
               (Header_Length + (Data_Length * 16)),
               (Header_Length + (Data_Length * 24)),
               (Header_Length + (Data_Length * 32)),
               (Header_Length + (Data_Length * 48)),
               (Header_Length + (Data_Length * 64)) };

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

          //Constants for SFL Files
          /***  Constants for the Header Section of a record ****/
          public static readonly int Min_Length = 2;
          public static readonly int Minute_Start_Index = 0;
          public static readonly String Min_Empty_Str = new System.String(' ', Min_Length);

          public static readonly int Hour_Length = 2;
          public static readonly int Hour_Start_Index = 2;
          public static readonly String Hour_Empty_Str = new System.String(' ', Hour_Length);

          public static readonly int Day_Length = 2;
          public static readonly int Day_Start_Index = 4;
          public static readonly String Day_Empty_Str = new System.String(' ', Day_Length);

          public static readonly int Month_Length = 2;
          public static readonly int Month_Start_Index = 6;
          public static readonly String Month_Empty_Str = new System.String(' ', Month_Length);

          public static readonly int Year_Length = 2;
          public static readonly int Year_Start_Index = 8;
          public static readonly String Year_Empty_Str = new System.String(' ', Year_Length);

          public static readonly int Site_Length = 2;
          public static readonly int Site_Start_Index = 10;
          public static readonly String Site_Empty_Str = new System.String(' ', Site_Length);

          public static readonly int Logger_Num_Length = 4;
          public static readonly int Logger_Num_Start_Index = 12;
          public static readonly String Logger_Num_Empty_Str = new System.String(' ', Logger_Num_Length);

          public static readonly int Altitude_Length = 8;
          public static readonly int Altitude_Start_Index = 16;
          public static readonly String Altitude_Num_Empty_Str = new System.String(' ', Altitude_Length);

          public static readonly int Longitude_Length = 8;
          public static readonly int Longitude_Start_Index = 24;
          public static readonly String Longitude_Num_Empty_Str = new System.String(' ', Longitude_Length);

          public static readonly int Latitude_Length = 8;
          public static readonly int Latitude_Start_Index = 32;
          public static readonly String Latitude_Num_Empty_Str = new System.String(' ', Latitude_Length);

          /***  Constants for the Header Section of a record ****/
          public static readonly int Data_Code_Length = 4;
          public static readonly int Data_Code_Start_Index = 0;
          public static readonly String Data_Code_Empty_Str = new System.String(' ', Data_Code_Length);

          public static readonly int Inst_Length = 10;
          public static readonly int Inst_Start_Index = 4;
          public static readonly String Inst_Num_Empty_Str = new System.String(' ', Inst_Length);

          public static readonly int Sensitivity_Length = 8;
          public static readonly int Sensitivity_Start_Index = 14;
          public static readonly String Sensitivity_Num_Empty_Str = new System.String(' ', Sensitivity_Length);

          public static readonly int POD_Length = 4;
          public static readonly int POD_Start_Index = 22;
          public static readonly String POD_Num_Empty_Str = new System.String(' ', POD_Length);

          public static readonly int Counts_MV_Length = 8;
          public static readonly int Counts_MV_Start_Index = 26;
          public static readonly String Count_MV_Num_Empty_Str = new System.String(' ', Counts_MV_Length);

          public static readonly int Zero_Offset_Length = 8;
          public static readonly int Zero_Offset_Start_Index = 34;
          public static readonly String Zero_Offset_Empty_Str = new System.String(' ', Zero_Offset_Length);
     }
}
