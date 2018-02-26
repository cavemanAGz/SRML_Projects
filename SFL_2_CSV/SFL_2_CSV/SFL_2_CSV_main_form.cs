using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//THis is fo rthe directory.get method
using System.IO;

using file_handler;
using sfl_parser;

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

        //String array to hold names of files in the directory for parsing
        string[] sfl_list;
        //string[] all_file_list;
        List<string> raw_file_string;

        //Add a parser object to handle file parsing duties
        /*** Gotta think about how to handle this one, maybe use this in the file handler class ***/
        SFL_Parser parser = null;


        //This is the FOrm constructor 
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

            

            /****************** SFL file location section setup ****************************/
            //Set the default text for the label
            Frm_TxtBx_SFL_Path.Text = Properties.Settings.Default.default_sfl_path;
            //Ensure that the folder path string holds the default folder location
            sfl_loc_fldr_path_str = Properties.Settings.Default.default_sfl_path;
            //Set the deeafault path for the folder browser
            sfl_loc_fh.fbd_1.SelectedPath = Properties.Settings.Default.default_sfl_path;

            /****************** SFL file archive location section setup ****************************/
            //Set the default text for the label
            Frm_TxtBx_SFL_Arch_Path.Text = Properties.Settings.Default.default_sfl_arch_path;
            //Set the default folder path from from settings file
            sfl_arch_loc_fh.fbd_1.SelectedPath = Properties.Settings.Default.default_sfl_arch_path;
            //Ensure that the folder path string holds the default folder location
            sfl_arch_loc_fldr_path_str = Properties.Settings.Default.default_sfl_arch_path;

            /****************** CSV output location section setup ****************************/
            //Set the default text for the label
            Frm_TxtBx_CSV_Out_Path.Text = Properties.Settings.Default.default_csv_out_path;
            //Set the default folder path from from settings file
            csv_loc_fh.fbd_1.SelectedPath = Properties.Settings.Default.default_csv_out_path;
            //Ensure that the folder path string holds the default folder location
           csv_loc_fldr_path_str = Properties.Settings.Default.default_csv_out_path;
        }

        private void Frm_Btn_SFL_Loc_Browse_Click(object sender, EventArgs e)
        {
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
            //Open the folder browser window for CSV output location
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
            csv_loc_fh.Open_Folder_Dialog();

            //Do some checks to ensure everything went well here

            //Set the text for the CSV output path to local var
            csv_loc_fldr_path_str = csv_loc_fh.Get_Folder_Name();
            //Set the textbox value for the CSV output path
            Frm_TxtBx_CSV_Out_Path.Text = csv_loc_fldr_path_str;

            //Lets set the default path for next load by using the User settings attribute
            Properties.Settings.Default.default_csv_out_path = csv_loc_fldr_path_str;
            //Save the changes to the properties **** Move this to the SFL->CSV
            Properties.Settings.Default.Save();
          }

        private void Frm_Btn_Qut_App_Click(object sender, EventArgs e)
          {
               Application.Exit();
          }

        private void Frm_Btn_Convert_files_Click(object sender, EventArgs e)
          {
               sfl_list = Directory.GetFiles(sfl_loc_fldr_path_str, "*.sfl");
               foreach(string name in sfl_list)
               {
                    Console.WriteLine("SFL File: " + name);
                    string tmp_str;
                    try
                    {
                         //the file string will begine with name, then the contents of the file
                         tmp_str = @name + @"," + @File.ReadAllText(name);

                         //Check if the list is initialized
                         if (raw_file_string == null)
                         {
                              //List needs to be initialized
                              raw_file_string = new List<string> { tmp_str };
                         }
                         else
                         {
                              //Else just add the next file string
                              raw_file_string.Add(tmp_str);
                         }                         
                         
                    }
                    catch(Exception ex)
                    {
                         Console.WriteLine("The file could not be read:");
                         Console.WriteLine(ex.Message);
                    }                    
               }

               foreach(string sfl in raw_file_string )
               {
                    Console.WriteLine(sfl);
               }
          }
     }
}
