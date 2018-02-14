using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file_handler
{
    public class File_Handler
    {
        public FolderBrowserDialog fbd_1;

        private string folder_name { get;  set; }

        //Constructor for my file handle class
        public File_Handler()
        {
            //Create memory for our SFL path browser object
            fbd_1 = new FolderBrowserDialog();

        }

        public void Open_Folder_Dialog()
        {
            
            DialogResult result = fbd_1.ShowDialog();

            if(result == DialogResult.OK)
            {
                //Set the foldername string
                folder_name = fbd_1.SelectedPath;
                System.Diagnostics.Debug.WriteLine("The folder path is: " + folder_name);

            }
            else if(result == DialogResult.Cancel)
            {
                return;
            }

        }

        public string Get_Folder_Name()
        {
               string tmp_String = folder_name;
               return tmp_String;
        }

    }

}
