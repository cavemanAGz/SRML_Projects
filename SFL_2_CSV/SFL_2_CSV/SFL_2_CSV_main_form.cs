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
        File_Handler sfl_loc_fh;

          public SFL_2_CSV_main_form()
          {
               InitializeComponent();
               sfl_loc_fh = new File_Handler();
          }

          private void button1_Click(object sender, EventArgs e)
          {
            //folderBrowserDialog1.ShowDialog();
            sfl_loc_fh.Open_SFL_LOC_Dialog();
          }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
