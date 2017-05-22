namespace ExcelComparer_Unmatch
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.filedlg = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SaveToExcel = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkbox_case = new System.Windows.Forms.CheckBox();
            this.txtbox_file2 = new System.Windows.Forms.TextBox();
            this.txtbox_file1 = new System.Windows.Forms.TextBox();
            this.btn_browsefile1 = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_CompareAgain = new System.Windows.Forms.Button();
            this.btn_browsefile2 = new System.Windows.Forms.Button();
            this.btn_cmpr = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblloading = new System.Windows.Forms.Label();
            this.comppictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dt_gridview = new System.Windows.Forms.DataGridView();
            this.lblCopyRights = new System.Windows.Forms.Label();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtoninfo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comppictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gridview)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // filedlg
            // 
            this.filedlg.FileName = "openFileDialog1";
            // 
            // SaveToExcel
            // 
            this.SaveToExcel.AutoEllipsis = true;
            this.SaveToExcel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SaveToExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveToExcel.BackgroundImage")));
            this.SaveToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveToExcel.Location = new System.Drawing.Point(745, 14);
            this.SaveToExcel.Name = "SaveToExcel";
            this.SaveToExcel.Size = new System.Drawing.Size(60, 60);
            this.SaveToExcel.TabIndex = 26;
            this.toolTip1.SetToolTip(this.SaveToExcel, "Click to save result in Excel");
            this.SaveToExcel.UseVisualStyleBackColor = false;
            this.SaveToExcel.Click += new System.EventHandler(this.SaveToExcel_Click_1);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(272, 408);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 13);
            this.lbl.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkbox_case);
            this.groupBox1.Controls.Add(this.txtbox_file2);
            this.groupBox1.Controls.Add(this.txtbox_file1);
            this.groupBox1.Controls.Add(this.btn_browsefile1);
            this.groupBox1.Controls.Add(this.Btn_Cancel);
            this.groupBox1.Controls.Add(this.Btn_CompareAgain);
            this.groupBox1.Controls.Add(this.btn_browsefile2);
            this.groupBox1.Controls.Add(this.btn_cmpr);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.MaximumSize = new System.Drawing.Size(1200, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 156);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Calligraphy", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(381, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "Second File ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Calligraphy", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(391, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "First File";
            // 
            // checkbox_case
            // 
            this.checkbox_case.AutoSize = true;
            this.checkbox_case.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_case.Location = new System.Drawing.Point(593, 20);
            this.checkbox_case.Name = "checkbox_case";
            this.checkbox_case.Size = new System.Drawing.Size(105, 23);
            this.checkbox_case.TabIndex = 2;
            this.checkbox_case.Text = "Ignore Case";
            this.checkbox_case.UseVisualStyleBackColor = true;
            // 
            // txtbox_file2
            // 
            this.txtbox_file2.Location = new System.Drawing.Point(18, 80);
            this.txtbox_file2.Multiline = true;
            this.txtbox_file2.Name = "txtbox_file2";
            this.txtbox_file2.Size = new System.Drawing.Size(443, 45);
            this.txtbox_file2.TabIndex = 15;
            // 
            // txtbox_file1
            // 
            this.txtbox_file1.Location = new System.Drawing.Point(18, 20);
            this.txtbox_file1.Multiline = true;
            this.txtbox_file1.Name = "txtbox_file1";
            this.txtbox_file1.Size = new System.Drawing.Size(443, 45);
            this.txtbox_file1.TabIndex = 14;
            // 
            // btn_browsefile1
            // 
            this.btn_browsefile1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_browsefile1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_browsefile1.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.btn_browsefile1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_browsefile1.Image = ((System.Drawing.Image)(resources.GetObject("btn_browsefile1.Image")));
            this.btn_browsefile1.Location = new System.Drawing.Point(467, 14);
            this.btn_browsefile1.Margin = new System.Windows.Forms.Padding(0);
            this.btn_browsefile1.Name = "btn_browsefile1";
            this.btn_browsefile1.Size = new System.Drawing.Size(60, 55);
            this.btn_browsefile1.TabIndex = 13;
            this.btn_browsefile1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_browsefile1.UseVisualStyleBackColor = false;
            this.btn_browsefile1.Click += new System.EventHandler(this.btn_browsefile1_Click_1);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Btn_Cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Cancel.BackgroundImage")));
            this.Btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Cancel.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Cancel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Btn_Cancel.Location = new System.Drawing.Point(723, 70);
            this.Btn_Cancel.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(60, 60);
            this.Btn_Cancel.TabIndex = 28;
            this.Btn_Cancel.UseVisualStyleBackColor = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click_1);
            // 
            // Btn_CompareAgain
            // 
            this.Btn_CompareAgain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Btn_CompareAgain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_CompareAgain.BackgroundImage")));
            this.Btn_CompareAgain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_CompareAgain.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_CompareAgain.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Btn_CompareAgain.Location = new System.Drawing.Point(658, 70);
            this.Btn_CompareAgain.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_CompareAgain.Name = "Btn_CompareAgain";
            this.Btn_CompareAgain.Size = new System.Drawing.Size(60, 60);
            this.Btn_CompareAgain.TabIndex = 29;
            this.Btn_CompareAgain.UseVisualStyleBackColor = false;
            this.Btn_CompareAgain.Click += new System.EventHandler(this.Btn_CompareAgain_Click_1);
            // 
            // btn_browsefile2
            // 
            this.btn_browsefile2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_browsefile2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_browsefile2.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.btn_browsefile2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_browsefile2.Image = ((System.Drawing.Image)(resources.GetObject("btn_browsefile2.Image")));
            this.btn_browsefile2.Location = new System.Drawing.Point(468, 75);
            this.btn_browsefile2.Name = "btn_browsefile2";
            this.btn_browsefile2.Size = new System.Drawing.Size(60, 55);
            this.btn_browsefile2.TabIndex = 0;
            this.btn_browsefile2.UseVisualStyleBackColor = false;
            this.btn_browsefile2.Click += new System.EventHandler(this.btn_browsefile2_Click);
            // 
            // btn_cmpr
            // 
            this.btn_cmpr.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_cmpr.BackgroundImage = global::ExcelComparer_Unmatch.Properties.Resources.process_accept_icon;
            this.btn_cmpr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cmpr.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.btn_cmpr.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_cmpr.Location = new System.Drawing.Point(593, 71);
            this.btn_cmpr.Name = "btn_cmpr";
            this.btn_cmpr.Size = new System.Drawing.Size(60, 60);
            this.btn_cmpr.TabIndex = 3;
            this.btn_cmpr.UseVisualStyleBackColor = false;
            this.btn_cmpr.Click += new System.EventHandler(this.btn_cmpr_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.lblloading);
            this.groupBox2.Controls.Add(this.comppictureBox);
            this.groupBox2.Controls.Add(this.statusStrip1);
            this.groupBox2.Controls.Add(this.SaveToExcel);
            this.groupBox2.Controls.Add(this.dt_gridview);
            this.groupBox2.Location = new System.Drawing.Point(12, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(829, 428);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ExcelComparer_Unmatch.Properties.Resources.ajax_loader__2_;
            this.pictureBox2.InitialImage = global::ExcelComparer_Unmatch.Properties.Resources.ajax_loader__2_;
            this.pictureBox2.Location = new System.Drawing.Point(341, 203);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 15);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // lblloading
            // 
            this.lblloading.AutoSize = true;
            this.lblloading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblloading.Location = new System.Drawing.Point(217, 238);
            this.lblloading.Name = "lblloading";
            this.lblloading.Size = new System.Drawing.Size(410, 17);
            this.lblloading.TabIndex = 37;
            this.lblloading.Text = "Loading Data....Please Wait..For large files it will take some time";
            // 
            // comppictureBox
            // 
            this.comppictureBox.Image = ((System.Drawing.Image)(resources.GetObject("comppictureBox.Image")));
            this.comppictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("comppictureBox.InitialImage")));
            this.comppictureBox.Location = new System.Drawing.Point(384, 165);
            this.comppictureBox.Name = "comppictureBox";
            this.comppictureBox.Size = new System.Drawing.Size(32, 32);
            this.comppictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.comppictureBox.TabIndex = 32;
            this.comppictureBox.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 403);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(823, 22);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // dt_gridview
            // 
            this.dt_gridview.AllowUserToAddRows = false;
            this.dt_gridview.AllowUserToDeleteRows = false;
            this.dt_gridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dt_gridview.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dt_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_gridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dt_gridview.Location = new System.Drawing.Point(21, 77);
            this.dt_gridview.Name = "dt_gridview";
            this.dt_gridview.ReadOnly = true;
            this.dt_gridview.Size = new System.Drawing.Size(783, 307);
            this.dt_gridview.TabIndex = 25;
            // 
            // lblCopyRights
            // 
            this.lblCopyRights.AutoSize = true;
            this.lblCopyRights.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyRights.Location = new System.Drawing.Point(342, 668);
            this.lblCopyRights.Name = "lblCopyRights";
            this.lblCopyRights.Size = new System.Drawing.Size(217, 13);
            this.lblCopyRights.TabIndex = 18;
            this.lblCopyRights.Text = "Copyright © Capgemini. All Rights Reserved.";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(78)))), ((int)(((byte)(105)))));
            this.toolStripLabel1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(504, 67);
            this.toolStripLabel1.Text = "                                                                             Exce" +
    "l Report Comparer ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(78)))), ((int)(((byte)(105)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtoninfo,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(854, 70);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtoninfo
            // 
            this.toolStripButtoninfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtoninfo.AutoSize = false;
            this.toolStripButtoninfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripButtoninfo.BackgroundImage")));
            this.toolStripButtoninfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripButtoninfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtoninfo.Name = "toolStripButtoninfo";
            this.toolStripButtoninfo.Size = new System.Drawing.Size(0, 58);
            this.toolStripButtoninfo.ToolTipText = "Click To See Preconditon for Comparison";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripLabel2.BackgroundImage")));
            this.toolStripLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripLabel2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(80, 72);
            this.toolStripLabel2.ToolTipText = "Click to see Instructions!!!";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(668, 657);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(854, 702);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCopyRights);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lbl);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Excel Report Comparer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comppictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gridview)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog filedlg;
        private System.Windows.Forms.Button btn_browsefile2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btn_browsefile1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtbox_file2;
        private System.Windows.Forms.TextBox txtbox_file1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCopyRights;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkbox_case;
        private System.Windows.Forms.Button Btn_CompareAgain;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button SaveToExcel;
        private System.Windows.Forms.DataGridView dt_gridview;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btn_cmpr;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripButtoninfo;
        private System.Windows.Forms.PictureBox comppictureBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblloading;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

