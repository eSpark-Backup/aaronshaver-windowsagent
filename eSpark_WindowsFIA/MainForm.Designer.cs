
namespace eSpark_WindowsFIA
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FileSystemWatcherTimer = new System.Windows.Forms.Timer(this.components);
            this.lblFileSystemWatcher = new MetroSet_UI.Controls.MetroSetLabel();
            this.label7 = new MetroSet_UI.Controls.MetroSetLabel();
            this.label6 = new MetroSet_UI.Controls.MetroSetLabel();
            this.tootltip1label1 = new MetroSet_UI.Controls.MetroSetLabel();
            this.btnSrchFltr = new MetroSet_UI.Controls.MetroSetButton();
            this.btnScanLoc = new MetroSet_UI.Controls.MetroSetButton();
            this.cmbScanLocations = new MetroSet_UI.Controls.MetroSetComboBox();
            this.cmbSrchFileFilter = new MetroSet_UI.Controls.MetroSetComboBox();
            this.label4 = new MetroSet_UI.Controls.MetroSetLabel();
            this.label2 = new MetroSet_UI.Controls.MetroSetLabel();
            this.label1 = new MetroSet_UI.Controls.MetroSetLabel();
            this.btnFilesSearch = new MetroSet_UI.Controls.MetroSetButton();
            timer_callByTaskSched = new System.Windows.Forms.Timer(this.components);
            this.tootltip1label2 = new MetroSet_UI.Controls.MetroSetLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbMaxExcludeFileSize = new MetroSet_UI.Controls.MetroSetComboBox();
            this.cmbMinExcludeFileSize = new MetroSet_UI.Controls.MetroSetComboBox();
            this.panel1 = new MetroSet_UI.Controls.MetroSetPanel();
            this.numMaxExcludeFileSize = new System.Windows.Forms.NumericUpDown();
            this.numMinExcludeFileSize = new System.Windows.Forms.NumericUpDown();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            timer1 = new System.Windows.Forms.Timer(this.components);
            progressbarTimer = new System.Windows.Forms.Timer(this.components);
            this.FSW_trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.FSW_trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FSWopen_toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Quartz_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskScheduler_toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.About_toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStripProgressBar1 = new MetroSet_UI.Controls.MetroSetProgressBar();
            this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
            this.metroSetProgressBar1 = new MetroSet_UI.Controls.MetroSetProgressBar();
            this.metroSetLabel9 = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetLabel1 = new MetroSet_UI.Controls.MetroSetLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxExcludeFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinExcludeFileSize)).BeginInit();
            this.FSW_trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileSystemWatcherTimer
            // 
            this.FileSystemWatcherTimer.Enabled = true;
            this.FileSystemWatcherTimer.Interval = 1000;
            this.FileSystemWatcherTimer.Tick += new System.EventHandler(this.FileSystemWatcherTimer_Tick);
            // 
            // lblFileSystemWatcher
            // 
            this.lblFileSystemWatcher.AutoEllipsis = true;
            this.lblFileSystemWatcher.AutoSize = true;
            this.lblFileSystemWatcher.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileSystemWatcher.IsDerivedStyle = true;
            this.lblFileSystemWatcher.Location = new System.Drawing.Point(3, 0);
            this.lblFileSystemWatcher.MaximumSize = new System.Drawing.Size(449, 35);
            this.lblFileSystemWatcher.MinimumSize = new System.Drawing.Size(449, 25);
            this.lblFileSystemWatcher.Name = "lblFileSystemWatcher";
            this.lblFileSystemWatcher.Size = new System.Drawing.Size(449, 25);
            this.lblFileSystemWatcher.Style = MetroSet_UI.Enums.Style.Light;
            this.lblFileSystemWatcher.StyleManager = null;
            this.lblFileSystemWatcher.TabIndex = 20;
            this.lblFileSystemWatcher.Text = "File System Watcher stopped!....................................................." +
    ".............................";
            this.lblFileSystemWatcher.ThemeAuthor = "Narwin";
            this.lblFileSystemWatcher.ThemeName = "MetroLite";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.IsDerivedStyle = true;
            this.label7.Location = new System.Drawing.Point(333, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.Style = MetroSet_UI.Enums.Style.Light;
            this.label7.StyleManager = null;
            this.label7.TabIndex = 19;
            this.label7.Text = "MAX";
            this.label7.ThemeAuthor = "Narwin";
            this.label7.ThemeName = "MetroLite";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.IsDerivedStyle = true;
            this.label6.Location = new System.Drawing.Point(333, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.Style = MetroSet_UI.Enums.Style.Light;
            this.label6.StyleManager = null;
            this.label6.TabIndex = 18;
            this.label6.Text = "MIN";
            this.label6.ThemeAuthor = "Narwin";
            this.label6.ThemeName = "MetroLite";
            // 
            // tootltip1label1
            // 
            this.tootltip1label1.AutoEllipsis = true;
            this.tootltip1label1.AutoSize = true;
            this.tootltip1label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tootltip1label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tootltip1label1.IsDerivedStyle = true;
            this.tootltip1label1.Location = new System.Drawing.Point(459, 0);
            this.tootltip1label1.MaximumSize = new System.Drawing.Size(211, 25);
            this.tootltip1label1.MinimumSize = new System.Drawing.Size(101, 25);
            this.tootltip1label1.Name = "tootltip1label1";
            this.tootltip1label1.Size = new System.Drawing.Size(143, 25);
            this.tootltip1label1.Style = MetroSet_UI.Enums.Style.Light;
            this.tootltip1label1.StyleManager = null;
            this.tootltip1label1.TabIndex = 3;
            this.tootltip1label1.Text = "execution time: 0s............";
            this.tootltip1label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tootltip1label1.ThemeAuthor = "Narwin";
            this.tootltip1label1.ThemeName = "MetroLite";
            this.tootltip1label1.UseCompatibleTextRendering = true;
            // 
            // btnSrchFltr
            // 
            this.btnSrchFltr.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnSrchFltr.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnSrchFltr.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnSrchFltr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSrchFltr.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnSrchFltr.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnSrchFltr.HoverTextColor = System.Drawing.Color.White;
            this.btnSrchFltr.IsDerivedStyle = true;
            this.btnSrchFltr.Location = new System.Drawing.Point(546, 180);
            this.btnSrchFltr.Name = "btnSrchFltr";
            this.btnSrchFltr.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnSrchFltr.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnSrchFltr.NormalTextColor = System.Drawing.Color.White;
            this.btnSrchFltr.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnSrchFltr.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnSrchFltr.PressTextColor = System.Drawing.Color.White;
            this.btnSrchFltr.Size = new System.Drawing.Size(43, 23);
            this.btnSrchFltr.Style = MetroSet_UI.Enums.Style.Light;
            this.btnSrchFltr.StyleManager = null;
            this.btnSrchFltr.TabIndex = 10;
            this.btnSrchFltr.Text = "...";
            this.btnSrchFltr.ThemeAuthor = "Narwin";
            this.btnSrchFltr.ThemeName = "MetroLite";
            this.btnSrchFltr.Click += new System.EventHandler(this.btnSrchFltr_Click);
            // 
            // btnScanLoc
            // 
            this.btnScanLoc.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnScanLoc.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnScanLoc.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnScanLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnScanLoc.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnScanLoc.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnScanLoc.HoverTextColor = System.Drawing.Color.White;
            this.btnScanLoc.IsDerivedStyle = true;
            this.btnScanLoc.Location = new System.Drawing.Point(546, 140);
            this.btnScanLoc.Name = "btnScanLoc";
            this.btnScanLoc.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnScanLoc.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnScanLoc.NormalTextColor = System.Drawing.Color.White;
            this.btnScanLoc.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnScanLoc.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnScanLoc.PressTextColor = System.Drawing.Color.White;
            this.btnScanLoc.Size = new System.Drawing.Size(43, 23);
            this.btnScanLoc.Style = MetroSet_UI.Enums.Style.Light;
            this.btnScanLoc.StyleManager = null;
            this.btnScanLoc.TabIndex = 8;
            this.btnScanLoc.Text = "...";
            this.btnScanLoc.ThemeAuthor = "Narwin";
            this.btnScanLoc.ThemeName = "MetroLite";
            this.btnScanLoc.Click += new System.EventHandler(this.btnScanLoc_Click);
            // 
            // cmbScanLocations
            // 
            this.cmbScanLocations.AllowDrop = true;
            this.cmbScanLocations.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmbScanLocations.BackColor = System.Drawing.Color.Transparent;
            this.cmbScanLocations.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cmbScanLocations.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmbScanLocations.CausesValidation = false;
            this.cmbScanLocations.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbScanLocations.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cmbScanLocations.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.cmbScanLocations.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbScanLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScanLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbScanLocations.FormattingEnabled = true;
            this.cmbScanLocations.IsDerivedStyle = true;
            this.cmbScanLocations.ItemHeight = 20;
            this.cmbScanLocations.Location = new System.Drawing.Point(158, 137);
            this.cmbScanLocations.MaxDropDownItems = 50;
            this.cmbScanLocations.Name = "cmbScanLocations";
            this.cmbScanLocations.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cmbScanLocations.SelectedItemForeColor = System.Drawing.Color.White;
            this.cmbScanLocations.Size = new System.Drawing.Size(382, 26);
            this.cmbScanLocations.Style = MetroSet_UI.Enums.Style.Light;
            this.cmbScanLocations.StyleManager = null;
            this.cmbScanLocations.TabIndex = 7;
            this.cmbScanLocations.ThemeAuthor = "Narwin";
            this.cmbScanLocations.ThemeName = "MetroLite";
            // 
            // cmbSrchFileFilter
            // 
            this.cmbSrchFileFilter.AllowDrop = true;
            this.cmbSrchFileFilter.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmbSrchFileFilter.BackColor = System.Drawing.Color.Transparent;
            this.cmbSrchFileFilter.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cmbSrchFileFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmbSrchFileFilter.CausesValidation = false;
            this.cmbSrchFileFilter.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbSrchFileFilter.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cmbSrchFileFilter.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.cmbSrchFileFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSrchFileFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSrchFileFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbSrchFileFilter.FormattingEnabled = true;
            this.cmbSrchFileFilter.IsDerivedStyle = true;
            this.cmbSrchFileFilter.ItemHeight = 20;
            this.cmbSrchFileFilter.Location = new System.Drawing.Point(159, 177);
            this.cmbSrchFileFilter.MaxDropDownItems = 50;
            this.cmbSrchFileFilter.Name = "cmbSrchFileFilter";
            this.cmbSrchFileFilter.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cmbSrchFileFilter.SelectedItemForeColor = System.Drawing.Color.White;
            this.cmbSrchFileFilter.Size = new System.Drawing.Size(382, 26);
            this.cmbSrchFileFilter.Style = MetroSet_UI.Enums.Style.Light;
            this.cmbSrchFileFilter.StyleManager = null;
            this.cmbSrchFileFilter.TabIndex = 9;
            this.cmbSrchFileFilter.ThemeAuthor = "Narwin";
            this.cmbSrchFileFilter.ThemeName = "MetroLite";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.IsDerivedStyle = true;
            this.label4.Location = new System.Drawing.Point(12, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.Style = MetroSet_UI.Enums.Style.Light;
            this.label4.StyleManager = null;
            this.label4.TabIndex = 9;
            this.label4.Text = "Search file filter:";
            this.label4.ThemeAuthor = "Narwin";
            this.label4.ThemeName = "MetroLite";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.IsDerivedStyle = true;
            this.label2.Location = new System.Drawing.Point(12, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.Style = MetroSet_UI.Enums.Style.Light;
            this.label2.StyleManager = null;
            this.label2.TabIndex = 7;
            this.label2.Text = "Scan Location:";
            this.label2.ThemeAuthor = "Narwin";
            this.label2.ThemeName = "MetroLite";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.IsDerivedStyle = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.Style = MetroSet_UI.Enums.Style.Light;
            this.label1.StyleManager = null;
            this.label1.TabIndex = 5;
            this.label1.Text = "Exclude File size:";
            this.label1.ThemeAuthor = "Narwin";
            this.label1.ThemeName = "MetroLite";
            // 
            // btnFilesSearch
            // 
            this.btnFilesSearch.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnFilesSearch.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnFilesSearch.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnFilesSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnFilesSearch.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnFilesSearch.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnFilesSearch.HoverTextColor = System.Drawing.Color.White;
            this.btnFilesSearch.IsDerivedStyle = true;
            this.btnFilesSearch.Location = new System.Drawing.Point(248, 253);
            this.btnFilesSearch.Name = "btnFilesSearch";
            this.btnFilesSearch.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnFilesSearch.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnFilesSearch.NormalTextColor = System.Drawing.Color.White;
            this.btnFilesSearch.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnFilesSearch.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnFilesSearch.PressTextColor = System.Drawing.Color.White;
            this.btnFilesSearch.Size = new System.Drawing.Size(132, 52);
            this.btnFilesSearch.Style = MetroSet_UI.Enums.Style.Light;
            this.btnFilesSearch.StyleManager = null;
            this.btnFilesSearch.TabIndex = 13;
            this.btnFilesSearch.Text = "Search Files";
            this.btnFilesSearch.ThemeAuthor = "Narwin";
            this.btnFilesSearch.ThemeName = "MetroLite";
            this.btnFilesSearch.Click += new System.EventHandler(this.btnFilesSearch_Click);
            // 
            // timer_callByTaskSched
            // 
            timer_callByTaskSched.Interval = 5000;
            timer_callByTaskSched.Tick += new System.EventHandler(this.timer_callByTaskSched_Tick);
            // 
            // tootltip1label2
            // 
            this.tootltip1label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tootltip1label2.IsDerivedStyle = false;
            this.tootltip1label2.Location = new System.Drawing.Point(34, 465);
            this.tootltip1label2.MaximumSize = new System.Drawing.Size(583, 50);
            this.tootltip1label2.Name = "tootltip1label2";
            this.tootltip1label2.Size = new System.Drawing.Size(580, 50);
            this.tootltip1label2.Style = MetroSet_UI.Enums.Style.Light;
            this.tootltip1label2.StyleManager = null;
            this.tootltip1label2.TabIndex = 6;
            this.tootltip1label2.Text = "Press start search files to start scanning!......................................" +
    "................................................................................" +
    ".......................";
            this.tootltip1label2.ThemeAuthor = "Narwin";
            this.tootltip1label2.ThemeName = "MetroLite";
            // 
            // cmbMaxExcludeFileSize
            // 
            this.cmbMaxExcludeFileSize.AllowDrop = true;
            this.cmbMaxExcludeFileSize.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmbMaxExcludeFileSize.BackColor = System.Drawing.Color.Transparent;
            this.cmbMaxExcludeFileSize.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cmbMaxExcludeFileSize.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmbMaxExcludeFileSize.CausesValidation = false;
            this.cmbMaxExcludeFileSize.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbMaxExcludeFileSize.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cmbMaxExcludeFileSize.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.cmbMaxExcludeFileSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMaxExcludeFileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaxExcludeFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbMaxExcludeFileSize.FormattingEnabled = true;
            this.cmbMaxExcludeFileSize.IsDerivedStyle = true;
            this.cmbMaxExcludeFileSize.ItemHeight = 20;
            this.cmbMaxExcludeFileSize.Items.AddRange(new object[] {
            "KB",
            "MB",
            "GB"});
            this.cmbMaxExcludeFileSize.Location = new System.Drawing.Point(248, 93);
            this.cmbMaxExcludeFileSize.MaxDropDownItems = 50;
            this.cmbMaxExcludeFileSize.Name = "cmbMaxExcludeFileSize";
            this.cmbMaxExcludeFileSize.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cmbMaxExcludeFileSize.SelectedItemForeColor = System.Drawing.Color.White;
            this.cmbMaxExcludeFileSize.Size = new System.Drawing.Size(79, 26);
            this.cmbMaxExcludeFileSize.Style = MetroSet_UI.Enums.Style.Light;
            this.cmbMaxExcludeFileSize.StyleManager = null;
            this.cmbMaxExcludeFileSize.TabIndex = 6;
            this.cmbMaxExcludeFileSize.ThemeAuthor = "Narwin";
            this.cmbMaxExcludeFileSize.ThemeName = "MetroLite";
            this.toolTip1.SetToolTip(this.cmbMaxExcludeFileSize, "Maximum file size here");
            // 
            // cmbMinExcludeFileSize
            // 
            this.cmbMinExcludeFileSize.AllowDrop = true;
            this.cmbMinExcludeFileSize.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmbMinExcludeFileSize.BackColor = System.Drawing.Color.Transparent;
            this.cmbMinExcludeFileSize.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cmbMinExcludeFileSize.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmbMinExcludeFileSize.CausesValidation = false;
            this.cmbMinExcludeFileSize.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbMinExcludeFileSize.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cmbMinExcludeFileSize.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.cmbMinExcludeFileSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMinExcludeFileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMinExcludeFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbMinExcludeFileSize.FormattingEnabled = true;
            this.cmbMinExcludeFileSize.IsDerivedStyle = true;
            this.cmbMinExcludeFileSize.ItemHeight = 20;
            this.cmbMinExcludeFileSize.Items.AddRange(new object[] {
            "KB",
            "MB",
            "GB"});
            this.cmbMinExcludeFileSize.Location = new System.Drawing.Point(248, 53);
            this.cmbMinExcludeFileSize.MaxDropDownItems = 50;
            this.cmbMinExcludeFileSize.Name = "cmbMinExcludeFileSize";
            this.cmbMinExcludeFileSize.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cmbMinExcludeFileSize.SelectedItemForeColor = System.Drawing.Color.White;
            this.cmbMinExcludeFileSize.Size = new System.Drawing.Size(79, 26);
            this.cmbMinExcludeFileSize.Style = MetroSet_UI.Enums.Style.Light;
            this.cmbMinExcludeFileSize.StyleManager = null;
            this.cmbMinExcludeFileSize.TabIndex = 4;
            this.cmbMinExcludeFileSize.ThemeAuthor = "Narwin";
            this.cmbMinExcludeFileSize.ThemeName = "MetroLite";
            this.toolTip1.SetToolTip(this.cmbMinExcludeFileSize, "Minimum file size here");
            // 
            // panel1
            // 
            this.panel1.BackgroundColor = System.Drawing.Color.White;
            this.panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.panel1.BorderThickness = 1;
            this.panel1.Controls.Add(this.metroSetLabel1);
            this.panel1.Controls.Add(this.numMaxExcludeFileSize);
            this.panel1.Controls.Add(this.numMinExcludeFileSize);
            this.panel1.Controls.Add(this.lblFileSystemWatcher);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbMaxExcludeFileSize);
            this.panel1.Controls.Add(this.cmbMinExcludeFileSize);
            this.panel1.Controls.Add(this.tootltip1label1);
            this.panel1.Controls.Add(this.btnSrchFltr);
            this.panel1.Controls.Add(this.btnScanLoc);
            this.panel1.Controls.Add(this.cmbScanLocations);
            this.panel1.Controls.Add(this.cmbSrchFileFilter);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnFilesSearch);
            this.panel1.IsDerivedStyle = true;
            this.panel1.Location = new System.Drawing.Point(28, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 331);
            this.panel1.Style = MetroSet_UI.Enums.Style.Light;
            this.panel1.StyleManager = null;
            this.panel1.TabIndex = 4;
            this.panel1.ThemeAuthor = "Narwin";
            this.panel1.ThemeName = "MetroLite";
            // 
            // numMaxExcludeFileSize
            // 
            this.numMaxExcludeFileSize.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMaxExcludeFileSize.Location = new System.Drawing.Point(158, 92);
            this.numMaxExcludeFileSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numMaxExcludeFileSize.Name = "numMaxExcludeFileSize";
            this.numMaxExcludeFileSize.Size = new System.Drawing.Size(84, 29);
            this.numMaxExcludeFileSize.TabIndex = 5;
            this.numMaxExcludeFileSize.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // numMinExcludeFileSize
            // 
            this.numMinExcludeFileSize.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.numMinExcludeFileSize.Location = new System.Drawing.Point(158, 53);
            this.numMinExcludeFileSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numMinExcludeFileSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numMinExcludeFileSize.Name = "numMinExcludeFileSize";
            this.numMinExcludeFileSize.Size = new System.Drawing.Size(84, 29);
            this.numMinExcludeFileSize.TabIndex = 3;
            this.numMinExcludeFileSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            timer1.Interval = 500;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressbarTimer
            // 
            progressbarTimer.Interval = 50;
            progressbarTimer.Tick += new System.EventHandler(this.progressbarTimer_Tick);
            // 
            // FSW_trayicon
            // 
            this.FSW_trayicon.BalloonTipText = "This is eSPark FSW";
            this.FSW_trayicon.BalloonTipTitle = "This is eSPark FSW";
            this.FSW_trayicon.ContextMenuStrip = this.FSW_trayMenu;
            this.FSW_trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("FSW_trayicon.Icon")));
            this.FSW_trayicon.Text = "eSpark FSW";
            this.FSW_trayicon.Visible = true;
            // 
            // FSW_trayMenu
            // 
            this.FSW_trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FSWopen_toolStripMenuItem2,
            this.Quartz_toolStripMenuItem,
            this.TaskScheduler_toolStripMenuItem1,
            this.About_toolStripMenuItem1,
            this.Exit_toolStripMenuItem3});
            this.FSW_trayMenu.Name = "contextMenuStrip1";
            this.FSW_trayMenu.Size = new System.Drawing.Size(233, 114);
            // 
            // FSWopen_toolStripMenuItem2
            // 
            this.FSWopen_toolStripMenuItem2.Name = "FSWopen_toolStripMenuItem2";
            this.FSWopen_toolStripMenuItem2.Size = new System.Drawing.Size(232, 22);
            this.FSWopen_toolStripMenuItem2.Text = "Open File System Agent";
            this.FSWopen_toolStripMenuItem2.Click += new System.EventHandler(this.FSWopen_toolStripMenuItem2_Click);
            // 
            // Quartz_toolStripMenuItem
            // 
            this.Quartz_toolStripMenuItem.Name = "Quartz_toolStripMenuItem";
            this.Quartz_toolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.Quartz_toolStripMenuItem.Text = "Open FileSystem Scheduler";
            this.Quartz_toolStripMenuItem.Click += new System.EventHandler(this.Quartz_toolStripMenuItem_Click);
            // 
            // TaskScheduler_toolStripMenuItem1
            // 
            this.TaskScheduler_toolStripMenuItem1.Name = "TaskScheduler_toolStripMenuItem1";
            this.TaskScheduler_toolStripMenuItem1.Size = new System.Drawing.Size(232, 22);
            this.TaskScheduler_toolStripMenuItem1.Text = "Open WindowsTask Scheduler";
            this.TaskScheduler_toolStripMenuItem1.Click += new System.EventHandler(this.TaskScheduler_toolStripMenuItem1_Click);
            // 
            // About_toolStripMenuItem1
            // 
            this.About_toolStripMenuItem1.Name = "About_toolStripMenuItem1";
            this.About_toolStripMenuItem1.Size = new System.Drawing.Size(232, 22);
            this.About_toolStripMenuItem1.Text = "About";
            this.About_toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Exit_toolStripMenuItem3
            // 
            this.Exit_toolStripMenuItem3.Name = "Exit_toolStripMenuItem3";
            this.Exit_toolStripMenuItem3.Size = new System.Drawing.Size(232, 22);
            this.Exit_toolStripMenuItem3.Text = "Exit";
            this.Exit_toolStripMenuItem3.Click += new System.EventHandler(this.Exit_toolStripMenuItem3_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.toolStripProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.toolStripProgressBar1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.toolStripProgressBar1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.toolStripProgressBar1.DisabledProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.toolStripProgressBar1.IsDerivedStyle = false;
            this.toolStripProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.toolStripProgressBar1.Maximum = 100;
            this.toolStripProgressBar1.Minimum = 0;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Orientation = MetroSet_UI.Enums.ProgressOrientation.Horizontal;
            this.toolStripProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.toolStripProgressBar1.Size = new System.Drawing.Size(525, 24);
            this.toolStripProgressBar1.Style = MetroSet_UI.Enums.Style.Light;
            this.toolStripProgressBar1.StyleManager = null;
            this.toolStripProgressBar1.TabIndex = 0;
            this.toolStripProgressBar1.ThemeAuthor = "Narwin";
            this.toolStripProgressBar1.ThemeName = "MetroLite";
            this.toolStripProgressBar1.Value = 100;
            // 
            // metroSetControlBox1
            // 
            this.metroSetControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.DimGray;
            this.metroSetControlBox1.IsDerivedStyle = true;
            this.metroSetControlBox1.Location = new System.Drawing.Point(530, 14);
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
            this.metroSetControlBox1.TabIndex = 7;
            this.metroSetControlBox1.ThemeAuthor = "Narwin";
            this.metroSetControlBox1.ThemeName = "MetroLite";
            this.metroSetControlBox1.Click += new System.EventHandler(this.Form1_FormClosing);
            // 
            // metroSetProgressBar1
            // 
            this.metroSetProgressBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetProgressBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroSetProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetProgressBar1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetProgressBar1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetProgressBar1.DisabledProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.metroSetProgressBar1.IsDerivedStyle = true;
            this.metroSetProgressBar1.Location = new System.Drawing.Point(28, 437);
            this.metroSetProgressBar1.Maximum = 100;
            this.metroSetProgressBar1.Minimum = 0;
            this.metroSetProgressBar1.Name = "metroSetProgressBar1";
            this.metroSetProgressBar1.Orientation = MetroSet_UI.Enums.ProgressOrientation.Horizontal;
            this.metroSetProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetProgressBar1.Size = new System.Drawing.Size(602, 23);
            this.metroSetProgressBar1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetProgressBar1.StyleManager = null;
            this.metroSetProgressBar1.TabIndex = 8;
            this.metroSetProgressBar1.Text = "100%";
            this.metroSetProgressBar1.ThemeAuthor = "Narwin";
            this.metroSetProgressBar1.ThemeName = "MetroLite";
            this.metroSetProgressBar1.Value = 0;
            // 
            // metroSetLabel9
            // 
            this.metroSetLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroSetLabel9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.metroSetLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroSetLabel9.IsDerivedStyle = true;
            this.metroSetLabel9.Location = new System.Drawing.Point(27, 70);
            this.metroSetLabel9.Name = "metroSetLabel9";
            this.metroSetLabel9.Size = new System.Drawing.Size(471, 27);
            this.metroSetLabel9.Style = MetroSet_UI.Enums.Style.Dark;
            this.metroSetLabel9.StyleManager = null;
            this.metroSetLabel9.TabIndex = 33;
            this.metroSetLabel9.Text = "File System Agents plays a pivotal role in modern data stategies";
            this.metroSetLabel9.ThemeAuthor = "Narwin";
            this.metroSetLabel9.ThemeName = "MetroDark";
            // 
            // metroSetLabel1
            // 
            this.metroSetLabel1.AutoSize = true;
            this.metroSetLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetLabel1.IsDerivedStyle = true;
            this.metroSetLabel1.Location = new System.Drawing.Point(12, 104);
            this.metroSetLabel1.Name = "metroSetLabel1";
            this.metroSetLabel1.Size = new System.Drawing.Size(116, 17);
            this.metroSetLabel1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel1.StyleManager = null;
            this.metroSetLabel1.TabIndex = 21;
            this.metroSetLabel1.Text = "Exclude File size:";
            this.metroSetLabel1.ThemeAuthor = "Narwin";
            this.metroSetLabel1.ThemeName = "MetroLite";
            // 
            // MainForm
            // 
            this.AllowResize = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BorderThickness = 10F;
            this.ClientSize = new System.Drawing.Size(644, 527);
            this.ControlBox = false;
            this.Controls.Add(this.metroSetLabel9);
            this.Controls.Add(this.metroSetProgressBar1);
            this.Controls.Add(this.metroSetControlBox1);
            this.Controls.Add(this.tootltip1label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Bookman Old Style", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderHeight = 10;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(12, 90, 12, 12);
            this.ShowBorder = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File System Scanner";
            this.TextColor = System.Drawing.Color.Black;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Form1_HelpButtonClicked);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxExcludeFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinExcludeFileSize)).EndInit();
            this.FSW_trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer FileSystemWatcherTimer;
        private MetroSet_UI.Controls.MetroSetButton btnSrchFltr;
        private MetroSet_UI.Controls.MetroSetButton btnScanLoc;
        private MetroSet_UI.Controls.MetroSetButton btnFilesSearch;        
        private System.Windows.Forms.ToolTip toolTip1;
        private MetroSet_UI.Controls.MetroSetPanel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NotifyIcon FSW_trayicon;
        private System.Windows.Forms.ContextMenuStrip FSW_trayMenu;
        private System.Windows.Forms.ToolStripMenuItem FSWopen_toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem Quartz_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TaskScheduler_toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem About_toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Exit_toolStripMenuItem3;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private MetroSet_UI.Controls.MetroSetProgressBar toolStripProgressBar1;
        private MetroSet_UI.Controls.MetroSetLabel lblFileSystemWatcher;
        private MetroSet_UI.Controls.MetroSetLabel label7;
        private MetroSet_UI.Controls.MetroSetLabel label6;
        private MetroSet_UI.Controls.MetroSetLabel tootltip1label1;
        private MetroSet_UI.Controls.MetroSetComboBox cmbScanLocations;
        private MetroSet_UI.Controls.MetroSetComboBox cmbSrchFileFilter;
        private MetroSet_UI.Controls.MetroSetLabel label4;
        private MetroSet_UI.Controls.MetroSetLabel label2;
        private MetroSet_UI.Controls.MetroSetLabel label1;
        private MetroSet_UI.Controls.MetroSetLabel tootltip1label2;
        private MetroSet_UI.Controls.MetroSetComboBox cmbMaxExcludeFileSize;
        private MetroSet_UI.Controls.MetroSetComboBox cmbMinExcludeFileSize;
        private MetroSet_UI.Controls.MetroSetControlBox metroSetControlBox1;
        private MetroSet_UI.Controls.MetroSetProgressBar metroSetProgressBar1;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel9;
        private System.Windows.Forms.NumericUpDown numMaxExcludeFileSize;
        private System.Windows.Forms.NumericUpDown numMinExcludeFileSize;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel1;
        public static System.Windows.Forms.Timer timer1;
        public static System.Windows.Forms.Timer progressbarTimer;
        public static System.Windows.Forms.Timer timer_callByTaskSched;
    }
}