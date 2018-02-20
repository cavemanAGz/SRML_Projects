namespace SFL_2_CSV
{
     partial class SFL_2_CSV_main_form
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
               this.Frm_Btn_SFL_Loc_Browse = new System.Windows.Forms.Button();
               this.label2 = new System.Windows.Forms.Label();
               this.Frm_Btn_SFL_Arch_Loc_Browse = new System.Windows.Forms.Button();
               this.label3 = new System.Windows.Forms.Label();
               this.Frm_Btn_CSV_Out_Loc_Browse = new System.Windows.Forms.Button();
               this.Frm_TxtBx_SFL_Path = new System.Windows.Forms.TextBox();
               this.Frm_TxtBx_SFL_Arch_Path = new System.Windows.Forms.TextBox();
               this.Frm_TxtBx_CSV_Out_Path = new System.Windows.Forms.TextBox();
               this.label1 = new System.Windows.Forms.Label();
               this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
               this.Frm_Btn_Convert_files = new System.Windows.Forms.Button();
               this.Frm_Btn_Qut_App = new System.Windows.Forms.Button();
               this.tableLayoutPanel1.SuspendLayout();
               this.SuspendLayout();
               // 
               // tableLayoutPanel1
               // 
               this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.tableLayoutPanel1.AutoSize = true;
               this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
               this.tableLayoutPanel1.ColumnCount = 3;
               this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
               this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
               this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
               this.tableLayoutPanel1.Controls.Add(this.Frm_Btn_SFL_Loc_Browse, 2, 0);
               this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
               this.tableLayoutPanel1.Controls.Add(this.Frm_Btn_SFL_Arch_Loc_Browse, 2, 1);
               this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
               this.tableLayoutPanel1.Controls.Add(this.Frm_Btn_CSV_Out_Loc_Browse, 2, 2);
               this.tableLayoutPanel1.Controls.Add(this.Frm_TxtBx_SFL_Path, 1, 0);
               this.tableLayoutPanel1.Controls.Add(this.Frm_TxtBx_SFL_Arch_Path, 1, 1);
               this.tableLayoutPanel1.Controls.Add(this.Frm_TxtBx_CSV_Out_Path, 1, 2);
               this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
               this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 12);
               this.tableLayoutPanel1.Name = "tableLayoutPanel1";
               this.tableLayoutPanel1.RowCount = 3;
               this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
               this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
               this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
               this.tableLayoutPanel1.Size = new System.Drawing.Size(1064, 99);
               this.tableLayoutPanel1.TabIndex = 0;
               // 
               // Frm_Btn_SFL_Loc_Browse
               // 
               this.Frm_Btn_SFL_Loc_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.Frm_Btn_SFL_Loc_Browse.Location = new System.Drawing.Point(986, 3);
               this.Frm_Btn_SFL_Loc_Browse.Name = "Frm_Btn_SFL_Loc_Browse";
               this.Frm_Btn_SFL_Loc_Browse.Size = new System.Drawing.Size(75, 27);
               this.Frm_Btn_SFL_Loc_Browse.TabIndex = 0;
               this.Frm_Btn_SFL_Loc_Browse.Text = "Browse...";
               this.Frm_Btn_SFL_Loc_Browse.UseVisualStyleBackColor = true;
               this.Frm_Btn_SFL_Loc_Browse.Click += new System.EventHandler(this.Frm_Btn_SFL_Loc_Browse_Click);
               // 
               // label2
               // 
               this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.label2.AutoSize = true;
               this.label2.Location = new System.Drawing.Point(25, 33);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(119, 33);
               this.label2.TabIndex = 3;
               this.label2.Text = "*.SFL Archive Location:";
               // 
               // Frm_Btn_SFL_Arch_Loc_Browse
               // 
               this.Frm_Btn_SFL_Arch_Loc_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.Frm_Btn_SFL_Arch_Loc_Browse.Location = new System.Drawing.Point(986, 36);
               this.Frm_Btn_SFL_Arch_Loc_Browse.Name = "Frm_Btn_SFL_Arch_Loc_Browse";
               this.Frm_Btn_SFL_Arch_Loc_Browse.Size = new System.Drawing.Size(75, 27);
               this.Frm_Btn_SFL_Arch_Loc_Browse.TabIndex = 1;
               this.Frm_Btn_SFL_Arch_Loc_Browse.Text = "Browse...";
               this.Frm_Btn_SFL_Arch_Loc_Browse.UseVisualStyleBackColor = true;
               this.Frm_Btn_SFL_Arch_Loc_Browse.Click += new System.EventHandler(this.Frm_Btn_SFL_Arch_Loc_Browse_Click);
               // 
               // label3
               // 
               this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.label3.AutoSize = true;
               this.label3.Location = new System.Drawing.Point(65, 66);
               this.label3.Name = "label3";
               this.label3.Size = new System.Drawing.Size(79, 33);
               this.label3.TabIndex = 4;
               this.label3.Text = "*.CSV Location";
               // 
               // Frm_Btn_CSV_Out_Loc_Browse
               // 
               this.Frm_Btn_CSV_Out_Loc_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.Frm_Btn_CSV_Out_Loc_Browse.Location = new System.Drawing.Point(986, 69);
               this.Frm_Btn_CSV_Out_Loc_Browse.Name = "Frm_Btn_CSV_Out_Loc_Browse";
               this.Frm_Btn_CSV_Out_Loc_Browse.Size = new System.Drawing.Size(75, 27);
               this.Frm_Btn_CSV_Out_Loc_Browse.TabIndex = 5;
               this.Frm_Btn_CSV_Out_Loc_Browse.Text = "Browse...";
               this.Frm_Btn_CSV_Out_Loc_Browse.UseVisualStyleBackColor = true;
               this.Frm_Btn_CSV_Out_Loc_Browse.Click += new System.EventHandler(this.Frm_Btn_CSV_Out_Loc_Browse_Click);
               // 
               // Frm_TxtBx_SFL_Path
               // 
               this.Frm_TxtBx_SFL_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.Frm_TxtBx_SFL_Path.Location = new System.Drawing.Point(150, 3);
               this.Frm_TxtBx_SFL_Path.Name = "Frm_TxtBx_SFL_Path";
               this.Frm_TxtBx_SFL_Path.Size = new System.Drawing.Size(827, 20);
               this.Frm_TxtBx_SFL_Path.TabIndex = 6;
               // 
               // Frm_TxtBx_SFL_Arch_Path
               // 
               this.Frm_TxtBx_SFL_Arch_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.Frm_TxtBx_SFL_Arch_Path.Location = new System.Drawing.Point(150, 36);
               this.Frm_TxtBx_SFL_Arch_Path.Name = "Frm_TxtBx_SFL_Arch_Path";
               this.Frm_TxtBx_SFL_Arch_Path.Size = new System.Drawing.Size(827, 20);
               this.Frm_TxtBx_SFL_Arch_Path.TabIndex = 7;
               // 
               // Frm_TxtBx_CSV_Out_Path
               // 
               this.Frm_TxtBx_CSV_Out_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.Frm_TxtBx_CSV_Out_Path.Location = new System.Drawing.Point(150, 69);
               this.Frm_TxtBx_CSV_Out_Path.Name = "Frm_TxtBx_CSV_Out_Path";
               this.Frm_TxtBx_CSV_Out_Path.Size = new System.Drawing.Size(827, 20);
               this.Frm_TxtBx_CSV_Out_Path.TabIndex = 8;
               // 
               // label1
               // 
               this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(64, 0);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(80, 33);
               this.label1.TabIndex = 2;
               this.label1.Text = "*.SFL Location:";
               // 
               // Frm_Btn_Convert_files
               // 
               this.Frm_Btn_Convert_files.Location = new System.Drawing.Point(915, 137);
               this.Frm_Btn_Convert_files.Name = "Frm_Btn_Convert_files";
               this.Frm_Btn_Convert_files.Size = new System.Drawing.Size(75, 23);
               this.Frm_Btn_Convert_files.TabIndex = 1;
               this.Frm_Btn_Convert_files.Text = "SFL --> CSV";
               this.Frm_Btn_Convert_files.UseVisualStyleBackColor = true;
               // 
               // Frm_Btn_Qut_App
               // 
               this.Frm_Btn_Qut_App.Location = new System.Drawing.Point(1002, 137);
               this.Frm_Btn_Qut_App.Name = "Frm_Btn_Qut_App";
               this.Frm_Btn_Qut_App.Size = new System.Drawing.Size(75, 23);
               this.Frm_Btn_Qut_App.TabIndex = 2;
               this.Frm_Btn_Qut_App.Text = "Quit";
               this.Frm_Btn_Qut_App.UseVisualStyleBackColor = true;
               this.Frm_Btn_Qut_App.Click += new System.EventHandler(this.Frm_Btn_Qut_App_Click);
               // 
               // SFL_2_CSV_main_form
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1097, 172);
               this.Controls.Add(this.Frm_Btn_Qut_App);
               this.Controls.Add(this.Frm_Btn_Convert_files);
               this.Controls.Add(this.tableLayoutPanel1);
               this.Name = "SFL_2_CSV_main_form";
               this.Text = "SFL_2_CSV_main_form";
               this.tableLayoutPanel1.ResumeLayout(false);
               this.tableLayoutPanel1.PerformLayout();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
          private System.Windows.Forms.Button Frm_Btn_SFL_Loc_Browse;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.Button Frm_Btn_SFL_Arch_Loc_Browse;
          private System.Windows.Forms.Label label3;
          private System.Windows.Forms.Button Frm_Btn_CSV_Out_Loc_Browse;
          private System.Windows.Forms.TextBox Frm_TxtBx_SFL_Path;
          private System.Windows.Forms.TextBox Frm_TxtBx_SFL_Arch_Path;
          private System.Windows.Forms.TextBox Frm_TxtBx_CSV_Out_Path;
          private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
          private System.Windows.Forms.Button Frm_Btn_Convert_files;
          private System.Windows.Forms.Button Frm_Btn_Qut_App;
     }
}