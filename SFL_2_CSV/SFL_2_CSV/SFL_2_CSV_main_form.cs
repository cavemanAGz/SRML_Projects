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
          //Create a file hanfdler object for the SFL location pointer
          File_Handler sfl_loc_fh;
          //Hold the text string of the file location for displaying to users
          string fldr_name = null;

          public SFL_2_CSV_main_form()
          {
               InitializeComponent();
               //Creat memory for the SFL location file handler
               sfl_loc_fh = new File_Handler();
          }

          private void button1_Click(object sender, EventArgs e)
          {
               //Open the folder browser window
               sfl_loc_fh.Open_Folder_Dialog();
               //Set the text for the SFL path to local var
               fldr_name = sfl_loc_fh.Get_Folder_Name();
               //Set the textbox value for the selected path
               Frm_Lbl_SFL_Path.Text = fldr_name;
          }

    }
}
