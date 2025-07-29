
namespace eSpark_WindowsFIA
{
    partial class SchedulerNew
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
            this.btnNewJob = new MetroSet_UI.Controls.MetroSetButton();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new MetroSet_UI.Controls.MetroSetLabel();
            this.txtScanPath = new MetroSet_UI.Controls.MetroSetTextBox();
            this.btnScanPath = new MetroSet_UI.Controls.MetroSetButton();
            this.lblScanPath = new MetroSet_UI.Controls.MetroSetLabel();
            this.panel1 = new MetroSet_UI.Controls.MetroSetPanel();
            this.metroSetLabel4 = new MetroSet_UI.Controls.MetroSetLabel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.metroSetLabel3 = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetLabel2 = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetLabel1 = new MetroSet_UI.Controls.MetroSetLabel();
            this.chkQuartzJobs = new MetroSet_UI.Controls.MetroSetSwitch();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Monday = new MetroSet_UI.Controls.MetroSetCheckBox();
            this.Tuesday = new MetroSet_UI.Controls.MetroSetCheckBox();
            this.Sunday = new MetroSet_UI.Controls.MetroSetCheckBox();
            this.Wednesday = new MetroSet_UI.Controls.MetroSetCheckBox();
            this.Saturday = new MetroSet_UI.Controls.MetroSetCheckBox();
            this.Thursday = new MetroSet_UI.Controls.MetroSetCheckBox();
            this.Friday = new MetroSet_UI.Controls.MetroSetCheckBox();
            this.label2 = new MetroSet_UI.Controls.MetroSetLabel();
            this.chkRemove = new MetroSet_UI.Controls.MetroSetCheckBox();
            this.label1 = new MetroSet_UI.Controls.MetroSetLabel();
            this.cmbRemoveJobs = new MetroSet_UI.Controls.MetroSetComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
            this.metroSetLabel9 = new MetroSet_UI.Controls.MetroSetLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewJob
            // 
            this.btnNewJob.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNewJob.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNewJob.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnNewJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnNewJob.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnNewJob.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnNewJob.HoverTextColor = System.Drawing.Color.White;
            this.btnNewJob.IsDerivedStyle = true;
            this.btnNewJob.Location = new System.Drawing.Point(185, 239);
            this.btnNewJob.Name = "btnNewJob";
            this.btnNewJob.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNewJob.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNewJob.NormalTextColor = System.Drawing.Color.White;
            this.btnNewJob.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnNewJob.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnNewJob.PressTextColor = System.Drawing.Color.White;
            this.btnNewJob.Size = new System.Drawing.Size(120, 52);
            this.btnNewJob.Style = MetroSet_UI.Enums.Style.Light;
            this.btnNewJob.StyleManager = null;
            this.btnNewJob.TabIndex = 14;
            this.btnNewJob.Text = "Set New Job";
            this.btnNewJob.ThemeAuthor = "Narwin";
            this.btnNewJob.ThemeName = "MetroLite";
            this.btnNewJob.Click += new System.EventHandler(this.btnNewJob_Click);
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "dd/MMM/yyyy hh:mm:ss tttt";
            this.dtStartDate.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(150, 16);
            this.dtStartDate.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dtStartDate.MinDate = System.DateTime.Now.AddMinutes(15);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(301, 25);
            this.dtStartDate.TabIndex = 1;
            this.dtStartDate.Value = System.DateTime.Now.AddMinutes(15);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblStart.IsDerivedStyle = true;
            this.lblStart.Location = new System.Drawing.Point(17, 23);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(115, 17);
            this.lblStart.Style = MetroSet_UI.Enums.Style.Light;
            this.lblStart.StyleManager = null;
            this.lblStart.TabIndex = 7;
            this.lblStart.Text = "Select Start Date";
            this.lblStart.ThemeAuthor = "Narwin";
            this.lblStart.ThemeName = "MetroLite";
            // 
            // txtScanPath
            // 
            this.txtScanPath.AutoCompleteCustomSource = null;
            this.txtScanPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtScanPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtScanPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtScanPath.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtScanPath.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtScanPath.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.txtScanPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtScanPath.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtScanPath.Image = null;
            this.txtScanPath.IsDerivedStyle = true;
            this.txtScanPath.Lines = null;
            this.txtScanPath.Location = new System.Drawing.Point(150, 137);
            this.txtScanPath.MaxLength = 32767;
            this.txtScanPath.Multiline = false;
            this.txtScanPath.Name = "txtScanPath";
            this.txtScanPath.ReadOnly = false;
            this.txtScanPath.Size = new System.Drawing.Size(200, 27);
            this.txtScanPath.Style = MetroSet_UI.Enums.Style.Light;
            this.txtScanPath.StyleManager = null;
            this.txtScanPath.TabIndex = 10;
            this.txtScanPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtScanPath.ThemeAuthor = "Narwin";
            this.txtScanPath.ThemeName = "MetroLite";
            this.txtScanPath.UseSystemPasswordChar = false;
            this.txtScanPath.WatermarkText = "";
            // 
            // btnScanPath
            // 
            this.btnScanPath.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnScanPath.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnScanPath.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnScanPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnScanPath.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnScanPath.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnScanPath.HoverTextColor = System.Drawing.Color.White;
            this.btnScanPath.IsDerivedStyle = true;
            this.btnScanPath.Location = new System.Drawing.Point(356, 136);
            this.btnScanPath.Name = "btnScanPath";
            this.btnScanPath.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnScanPath.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnScanPath.NormalTextColor = System.Drawing.Color.White;
            this.btnScanPath.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnScanPath.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnScanPath.PressTextColor = System.Drawing.Color.White;
            this.btnScanPath.Size = new System.Drawing.Size(95, 23);
            this.btnScanPath.Style = MetroSet_UI.Enums.Style.Light;
            this.btnScanPath.StyleManager = null;
            this.btnScanPath.TabIndex = 11;
            this.btnScanPath.Text = "Scan Path";
            this.btnScanPath.ThemeAuthor = "Narwin";
            this.btnScanPath.ThemeName = "MetroLite";
            this.btnScanPath.Click += new System.EventHandler(this.btnScanPath_Click);
            // 
            // lblScanPath
            // 
            this.lblScanPath.AutoSize = true;
            this.lblScanPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblScanPath.IsDerivedStyle = true;
            this.lblScanPath.Location = new System.Drawing.Point(16, 137);
            this.lblScanPath.Name = "lblScanPath";
            this.lblScanPath.Size = new System.Drawing.Size(73, 17);
            this.lblScanPath.Style = MetroSet_UI.Enums.Style.Light;
            this.lblScanPath.StyleManager = null;
            this.lblScanPath.TabIndex = 14;
            this.lblScanPath.Text = "Scan Path";
            this.lblScanPath.ThemeAuthor = "Narwin";
            this.lblScanPath.ThemeName = "MetroLite";
            // 
            // panel1
            // 
            this.panel1.BackgroundColor = System.Drawing.Color.White;
            this.panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.panel1.BorderThickness = 1;
            this.panel1.Controls.Add(this.metroSetLabel4);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.metroSetLabel3);
            this.panel1.Controls.Add(this.metroSetLabel2);
            this.panel1.Controls.Add(this.metroSetLabel1);
            this.panel1.Controls.Add(this.chkQuartzJobs);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkRemove);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbRemoveJobs);
            this.panel1.Controls.Add(this.btnNewJob);
            this.panel1.Controls.Add(this.dtStartDate);
            this.panel1.Controls.Add(this.lblScanPath);
            this.panel1.Controls.Add(this.lblStart);
            this.panel1.Controls.Add(this.txtScanPath);
            this.panel1.Controls.Add(this.btnScanPath);
            this.panel1.IsDerivedStyle = true;
            this.panel1.Location = new System.Drawing.Point(15, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 299);
            this.panel1.Style = MetroSet_UI.Enums.Style.Light;
            this.panel1.StyleManager = null;
            this.panel1.TabIndex = 16;
            this.panel1.ThemeAuthor = "Narwin";
            this.panel1.ThemeName = "MetroLite";
            // 
            // metroSetLabel4
            // 
            this.metroSetLabel4.AutoSize = true;
            this.metroSetLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetLabel4.IsDerivedStyle = true;
            this.metroSetLabel4.Location = new System.Drawing.Point(226, 54);
            this.metroSetLabel4.Name = "metroSetLabel4";
            this.metroSetLabel4.Size = new System.Drawing.Size(28, 17);
            this.metroSetLabel4.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel4.StyleManager = null;
            this.metroSetLabel4.TabIndex = 33;
            this.metroSetLabel4.Text = "hrs";
            this.metroSetLabel4.ThemeAuthor = "Narwin";
            this.metroSetLabel4.ThemeName = "MetroLite";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(150, 48);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(68, 25);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // metroSetLabel3
            // 
            this.metroSetLabel3.AutoSize = true;
            this.metroSetLabel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.metroSetLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.metroSetLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroSetLabel3.IsDerivedStyle = true;
            this.metroSetLabel3.Location = new System.Drawing.Point(216, 207);
            this.metroSetLabel3.Name = "metroSetLabel3";
            this.metroSetLabel3.Size = new System.Drawing.Size(2, 18);
            this.metroSetLabel3.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel3.StyleManager = null;
            this.metroSetLabel3.TabIndex = 31;
            this.metroSetLabel3.ThemeAuthor = "Narwin";
            this.metroSetLabel3.ThemeName = "MetroLite";
            // 
            // metroSetLabel2
            // 
            this.metroSetLabel2.AutoSize = true;
            this.metroSetLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetLabel2.IsDerivedStyle = true;
            this.metroSetLabel2.Location = new System.Drawing.Point(16, 207);
            this.metroSetLabel2.Name = "metroSetLabel2";
            this.metroSetLabel2.Size = new System.Drawing.Size(118, 17);
            this.metroSetLabel2.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel2.StyleManager = null;
            this.metroSetLabel2.TabIndex = 30;
            this.metroSetLabel2.Text = "Quartz Jobs Only";
            this.metroSetLabel2.ThemeAuthor = "Narwin";
            this.metroSetLabel2.ThemeName = "MetroLite";
            // 
            // metroSetLabel1
            // 
            this.metroSetLabel1.AutoSize = true;
            this.metroSetLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetLabel1.IsDerivedStyle = true;
            this.metroSetLabel1.Location = new System.Drawing.Point(17, 54);
            this.metroSetLabel1.Name = "metroSetLabel1";
            this.metroSetLabel1.Size = new System.Drawing.Size(94, 17);
            this.metroSetLabel1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel1.StyleManager = null;
            this.metroSetLabel1.TabIndex = 29;
            this.metroSetLabel1.Text = "Repeat Every";
            this.metroSetLabel1.ThemeAuthor = "Narwin";
            this.metroSetLabel1.ThemeName = "MetroLite";
            // 
            // chkQuartzJobs
            // 
            this.chkQuartzJobs.BackColor = System.Drawing.Color.Transparent;
            this.chkQuartzJobs.BackgroundColor = System.Drawing.Color.Empty;
            this.chkQuartzJobs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(147)))));
            this.chkQuartzJobs.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.chkQuartzJobs.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.chkQuartzJobs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkQuartzJobs.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.chkQuartzJobs.DisabledCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.chkQuartzJobs.DisabledUnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.chkQuartzJobs.IsDerivedStyle = true;
            this.chkQuartzJobs.Location = new System.Drawing.Point(150, 205);
            this.chkQuartzJobs.Name = "chkQuartzJobs";
            this.chkQuartzJobs.Size = new System.Drawing.Size(58, 22);
            this.chkQuartzJobs.Style = MetroSet_UI.Enums.Style.Light;
            this.chkQuartzJobs.StyleManager = null;
            this.chkQuartzJobs.Switched = false;
            this.chkQuartzJobs.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.chkQuartzJobs.TabIndex = 28;
            this.chkQuartzJobs.Text = "Create Quartz Tasks Only!";
            this.chkQuartzJobs.ThemeAuthor = "Narwin";
            this.chkQuartzJobs.ThemeName = "MetroLite";
            this.chkQuartzJobs.UnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Monday);
            this.groupBox1.Controls.Add(this.Tuesday);
            this.groupBox1.Controls.Add(this.Sunday);
            this.groupBox1.Controls.Add(this.Wednesday);
            this.groupBox1.Controls.Add(this.Saturday);
            this.groupBox1.Controls.Add(this.Thursday);
            this.groupBox1.Controls.Add(this.Friday);
            this.groupBox1.Location = new System.Drawing.Point(150, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 57);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // Monday
            // 
            this.Monday.BackColor = System.Drawing.Color.Transparent;
            this.Monday.BackgroundColor = System.Drawing.Color.White;
            this.Monday.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.Monday.Checked = false;
            this.Monday.CheckSignColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Monday.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.Monday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Monday.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.Monday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Monday.IsDerivedStyle = true;
            this.Monday.Location = new System.Drawing.Point(6, 12);
            this.Monday.Name = "Monday";
            this.Monday.SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
            this.Monday.Size = new System.Drawing.Size(47, 16);
            this.Monday.Style = MetroSet_UI.Enums.Style.Light;
            this.Monday.StyleManager = null;
            this.Monday.TabIndex = 3;
            this.Monday.Text = "Mon";
            this.Monday.ThemeAuthor = "Narwin";
            this.Monday.ThemeName = "MetroLite";
            // 
            // Tuesday
            // 
            this.Tuesday.BackColor = System.Drawing.Color.Transparent;
            this.Tuesday.BackgroundColor = System.Drawing.Color.White;
            this.Tuesday.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.Tuesday.Checked = false;
            this.Tuesday.CheckSignColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Tuesday.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.Tuesday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tuesday.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.Tuesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Tuesday.IsDerivedStyle = true;
            this.Tuesday.Location = new System.Drawing.Point(64, 12);
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
            this.Tuesday.Size = new System.Drawing.Size(45, 16);
            this.Tuesday.Style = MetroSet_UI.Enums.Style.Light;
            this.Tuesday.StyleManager = null;
            this.Tuesday.TabIndex = 4;
            this.Tuesday.Text = "Tue";
            this.Tuesday.ThemeAuthor = "Narwin";
            this.Tuesday.ThemeName = "MetroLite";
            // 
            // Sunday
            // 
            this.Sunday.BackColor = System.Drawing.Color.Transparent;
            this.Sunday.BackgroundColor = System.Drawing.Color.White;
            this.Sunday.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.Sunday.Checked = false;
            this.Sunday.CheckSignColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Sunday.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.Sunday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Sunday.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.Sunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Sunday.IsDerivedStyle = true;
            this.Sunday.Location = new System.Drawing.Point(125, 35);
            this.Sunday.Name = "Sunday";
            this.Sunday.SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
            this.Sunday.Size = new System.Drawing.Size(45, 16);
            this.Sunday.Style = MetroSet_UI.Enums.Style.Light;
            this.Sunday.StyleManager = null;
            this.Sunday.TabIndex = 9;
            this.Sunday.Text = "Sun";
            this.Sunday.ThemeAuthor = "Narwin";
            this.Sunday.ThemeName = "MetroLite";
            // 
            // Wednesday
            // 
            this.Wednesday.BackColor = System.Drawing.Color.Transparent;
            this.Wednesday.BackgroundColor = System.Drawing.Color.White;
            this.Wednesday.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.Wednesday.Checked = false;
            this.Wednesday.CheckSignColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Wednesday.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.Wednesday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Wednesday.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.Wednesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Wednesday.IsDerivedStyle = true;
            this.Wednesday.Location = new System.Drawing.Point(125, 12);
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
            this.Wednesday.Size = new System.Drawing.Size(49, 16);
            this.Wednesday.Style = MetroSet_UI.Enums.Style.Light;
            this.Wednesday.StyleManager = null;
            this.Wednesday.TabIndex = 5;
            this.Wednesday.Text = "Wed";
            this.Wednesday.ThemeAuthor = "Narwin";
            this.Wednesday.ThemeName = "MetroLite";
            // 
            // Saturday
            // 
            this.Saturday.BackColor = System.Drawing.Color.Transparent;
            this.Saturday.BackgroundColor = System.Drawing.Color.White;
            this.Saturday.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.Saturday.Checked = false;
            this.Saturday.CheckSignColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Saturday.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.Saturday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Saturday.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.Saturday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Saturday.IsDerivedStyle = true;
            this.Saturday.Location = new System.Drawing.Point(64, 35);
            this.Saturday.Name = "Saturday";
            this.Saturday.SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
            this.Saturday.Size = new System.Drawing.Size(42, 16);
            this.Saturday.Style = MetroSet_UI.Enums.Style.Light;
            this.Saturday.StyleManager = null;
            this.Saturday.TabIndex = 8;
            this.Saturday.Text = "Sat";
            this.Saturday.ThemeAuthor = "Narwin";
            this.Saturday.ThemeName = "MetroLite";
            // 
            // Thursday
            // 
            this.Thursday.BackColor = System.Drawing.Color.Transparent;
            this.Thursday.BackgroundColor = System.Drawing.Color.White;
            this.Thursday.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.Thursday.Checked = false;
            this.Thursday.CheckSignColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Thursday.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.Thursday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Thursday.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.Thursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Thursday.IsDerivedStyle = true;
            this.Thursday.Location = new System.Drawing.Point(188, 12);
            this.Thursday.Name = "Thursday";
            this.Thursday.SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
            this.Thursday.Size = new System.Drawing.Size(45, 16);
            this.Thursday.Style = MetroSet_UI.Enums.Style.Light;
            this.Thursday.StyleManager = null;
            this.Thursday.TabIndex = 6;
            this.Thursday.Text = "Thu";
            this.Thursday.ThemeAuthor = "Narwin";
            this.Thursday.ThemeName = "MetroLite";
            // 
            // Friday
            // 
            this.Friday.BackColor = System.Drawing.Color.Transparent;
            this.Friday.BackgroundColor = System.Drawing.Color.White;
            this.Friday.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.Friday.Checked = false;
            this.Friday.CheckSignColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Friday.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.Friday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Friday.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.Friday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Friday.IsDerivedStyle = true;
            this.Friday.Location = new System.Drawing.Point(6, 35);
            this.Friday.Name = "Friday";
            this.Friday.SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
            this.Friday.Size = new System.Drawing.Size(37, 16);
            this.Friday.Style = MetroSet_UI.Enums.Style.Light;
            this.Friday.StyleManager = null;
            this.Friday.TabIndex = 7;
            this.Friday.Text = "Fri";
            this.Friday.ThemeAuthor = "Narwin";
            this.Friday.ThemeName = "MetroLite";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.IsDerivedStyle = true;
            this.label2.Location = new System.Drawing.Point(15, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.Style = MetroSet_UI.Enums.Style.Light;
            this.label2.StyleManager = null;
            this.label2.TabIndex = 26;
            this.label2.Text = "Exclude WeekDays";
            this.label2.ThemeAuthor = "Narwin";
            this.label2.ThemeName = "MetroLite";
            // 
            // chkRemove
            // 
            this.chkRemove.BackColor = System.Drawing.Color.Transparent;
            this.chkRemove.BackgroundColor = System.Drawing.Color.White;
            this.chkRemove.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.chkRemove.Checked = false;
            this.chkRemove.CheckSignColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.chkRemove.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.chkRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRemove.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.chkRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkRemove.IsDerivedStyle = true;
            this.chkRemove.Location = new System.Drawing.Point(341, 180);
            this.chkRemove.Name = "chkRemove";
            this.chkRemove.SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
            this.chkRemove.Size = new System.Drawing.Size(110, 16);
            this.chkRemove.Style = MetroSet_UI.Enums.Style.Light;
            this.chkRemove.StyleManager = null;
            this.chkRemove.TabIndex = 18;
            this.chkRemove.Text = "Only Remove";
            this.chkRemove.ThemeAuthor = "Narwin";
            this.chkRemove.ThemeName = "MetroLite";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.IsDerivedStyle = true;
            this.label1.Location = new System.Drawing.Point(16, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.Style = MetroSet_UI.Enums.Style.Light;
            this.label1.StyleManager = null;
            this.label1.TabIndex = 17;
            this.label1.Text = "Remove By";
            this.label1.ThemeAuthor = "Narwin";
            this.label1.ThemeName = "MetroLite";
            // 
            // cmbRemoveJobs
            // 
            this.cmbRemoveJobs.AllowDrop = true;
            this.cmbRemoveJobs.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmbRemoveJobs.BackColor = System.Drawing.Color.Transparent;
            this.cmbRemoveJobs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cmbRemoveJobs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmbRemoveJobs.CausesValidation = false;
            this.cmbRemoveJobs.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbRemoveJobs.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cmbRemoveJobs.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.cmbRemoveJobs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRemoveJobs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemoveJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbRemoveJobs.FormattingEnabled = true;
            this.cmbRemoveJobs.IsDerivedStyle = true;
            this.cmbRemoveJobs.ItemHeight = 20;
            this.cmbRemoveJobs.Items.AddRange(new object[] {
            "None",
            "Scan Path",
            "All"});
            this.cmbRemoveJobs.Location = new System.Drawing.Point(150, 171);
            this.cmbRemoveJobs.Name = "cmbRemoveJobs";
            this.cmbRemoveJobs.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cmbRemoveJobs.SelectedItemForeColor = System.Drawing.Color.White;
            this.cmbRemoveJobs.Size = new System.Drawing.Size(185, 26);
            this.cmbRemoveJobs.Style = MetroSet_UI.Enums.Style.Light;
            this.cmbRemoveJobs.StyleManager = null;
            this.cmbRemoveJobs.TabIndex = 12;
            this.cmbRemoveJobs.ThemeAuthor = "Narwin";
            this.cmbRemoveJobs.ThemeName = "MetroLite";
            // 
            // metroSetControlBox1
            // 
            this.metroSetControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.DimGray;
            this.metroSetControlBox1.IsDerivedStyle = false;
            this.metroSetControlBox1.Location = new System.Drawing.Point(384, 7);
            this.metroSetControlBox1.MaximizeBox = false;
            this.metroSetControlBox1.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetControlBox1.MaximizeHoverForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MaximizeNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MinimizeBox = false;
            this.metroSetControlBox1.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetControlBox1.MinimizeHoverForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MinimizeNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.Name = "metroSetControlBox1";
            this.metroSetControlBox1.Size = new System.Drawing.Size(100, 25);
            this.metroSetControlBox1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetControlBox1.StyleManager = null;
            this.metroSetControlBox1.TabIndex = 17;
            this.metroSetControlBox1.Text = "metroSetControlBox1";
            this.metroSetControlBox1.ThemeAuthor = "Narwin";
            this.metroSetControlBox1.ThemeName = "MetroLite";
            // 
            // metroSetLabel9
            // 
            this.metroSetLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroSetLabel9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.metroSetLabel9.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroSetLabel9.IsDerivedStyle = true;
            this.metroSetLabel9.Location = new System.Drawing.Point(25, 70);
            this.metroSetLabel9.Name = "metroSetLabel9";
            this.metroSetLabel9.Size = new System.Drawing.Size(436, 27);
            this.metroSetLabel9.Style = MetroSet_UI.Enums.Style.Dark;
            this.metroSetLabel9.StyleManager = null;
            this.metroSetLabel9.TabIndex = 32;
            this.metroSetLabel9.Text = "Managing Task Scheduler with File System Agents";
            this.metroSetLabel9.ThemeAuthor = "Narwin";
            this.metroSetLabel9.ThemeName = "MetroDark";
            // 
            // SchedulerNew
            // 
            this.AllowResize = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BorderThickness = 10F;
            this.ClientSize = new System.Drawing.Size(496, 412);
            this.ControlBox = false;
            this.Controls.Add(this.metroSetLabel9);
            this.Controls.Add(this.metroSetControlBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Bookman Old Style", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderHeight = 10;
            this.Name = "SchedulerNew";
            this.ShowBorder = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Scheduler";
            this.TextColor = System.Drawing.Color.Black;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SchedulerNew_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetButton btnNewJob;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private MetroSet_UI.Controls.MetroSetLabel lblStart;
        private MetroSet_UI.Controls.MetroSetTextBox txtScanPath;
        private MetroSet_UI.Controls.MetroSetButton btnScanPath;
        private MetroSet_UI.Controls.MetroSetLabel lblScanPath;
        private MetroSet_UI.Controls.MetroSetPanel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MetroSet_UI.Controls.MetroSetLabel label1;
        private MetroSet_UI.Controls.MetroSetComboBox cmbRemoveJobs;
        private MetroSet_UI.Controls.MetroSetCheckBox chkRemove;
        private MetroSet_UI.Controls.MetroSetLabel label2;
        private MetroSet_UI.Controls.MetroSetCheckBox Sunday;
        private MetroSet_UI.Controls.MetroSetCheckBox Saturday;
        private MetroSet_UI.Controls.MetroSetCheckBox Friday;
        private MetroSet_UI.Controls.MetroSetCheckBox Thursday;
        private MetroSet_UI.Controls.MetroSetCheckBox Wednesday;
        private MetroSet_UI.Controls.MetroSetCheckBox Tuesday;
        private MetroSet_UI.Controls.MetroSetCheckBox Monday;
        private MetroSet_UI.Controls.MetroSetSwitch chkQuartzJobs;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel2;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel1;
        private MetroSet_UI.Controls.MetroSetControlBox metroSetControlBox1;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel9;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel3;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}