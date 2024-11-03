
namespace eSpark_WindowsFIA
{
    partial class QuartzScheduler
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
            this.btnNewJob = new System.Windows.Forms.Button();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.txtScanPath = new System.Windows.Forms.TextBox();
            this.btnScanPath = new System.Windows.Forms.Button();
            this.chkHashCalc = new System.Windows.Forms.CheckBox();
            this.numRepeatCntr = new System.Windows.Forms.NumericUpDown();
            this.cmbRepeatDuration = new System.Windows.Forms.ComboBox();
            this.lblScanPath = new System.Windows.Forms.Label();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkRemove = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRemoveJobs = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatCntr)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewJob
            // 
            this.btnNewJob.Location = new System.Drawing.Point(129, 149);
            this.btnNewJob.Name = "btnNewJob";
            this.btnNewJob.Size = new System.Drawing.Size(120, 52);
            this.btnNewJob.TabIndex = 6;
            this.btnNewJob.Text = "Set New Job";
            this.btnNewJob.UseVisualStyleBackColor = true;
            this.btnNewJob.Click += new System.EventHandler(this.btnNewJob_Click);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStartDate.Location = new System.Drawing.Point(112, 16);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtStartDate.TabIndex = 5;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(18, 22);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(88, 13);
            this.lblStart.TabIndex = 7;
            this.lblStart.Text = "Select Start Date";
            // 
            // txtScanPath
            // 
            this.txtScanPath.Location = new System.Drawing.Point(112, 69);
            this.txtScanPath.Name = "txtScanPath";
            this.txtScanPath.Size = new System.Drawing.Size(200, 20);
            this.txtScanPath.TabIndex = 8;
            // 
            // btnScanPath
            // 
            this.btnScanPath.Location = new System.Drawing.Point(318, 67);
            this.btnScanPath.Name = "btnScanPath";
            this.btnScanPath.Size = new System.Drawing.Size(75, 23);
            this.btnScanPath.TabIndex = 9;
            this.btnScanPath.Text = "Scan Path";
            this.btnScanPath.UseVisualStyleBackColor = true;
            this.btnScanPath.Click += new System.EventHandler(this.btnScanPath_Click);
            // 
            // chkHashCalc
            // 
            this.chkHashCalc.AutoSize = true;
            this.chkHashCalc.Location = new System.Drawing.Point(112, 122);
            this.chkHashCalc.Name = "chkHashCalc";
            this.chkHashCalc.Size = new System.Drawing.Size(112, 17);
            this.chkHashCalc.TabIndex = 10;
            this.chkHashCalc.Text = "SHA256 calculate";
            this.chkHashCalc.UseVisualStyleBackColor = true;
            // 
            // numRepeatCntr
            // 
            this.numRepeatCntr.Location = new System.Drawing.Point(112, 43);
            this.numRepeatCntr.Name = "numRepeatCntr";
            this.numRepeatCntr.Size = new System.Drawing.Size(72, 20);
            this.numRepeatCntr.TabIndex = 11;
            // 
            // cmbRepeatDuration
            // 
            this.cmbRepeatDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRepeatDuration.FormattingEnabled = true;
            this.cmbRepeatDuration.Items.AddRange(new object[] {
            "Never",
            "Daily",
            "Weekly",
            "Monthly"});
            this.cmbRepeatDuration.Location = new System.Drawing.Point(191, 42);
            this.cmbRepeatDuration.Name = "cmbRepeatDuration";
            this.cmbRepeatDuration.Size = new System.Drawing.Size(121, 21);
            this.cmbRepeatDuration.TabIndex = 12;
            // 
            // lblScanPath
            // 
            this.lblScanPath.AutoSize = true;
            this.lblScanPath.Location = new System.Drawing.Point(18, 72);
            this.lblScanPath.Name = "lblScanPath";
            this.lblScanPath.Size = new System.Drawing.Size(57, 13);
            this.lblScanPath.TabIndex = 14;
            this.lblScanPath.Text = "Scan Path";
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Location = new System.Drawing.Point(18, 45);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(42, 13);
            this.lblRepeat.TabIndex = 15;
            this.lblRepeat.Text = "Repeat";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkRemove);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbRemoveJobs);
            this.panel1.Controls.Add(this.btnNewJob);
            this.panel1.Controls.Add(this.lblRepeat);
            this.panel1.Controls.Add(this.dtStartDate);
            this.panel1.Controls.Add(this.lblScanPath);
            this.panel1.Controls.Add(this.lblStart);
            this.panel1.Controls.Add(this.cmbRepeatDuration);
            this.panel1.Controls.Add(this.txtScanPath);
            this.panel1.Controls.Add(this.numRepeatCntr);
            this.panel1.Controls.Add(this.btnScanPath);
            this.panel1.Controls.Add(this.chkHashCalc);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 211);
            this.panel1.TabIndex = 16;
            // 
            // chkRemove
            // 
            this.chkRemove.AutoSize = true;
            this.chkRemove.Location = new System.Drawing.Point(200, 99);
            this.chkRemove.Name = "chkRemove";
            this.chkRemove.Size = new System.Drawing.Size(90, 17);
            this.chkRemove.TabIndex = 18;
            this.chkRemove.Text = "Only Remove";
            this.chkRemove.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Remove By";
            // 
            // cmbRemoveJobs
            // 
            this.cmbRemoveJobs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemoveJobs.FormattingEnabled = true;
            this.cmbRemoveJobs.Items.AddRange(new object[] {
            "None",
            "Scan Path",
            "All"});
            this.cmbRemoveJobs.Location = new System.Drawing.Point(112, 95);
            this.cmbRemoveJobs.Name = "cmbRemoveJobs";
            this.cmbRemoveJobs.Size = new System.Drawing.Size(82, 21);
            this.cmbRemoveJobs.TabIndex = 16;
            // 
            // QuartzScheduler
            // 
            this.AcceptButton = this.btnNewJob;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(434, 238);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuartzScheduler";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QuartzScheduler";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatCntr)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewJob;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.TextBox txtScanPath;
        private System.Windows.Forms.Button btnScanPath;
        private System.Windows.Forms.CheckBox chkHashCalc;
        private System.Windows.Forms.NumericUpDown numRepeatCntr;
        private System.Windows.Forms.ComboBox cmbRepeatDuration;
        private System.Windows.Forms.Label lblScanPath;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRemoveJobs;
        private System.Windows.Forms.CheckBox chkRemove;
    }
}