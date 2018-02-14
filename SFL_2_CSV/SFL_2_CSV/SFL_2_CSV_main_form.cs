using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using file_handler;

namespace SFL_2_CSV
{
     public partial class SFL_2_CSV_main_form : Form
     {
          //allocate a file handler for the SFL location
          File_Handler sfl_loc_fh = null;
          //allocate a file handler for the SFL archive location
          File_Handler sfl_arch_loc_fh = null;
          //allocate a file handler for the CSV output location
          File_Handler csv_loc_fh = null;

          //Hold the text string of the SFL file's location for displaying to users
          string sfl_loc_fldr_path_str = null;
          //Hold the text string of the SFL file's location for displaying to users
          string sfl_archive_loc_fldr_path_str = null;
          //Hold the text string of the SFL file's location for displaying to users
          string csv_loc_fldr_path_str = null;

          public SFL_2_CSV_main_form()
          {
               InitializeComponent();
               //Creat memory for the SFL location file handler
               sfl_loc_fh = new File_Handler();
               //Create a file hanfdler object for where the SFL files will be moved to after
               //conversion
               sfl_arch_loc_fh = new File_Handler();
               //Create a file hanfdler object for the location to stor the new CSV file
               csv_loc_fh = new File_Handler();
          }

          private void button1_Click(object sender, EventArgs e)
          {
               //Open the folder browser window
               sfl_loc_fh.Open_Folder_Dialog();
               //Set the text for the SFL path to local var
               sfl_loc_fldr_path_str = sfl_loc_fh.Get_Folder_Name();
               //Set the textbox value for the selected path
               Frm_Lbl_SFL_Path.Text = sfl_loc_fldr_path_str;
          }

    }
}
