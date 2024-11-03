

namespace eSpark_WindowsFIA
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
                this.FSW_trayicon.Dispose();
                this.notifyIcon1.Dispose();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tootltip1label1 = new System.Windows.Forms.Label();
            this.cmbLogsLevel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSrchFltr = new System.Windows.Forms.Button();
            this.btnScanLoc = new System.Windows.Forms.Button();
            this.btnExcludefile = new System.Windows.Forms.Button();
            this.cmbScanLocations = new System.Windows.Forms.ComboBox();
            this.cmbSrchFileFilter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogsAndDBpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbExcludefileSize = new System.Windows.Forms.ComboBox();
            this.btnLogs = new System.Windows.Forms.Button();
            this.chkHash = new System.Windows.Forms.CheckBox();
            this.btnFilesSearch = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tootltip1label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.FSW_trayMenu.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tootltip1label1);
            this.panel1.Controls.Add(this.cmbLogsLevel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnSrchFltr);
            this.panel1.Controls.Add(this.btnScanLoc);
            this.panel1.Controls.Add(this.btnExcludefile);
            this.panel1.Controls.Add(this.cmbScanLocations);
            this.panel1.Controls.Add(this.cmbSrchFileFilter);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtLogsAndDBpath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbExcludefileSize);
            this.panel1.Controls.Add(this.btnLogs);
            this.panel1.Controls.Add(this.chkHash);
            this.panel1.Controls.Add(this.btnFilesSearch);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 247);
            this.panel1.TabIndex = 0;
            // 
            // tootltip1label1
            // 
            this.tootltip1label1.AutoSize = true;
            this.tootltip1label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tootltip1label1.Location = new System.Drawing.Point(436, 0);
            this.tootltip1label1.Name = "tootltip1label1";
            this.tootltip1label1.Size = new System.Drawing.Size(92, 13);
            this.tootltip1label1.TabIndex = 3;
            this.tootltip1label1.Text = "execution time: 0s";
            // 
            // cmbLogsLevel
            // 
            this.cmbLogsLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogsLevel.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cmbLogsLevel.Items.AddRange(new object[] {
            "None",
            "Errors Only",
            "Errors and Search Results",
            "Full Logs"});
            this.cmbLogsLevel.Location = new System.Drawing.Point(124, 133);
            this.cmbLogsLevel.MaxDropDownItems = 50;
            this.cmbLogsLevel.Name = "cmbLogsLevel";
            this.cmbLogsLevel.Size = new System.Drawing.Size(326, 21);
            this.cmbLogsLevel.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Select Logs level:";
            // 
            // btnSrchFltr
            // 
            this.btnSrchFltr.Location = new System.Drawing.Point(456, 104);
            this.btnSrchFltr.Name = "btnSrchFltr";
            this.btnSrchFltr.Size = new System.Drawing.Size(39, 23);
            this.btnSrchFltr.TabIndex = 8;
            this.btnSrchFltr.Text = "...";
            this.btnSrchFltr.UseVisualStyleBackColor = true;
            this.btnSrchFltr.Click += new System.EventHandler(this.btnSrchFltr_Click);
            // 
            // btnScanLoc
            // 
            this.btnScanLoc.Location = new System.Drawing.Point(456, 77);
            this.btnScanLoc.Name = "btnScanLoc";
            this.btnScanLoc.Size = new System.Drawing.Size(39, 23);
            this.btnScanLoc.TabIndex = 6;
            this.btnScanLoc.Text = "...";
            this.btnScanLoc.UseVisualStyleBackColor = true;
            this.btnScanLoc.Click += new System.EventHandler(this.btnScanLoc_Click);
            // 
            // btnExcludefile
            // 
            this.btnExcludefile.Location = new System.Drawing.Point(456, 50);
            this.btnExcludefile.Name = "btnExcludefile";
            this.btnExcludefile.Size = new System.Drawing.Size(39, 23);
            this.btnExcludefile.TabIndex = 4;
            this.btnExcludefile.Text = "...";
            this.btnExcludefile.UseVisualStyleBackColor = true;
            this.btnExcludefile.Click += new System.EventHandler(this.btnExcludefile_Click);
            // 
            // cmbScanLocations
            // 
            this.cmbScanLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScanLocations.FormattingEnabled = true;
            this.cmbScanLocations.Location = new System.Drawing.Point(124, 79);
            this.cmbScanLocations.MaxDropDownItems = 50;
            this.cmbScanLocations.Name = "cmbScanLocations";
            this.cmbScanLocations.Size = new System.Drawing.Size(326, 21);
            this.cmbScanLocations.TabIndex = 5;
            this.cmbScanLocations.DropDownClosed += new System.EventHandler(this.cmbScanLocations_DropDownClosed);
            // 
            // cmbSrchFileFilter
            // 
            this.cmbSrchFileFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSrchFileFilter.FormattingEnabled = true;
            this.cmbSrchFileFilter.Location = new System.Drawing.Point(124, 106);
            this.cmbSrchFileFilter.MaxDropDownItems = 50;
            this.cmbSrchFileFilter.Name = "cmbSrchFileFilter";
            this.cmbSrchFileFilter.Size = new System.Drawing.Size(326, 21);
            this.cmbSrchFileFilter.TabIndex = 7;
            this.cmbSrchFileFilter.DropDownClosed += new System.EventHandler(this.cmbSrchFileFilter_DropDownClosed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Search file filter:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Logs and DB Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Scan Location:";
            // 
            // txtLogsAndDBpath
            // 
            this.txtLogsAndDBpath.Location = new System.Drawing.Point(124, 26);
            this.txtLogsAndDBpath.Name = "txtLogsAndDBpath";
            this.txtLogsAndDBpath.Size = new System.Drawing.Size(326, 20);
            this.txtLogsAndDBpath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Exclude file with size:";
            // 
            // cmbExcludefileSize
            // 
            this.cmbExcludefileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExcludefileSize.FormattingEnabled = true;
            this.cmbExcludefileSize.Location = new System.Drawing.Point(124, 52);
            this.cmbExcludefileSize.MaxDropDownItems = 50;
            this.cmbExcludefileSize.Name = "cmbExcludefileSize";
            this.cmbExcludefileSize.Size = new System.Drawing.Size(326, 21);
            this.cmbExcludefileSize.TabIndex = 3;
            this.cmbExcludefileSize.DropDownClosed += new System.EventHandler(this.cmbExcludefileSize_DropDownClosed);
            // 
            // btnLogs
            // 
            this.btnLogs.Location = new System.Drawing.Point(456, 26);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(39, 23);
            this.btnLogs.TabIndex = 2;
            this.btnLogs.Text = "...";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // chkHash
            // 
            this.chkHash.AutoSize = true;
            this.chkHash.Location = new System.Drawing.Point(124, 161);
            this.chkHash.Name = "chkHash";
            this.chkHash.Size = new System.Drawing.Size(98, 17);
            this.chkHash.TabIndex = 10;
            this.chkHash.Text = "Calculate Hash";
            this.chkHash.UseVisualStyleBackColor = true;
            // 
            // btnFilesSearch
            // 
            this.btnFilesSearch.Location = new System.Drawing.Point(216, 184);
            this.btnFilesSearch.Name = "btnFilesSearch";
            this.btnFilesSearch.Size = new System.Drawing.Size(120, 52);
            this.btnFilesSearch.TabIndex = 11;
            this.btnFilesSearch.Text = "Search Files";
            this.btnFilesSearch.UseVisualStyleBackColor = true;
            this.btnFilesSearch.Click += new System.EventHandler(this.btnFilesSearch_Click);
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
            this.FSW_trayMenu.Size = new System.Drawing.Size(211, 114);
            // 
            // FSWopen_toolStripMenuItem2
            // 
            this.FSWopen_toolStripMenuItem2.Name = "FSWopen_toolStripMenuItem2";
            this.FSWopen_toolStripMenuItem2.Size = new System.Drawing.Size(210, 22);
            this.FSWopen_toolStripMenuItem2.Text = "Open File System Agent";
            this.FSWopen_toolStripMenuItem2.Click += new System.EventHandler(this.FSWopen_toolStripMenuItem2_Click);
            // 
            // Quartz_toolStripMenuItem
            // 
            this.Quartz_toolStripMenuItem.Name = "Quartz_toolStripMenuItem";
            this.Quartz_toolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.Quartz_toolStripMenuItem.Text = "Open Quartz Scheduler";
            this.Quartz_toolStripMenuItem.Click += new System.EventHandler(this.Quartz_toolStripMenuItem_Click);
            // 
            // TaskScheduler_toolStripMenuItem1
            // 
            this.TaskScheduler_toolStripMenuItem1.Name = "TaskScheduler_toolStripMenuItem1";
            this.TaskScheduler_toolStripMenuItem1.Size = new System.Drawing.Size(210, 22);
            this.TaskScheduler_toolStripMenuItem1.Text = "Open Windows Scheduler";
            this.TaskScheduler_toolStripMenuItem1.Click += new System.EventHandler(this.TaskScheduler_toolStripMenuItem1_Click);
            // 
            // About_toolStripMenuItem1
            // 
            this.About_toolStripMenuItem1.Name = "About_toolStripMenuItem1";
            this.About_toolStripMenuItem1.Size = new System.Drawing.Size(210, 22);
            this.About_toolStripMenuItem1.Text = "About";
            this.About_toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Exit_toolStripMenuItem3
            // 
            this.Exit_toolStripMenuItem3.Name = "Exit_toolStripMenuItem3";
            this.Exit_toolStripMenuItem3.Size = new System.Drawing.Size(210, 22);
            this.Exit_toolStripMenuItem3.Text = "Exit";
            this.Exit_toolStripMenuItem3.Click += new System.EventHandler(this.Exit_toolStripMenuItem3_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(528, 4);
            this.toolStripContainer2.Location = new System.Drawing.Point(12, 265);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(528, 29);
            this.toolStripContainer2.TabIndex = 2;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(530, 27);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(525, 24);
            this.toolStripProgressBar1.Value = 100;
            // 
            // tootltip1label2
            // 
            this.tootltip1label2.AutoSize = true;
            this.tootltip1label2.Location = new System.Drawing.Point(9, 294);
            this.tootltip1label2.Name = "tootltip1label2";
            this.tootltip1label2.Size = new System.Drawing.Size(196, 13);
            this.tootltip1label2.TabIndex = 3;
            this.tootltip1label2.Text = "Press start search files to start scanning!";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnFilesSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 316);
            this.Controls.Add(this.tootltip1label2);
            this.Controls.Add(this.toolStripContainer2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Windows File Indexing Agent - By eSpark";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.FSW_trayMenu.ResumeLayout(false);
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.ContentPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnFilesSearch;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkHash;
        private System.Windows.Forms.NotifyIcon FSW_trayicon;
        private System.Windows.Forms.ContextMenuStrip FSW_trayMenu;
        private System.Windows.Forms.ToolStripMenuItem TaskScheduler_toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem FSWopen_toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem Exit_toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem About_toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Quartz_toolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbScanLocations;
        private System.Windows.Forms.ComboBox cmbSrchFileFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLogsAndDBpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbExcludefileSize;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnSrchFltr;
        private System.Windows.Forms.Button btnScanLoc;
        private System.Windows.Forms.Button btnExcludefile;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox cmbLogsLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label tootltip1label1;
        private System.Windows.Forms.Label tootltip1label2;
        public static System.Windows.Forms.Timer timer1;
        public static System.Windows.Forms.Timer progressbarTimer;
        //public static System.Windows.Forms.Timer timer1;
        //public static System.Windows.Forms.Timer progressbarTimer;
    }

}

