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
        string sfl_arch_loc_fldr_path_str = null;
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

            Frm_TxtBx_SFL_Path.Text = Properties.Settings.Default.default_sfl_path;
            Frm_TxtBx_SFL_Arch_Path.Text = Properties.Settings.Default.default_sfl_arch_path;
            Frm_TxtBx_CSV_Out_Path.Text = Properties.Settings.Default.default_csv_out_path;

        }

        private void Frm_Btn_SFL_Loc_Browse_Click(object sender, EventArgs e)
        {
            //Set the deeafault path for the folder browser
            sfl_loc_fh.fbd_1.SelectedPath = Properties.Settings.Default.default_sfl_path;
            //Open the folder browser window for SFL location
            sfl_loc_fh.Open_Folder_Dialog();

            //Do some checks to ensure everything went well here

            //Set the text for the SFL path to local var
            sfl_loc_fldr_path_str = sfl_loc_fh.Get_Folder_Name();
            //Set the textbox value for the selected path
            Frm_TxtBx_SFL_Path.Text = sfl_loc_fldr_path_str;

            //Lets set the default path for next load by using the User settings attribute
            Properties.Settings.Default.default_sfl_path = sfl_loc_fldr_path_str;
            //Save the changes to the properties **** Move this to the SFL->CSV
            Properties.Settings.Default.Save();
        }

        private void Frm_Btn_SFL_Arch_Loc_Browse_Click(object sender, EventArgs e)
        {
            //Set the default folder path from from settings file
            sfl_arch_loc_fh.fbd_1.SelectedPath = Properties.Settings.Default.default_sfl_arch_path;
            //Open the folder browser window for SFL archive location
            sfl_arch_loc_fh.Open_Folder_Dialog();

            //Do some checks to ensure everything went well here


            //Set the text for the SFL archive path to local var
            sfl_arch_loc_fldr_path_str = sfl_arch_loc_fh.Get_Folder_Name();
            //Set the textbox value for the selected SFL archive path
            Frm_TxtBx_SFL_Arch_Path.Text = sfl_arch_loc_fldr_path_str;

            //Lets set the default path for next load by using the User settings attribute
            Properties.Settings.Default.default_sfl_arch_path = sfl_arch_loc_fldr_path_str;
            //Save the changes to the properties **** Move this to the SFL->CSV
            Properties.Settings.Default.Save();
        }

        private void Frm_Btn_CSV_Out_Loc_Browse_Click(object sender, EventArgs e)
        {
            //Open the folder browser window to set CSV output folder
            csv_loc_fh.Open_Folder_Dialog();
            //Set the text for the CSV output path to local var
            csv_loc_fldr_path_str = csv_loc_fh.Get_Folder_Name();
            //Set the textbox value for the CSV output path
            Frm_TxtBx_CSV_Out_Path.Text = csv_loc_fldr_path_str;
        }
    }
}
