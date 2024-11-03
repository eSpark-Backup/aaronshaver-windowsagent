using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;
using Crc32C;
using System.Buffers;
using System.Reflection;
using NLog;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace eSpark_WindowsFIA
{
    public partial class Form1 : Form
    {
        //public static String collectedText = "";
        //public static StringBuilder sb_collectedText = new StringBuilder();
        public static bool processCompleted = false;
        public static bool calculateHash = false;
        public static int progressCounter = 0;
        public static int LogsLevel = 0;
        //public static DateTime StartTime = DateTime.UtcNow;
        //public static DateTime StopTime = DateTime.UtcNow;
        public static Stopwatch stopwatch = new Stopwatch();
        public static String SelectedFldr = "";
        public static String UserControlLabel = "";
        public static String logfilePath = "";
        public static NLog.Logger loger;
        private QuartzScheduler quartzScheduler = new QuartzScheduler();
        private static Form thisForm;
        public static double MaxSize = double.MaxValue;
        public static double MinSize = 0;
        private static int comboLastSelectedIndex = -1;

        private bool userExit = false;
        private static String filefiltr = "";
        private static String currentfilescan = "";


        private NLog.Config.LoggingConfiguration config = new NLog.Config.LoggingConfiguration();

        public Form1(String[] Runit)
        {
            InitializeComponent();
            
            try { this.txtLogsAndDBpath.Text = GetSetting("LogsDBPath"); } catch { }
            try { this.cmbExcludefileSize.Items.AddRange(GetSetting("ExcludeFileSize").Split('~')); } catch { }
            try { this.cmbScanLocations.Items.AddRange(GetSetting("ScanLocations").Split('~')); } catch { }
            try { this.cmbSrchFileFilter.Items.AddRange(GetSetting("ExcludeFilterList").Split('~')); } catch { }

            if (this.txtLogsAndDBpath.Text.Length > 1)
            {
                if (!File.Exists(AssemblyDirectory + "\\eSpark_FIA.sqlite"))
                {
                    MessageBox.Show("Source database location not found!", "Source file not found", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }
                try { File.Copy(AssemblyDirectory + "\\eSpark_FIA.sqlite", (this.txtLogsAndDBpath.Text + "\\eSpark_FIA.sqlite").Replace("\\\\", "\\"), false); } catch { }
            }

            UpdateLogdbEntry();            

             FSW_trayicon.Visible = true;

            loger.Log(LogLevel.Info, "==================Starting Windows File Logger==============="+DateTime.UtcNow);

            //resheduled Jobs from database
            QuartzScheduler.autoLoadJobsStartUp();


            if (Runit.Length > 0)
                if (Runit[0].Contains("/r"))
                    btnFilesSearch_Click(this, null);

        }

        public static Dictionary<string, string> XmlToDictionary(string key, string value, XElement baseElm)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (XElement elm in baseElm.Elements())
            {
                string dictKey = elm.Attribute(key).Value;
                string dictVal = elm.Attribute(value).Value;

                dict.Add(dictKey, dictVal);
            }
            return dict;
        }

        public static XElement DictToXml(Dictionary<string, string> inputDict, string elmName, string valuesName)
        {

            XElement outElm = new XElement(elmName);
            Dictionary<string, string>.KeyCollection keys = inputDict.Keys;
            XElement inner = new XElement(valuesName);

            foreach (string key in keys)
            {
                inner.Add(new XAttribute("key", key));
                inner.Add(new XAttribute("value", inputDict[key]));
            }

            outElm.Add(inner);
            return outElm;
        }

        private void UpdateLogdbEntry()
        {
            try
            {//Logs level
             //0=None
             //1=Errors Only
             //Errors and Search Results
             //Full Logs

                LogsLevel = int.Parse(GetSetting("LogsLevel"));
                this.cmbLogsLevel.SelectedIndex = LogsLevel;
            }
            catch { }


            if (this.txtLogsAndDBpath.Text.Length > 1)
                logfilePath = this.txtLogsAndDBpath.Text;


            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile")
            {
                FileName = (logfilePath + "\\logfile.txt").Replace("\\\\", "\\"),
                ArchiveFileName = "logfile.{#}.txt",
                ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Date,
                ArchiveEvery = NLog.Targets.FileArchivePeriod.Day,
                ArchiveDateFormat = "yyyyMMdd"
            };

            // Rules for mapping loggers to targets            
            //config.AddRule(LogLevel.Info, LogLevel.Info, logfile);
            //config.AddRule(LogLevel.Debug, LogLevel.Debug, logfile);            
            if (LogsLevel == 0) config.AddRule(LogLevel.Info, LogLevel.Info, logfile);
            else if (LogsLevel == 1) config.AddRule(LogLevel.Error, LogLevel.Fatal, logfile);
            else if (LogsLevel == 2) config.AddRule(LogLevel.Trace, LogLevel.Info, logfile);
            else if (LogsLevel == 3) config.AddRule(LogLevel.Trace, LogLevel.Fatal, logfile);

            config.Reload();

            // Apply config           
            NLog.LogManager.Configuration = config;
            loger = NLog.LogManager.GetCurrentClassLogger();


        }

        private void btnFilesSearch_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            //DialogResult result = folderDlg.ShowDialog();
            progressCounter = 0;
            toolStripProgressBar1.Value = progressCounter;
            //StartTime = DateTime.Now;
            //StopTime = DateTime.Now;
            SelectedFldr = "";
            calculateHash = false;

            //using (var fbd = new FolderBrowserDialog())
            //{
            //    var result = fbd.ShowDialog();

            //    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            //    {

            if (this.txtLogsAndDBpath.Text.Length < 1)
            {
                MessageBox.Show("Please enter Logs and database location!", "Logs file location not found?", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            else {
                if (!File.Exists(AssemblyDirectory + "\\eSpark_FIA.sqlite"))
                {
                    MessageBox.Show("Source database location not found!", "Source file not found", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }
                UpdateLogdbEntry();
            }

            if (this.cmbScanLocations.Items != null && this.cmbScanLocations.Items.Count > 0)
            {
                for (int i = 0; i < this.cmbScanLocations.Items.Count; i++)
                {
                    if (this.txtLogsAndDBpath.Text.Length > 0 && this.cmbScanLocations.Items[i].ToString().Contains(this.txtLogsAndDBpath.Text))
                    {
                        MessageBox.Show("Logs and DB folder can not be same in search location!", "Please change logs-db folder location!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Directory.Exists(this.cmbScanLocations.Items[i].ToString()))
                        SelectedFldr += this.cmbScanLocations.Items[i].ToString().Trim() + ";";
                }
                if (SelectedFldr.Length > 0)
                    SelectedFldr = SelectedFldr.Substring(0, SelectedFldr.Length - 1);
            }
            else
            {
                MessageBox.Show("Please enter some search locations.", "No locations entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.cmbLogsLevel.SelectedIndex > -1 && LogsLevel != this.cmbLogsLevel.SelectedIndex)
            {
                LogsLevel = this.cmbLogsLevel.SelectedIndex;
                SetSetting("LogsLevel", "" + LogsLevel);

                // Targets where to log to: File and Console
                var logfile = new NLog.Targets.FileTarget("logfile")
                {
                    FileName = "logfile.txt",
                    ArchiveFileName = "logfile.{#}.txt",
                    ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Date,
                    ArchiveEvery = NLog.Targets.FileArchivePeriod.Day,
                    ArchiveDateFormat = "yyyyMMdd"
                };

                // Rules for mapping loggers to targets            
                //config.AddRule(LogLevel.Info, LogLevel.Info, logfile);
                //config.AddRule(LogLevel.Debug, LogLevel.Debug, logfile);
                config = new NLog.Config.LoggingConfiguration();
                if (LogsLevel > 0) config.AddRule(LogLevel.Error, LogLevel.Fatal, logfile);
                if (LogsLevel > 1) config.AddRule(LogLevel.Trace, LogLevel.Trace, logfile);
                config.Reload();

                // Apply config           
                NLog.LogManager.Configuration = config;
                loger = NLog.LogManager.GetCurrentClassLogger();
            }


            if (this.cmbExcludefileSize.Items != null && this.cmbExcludefileSize.Items.Count > 0)
            {
                for (int i = 0; i < this.cmbExcludefileSize.Items.Count; i++)
                {
                    try
                    {
                        if (this.cmbExcludefileSize.Items[i].ToString().Trim().Contains(">"))//Greater value
                            if (this.cmbExcludefileSize.Items[i].ToString().Contains("KB"))//Greater value
                            {
                                MaxSize = double.Parse(Regex.Match(this.cmbExcludefileSize.Items[i].ToString().Trim(), @"\d+").Value);
                                MaxSize = MaxSize;
                            }
                            else if (this.cmbExcludefileSize.Items[i].ToString().Trim().Contains("MB"))//Greater value
                            {
                                MaxSize = double.Parse(Regex.Match(this.cmbExcludefileSize.Items[i].ToString().Trim(), @"\d+").Value);
                                MaxSize = MaxSize * 1024;
                            }
                            else if (this.cmbExcludefileSize.Items[i].ToString().Trim().Contains("GB"))//Greater value
                            {
                                MaxSize = double.Parse(Regex.Match(this.cmbExcludefileSize.Items[i].ToString().Trim(), @"\d+").Value);
                                MaxSize = MaxSize * 1024 * 1024;
                            }
                    }
                    catch { }

                    try
                    {
                        if (this.cmbExcludefileSize.Items[i].ToString().Trim().Contains("<"))//Greater value
                            if (this.cmbExcludefileSize.Items[i].ToString().Contains("KB"))//Greater value
                            {
                                MinSize = double.Parse(Regex.Match(this.cmbExcludefileSize.Items[i].ToString().Trim(), @"\d+").Value);
                                MinSize = MinSize;
                            }
                            else if (this.cmbExcludefileSize.Items[i].ToString().Trim().Contains("MB"))//Greater value
                            {
                                MinSize = double.Parse(Regex.Match(this.cmbExcludefileSize.Items[i].ToString().Trim(), @"\d+").Value);
                                MinSize = MinSize * 1024;
                            }
                            else if (this.cmbExcludefileSize.Items[i].ToString().Trim().Contains("GB"))//Greater value
                            {
                                MinSize = double.Parse(Regex.Match(this.cmbExcludefileSize.Items[i].ToString().Trim(), @"\d+").Value);
                                MinSize = MinSize * 1024 * 1024;
                            }
                    }
                    catch { }
                }
                //if (SelectedFldr.Length > 0)
                //    SelectedFldr = SelectedFldr.Substring(0, SelectedFldr.Length - 1);
            }

            if (this.cmbSrchFileFilter.Items != null && this.cmbSrchFileFilter.Items.Count > 0)
            {
                bool isValid = true;
                String rePattern = "";
                for (int i = 0; i < this.cmbSrchFileFilter.Items.Count; i++)
                {
                    try
                    {
                        //"!*\bin\*;!*\obj\*;!*\.*~;!*\Windows\*;!*\Program Files\*;!*\Program Files (x86)\*;!*\Users\*"
                        String updatedregexp = this.cmbSrchFileFilter.Items[i].ToString();
                        updatedregexp = Regex.Replace(updatedregexp, @"\s+", @"\s*");
                        updatedregexp = Regex.Replace(updatedregexp, @"\;", @"|");
                        updatedregexp = Regex.Replace(updatedregexp, @"\\", @"\\\\");

                        if (updatedregexp.Substring(updatedregexp.Length - 3).Contains('|'))
                            updatedregexp = updatedregexp.Remove(updatedregexp.Length - 1);

                        try { Regex.Match("", updatedregexp); }
                        catch (ArgumentException) { loger.Log(LogLevel.Trace, "===================FileFilter Bad Expression =================== " + this.cmbSrchFileFilter.Items[i].ToString().Trim());
                            isValid = false; }

                        rePattern += updatedregexp.Trim() + "|";
                    }
                    catch { }
                }
                if (!isValid)
                {
                    MessageBox.Show("Search file filter has some invalid values.", "Invalid file filter values!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (rePattern.Substring(rePattern.Length - 3).Contains('|'))
                    rePattern = rePattern.Remove(rePattern.Length - 1);

                filefiltr = rePattern;
            }

            //this.txtLogsAndDBpath.Text

            loger.Log(LogLevel.Trace, "===================Starting Scan =================== \r\n " + SelectedFldr);
            if (this.chkHash.Checked)
                calculateHash = true;

            CallFileSystemWatcherAsync();
            CallBrowseProcessAsync();
            timer1.Start();
            progressbarTimer.Start();
            this.btnFilesSearch.Enabled = false;
        }

        public static void CalledByScheduler(String path)
        {
            progressCounter = 0;
            SelectedFldr = "";
            calculateHash = false;


            if (!string.IsNullOrWhiteSpace(path))
            {
                SelectedFldr = path;
                loger.Log(LogLevel.Trace, "===================Starting Scheduler Scan =================== \r\n " + SelectedFldr);

                CallFileSystemWatcherAsync();
                CallBrowseProcessAsync();
                timer1.Start();
                progressbarTimer.Start();
            }

        }

        public static async void CallFileSystemWatcherAsync()
        {
            //Form1.SelectedFldr
            foreach (string subfldr in Form1.SelectedFldr.Split(';'))
            {
                WindowsFIA_FSW callFIA_FSW = new WindowsFIA_FSW();
                await Task.Run(() => callFIA_FSW.Initiate(subfldr));
                break;//can not run multiple watchers
            }
        }

        public static async void CallBrowseProcessAsync()
        {
            //var folder = await Task.Run(() => ShowFolderBrowserDialogAsync());
                await Task.Run(() => ShowFolderBrowserDialogAsync());
            //var folder = await ShowFolderBrowserDialogAsync();
            //if (!string.IsNullOrWhiteSpace(folder))
            //{
            //    collectedText += folder+"\r\n";
            //}            
        }

        public static Task<string> ShowFolderBrowserDialogAsync()
        {
            if (processCompleted)
            {
                loger.Log(LogLevel.Trace, "===================Summary=================== \r\n Process is already running!!! ");
                return Task.FromResult("Process is already running");
            }


            ControllerDB controllerDB = new ControllerDB();
            processCompleted = false;
            int counter = 1;
            String rootDir = "";
            String[] SelectedFldr_single = SelectedFldr.Split(';');

            int TotalFiles = 0;
            foreach (String fldr in SelectedFldr_single)
            {
                TotalFiles += Directory.GetFiles(fldr, "*", SearchOption.AllDirectories).Length;                
            }
            loger.Log(LogLevel.Trace, "===================TotalFilesToScan=================== "+TotalFiles.ToString());


            foreach (String fldr in SelectedFldr_single)
            {
                if(Regex.IsMatch(fldr, filefiltr))
                {
                    loger.Log(LogLevel.Trace, "===================Exculding folder =================== " + fldr);
                    continue;
                }

                string[] files = Directory.GetFiles(fldr, "*", SearchOption.AllDirectories);
                if (files.Count() > 0)
                {
                    stopwatch.Reset();
                    stopwatch.Start();


                    loger.Log(LogLevel.Trace, "0 > FileName  : CreationTime + : LastWriteTime : LastAccessTime : fileLengthKB : 0xGetHashCode() ");
                    String fileSizeUnit = "Bytes";
                    int dirID = 0;
                    controllerDB.InitializeFlexMoldDB();
                    rootDir = "";
                    controllerDB.DeleteData("ScannedFileLogs", " DirectoryID in (Select Distinct DirectoryID as DirectoryID from ScannedDirectoryLogs where DirectoryPath like '" + SelectedFldr_single + "%') ");
                    controllerDB.DeleteData("ScannedDirectoryLogs", " DirectoryPath like '" + SelectedFldr_single + "%'");

                    List<Dictionary<string, string>> FileList = new List<Dictionary<string, string>>();

                    foreach (string s in files)
                    {
                        try
                        {
                            FileInfo file = new FileInfo(s);
                            currentfilescan = file.FullName;
                            if (Regex.IsMatch(file.FullName, filefiltr.Replace("\\\\", "\\"))) //filefiltr.IsMatch(fldr))
                            {
                                loger.Log(LogLevel.Trace, "===================Exculding folder =================== " + file.FullName);
                                decimal dd2 = (counter * 1.00M) / TotalFiles;
                                progressCounter = (int)Math.Ceiling(dd2 * 100.00M);
                                counter++;
                                continue;
                            }


                            double fileLengthKB = Math.Ceiling(file.Length / 1024D);

                            if (file.Length < 1024)
                            {
                                fileLengthKB = file.Length;
                                fileSizeUnit = "Bytes";
                            }
                            else if (fileLengthKB < 1024)
                                fileSizeUnit = "KB";

                            if (fileLengthKB > 1024)
                            {
                                fileLengthKB = Math.Ceiling(fileLengthKB / 1024D);
                                fileSizeUnit = "MB";
                            }
                            if (fileLengthKB > 1024)
                            {
                                fileLengthKB = Math.Ceiling(fileLengthKB / 1024D);
                                fileSizeUnit = "GB";
                            }

                            if (fileLengthKB > MaxSize || fileLengthKB < MinSize)
                            {
                                loger.Log(LogLevel.Trace, "===================File Max/Min Size exceed =================== " + file.FullName);
                                decimal dd1 = (counter * 1.00M) / TotalFiles;
                                progressCounter = (int)Math.Ceiling(dd1 * 100.00M);
                                counter++;
                                continue;
                            }

                            loger.Log(LogLevel.Trace, counter + " > " + file.Name + " : " + file.CreationTime + " : " + file.LastWriteTime + " : " + file.LastAccessTime + " : " + fileLengthKB.ToString() + fileSizeUnit + " : 0x" + file.GetHashCode().ToString() + " : FileType" + file.Directory);

                            if (file.Directory.FullName != rootDir)
                            {
                                Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                                dirID = file.FullName.GetHashCode();
                                DirectoryInf.Add("DirectoryID", (dirID).ToString());
                                DirectoryInf.Add("DirectoryPath", file.Directory.FullName);
                                DirectoryInf.Add("ScannedDate", DateTime.UtcNow.ToString());

                                rootDir = file.Directory.FullName;

                                controllerDB.InsertOnlyData("ScannedDirectoryLogs", " DirectoryPath='" + rootDir + "' ", DirectoryInf);

                            }

                            Dictionary<String, String> fileInf = new Dictionary<string, string>();
                            fileInf.Add("DirectoryID", dirID.ToString());
                            fileInf.Add("FileName", file.Name);
                            fileInf.Add("CreationDate", file.CreationTime.ToString());
                            fileInf.Add("ModifiedDate", file.LastWriteTime.ToString());
                            fileInf.Add("AccessedDate", file.LastAccessTime.ToString());
                            fileInf.Add("ScannedDate", DateTime.UtcNow.ToString());
                            fileInf.Add("FileSize", (fileLengthKB.ToString() + "" + fileSizeUnit).ToString());

                            try
                            {
                                if (calculateHash)
                                {
                                    fileInf.Add("FileHash", Compute256Hash(file.FullName));
                                }
                                else fileInf.Add("FileHash", "0000000");


                            }
                            catch (Exception ex)
                            { fileInf.Add("FileHash", "0000000"); }



                            FileList.Add(fileInf);

                            if (FileList.Count() > 102400)//files records count almost in 100MBs???
                            {
                                foreach (Dictionary<string, string> fileRecord in FileList)
                                    controllerDB.InsertOnlyData("ScannedFileLogs", "", fileRecord);

                                FileList.Clear();

                            }

                            decimal dd = (counter * 1.00M) / TotalFiles;
                            progressCounter = (int)Math.Ceiling(dd * 100.00M);
                            counter++;
                        }
                        catch (UnauthorizedAccessException e)
                        {
                            loger.Log(LogLevel.Trace, "=================== UnauthorizedAccessException =================== " + e.Message);
                        }
                        catch (Exception ex)
                        {
                            loger.Log(LogLevel.Trace, "=================== FolderScanning Exception =================== " + ex.Message);
                        }
                    }

                    //StopTime = DateTime.UtcNow;
                    //stopwatch.Stop();

                    foreach (Dictionary<string, string> fileRecord in FileList)
                        controllerDB.InsertOnlyData("ScannedFileLogs", "", fileRecord);
                    
                    loger.Log(LogLevel.Trace, "===================Summary=================== \r\n Folder scanned=" + fldr);
                    loger.Log(LogLevel.Trace, "===================Summary=================== \r\n Total Files Scanned=" + counter);
                    loger.Log(LogLevel.Trace, "===================Summary=================== \r\n TotalTime=" + stopwatch.Elapsed);

                }
                Thread.Sleep(50);// to flush all the messages from collectedText 
                //processCompleted = true;
                //return Task.FromResult(SelectedFldr);
            }
            //}



            loger.Log(LogLevel.Trace, "===================Summary=================== \r\n Total Files Scanned= (0) Files" );
            loger.Log(LogLevel.Trace, "===================Summary=================== \r\n TotalTime=" + stopwatch.Elapsed );

            
            processCompleted = true;
            return Task.FromResult(SelectedFldr);
            //return Task.FromResult(ShowFolderBrowserDialog());
        }

        static readonly SHA256CryptoServiceProvider _hashAlgorithm2 = new SHA256CryptoServiceProvider();
        public static string Compute256Hash(String fileName)
        {
            lock (_hashAlgorithm2)
            {
                byte[] fileData = null;
                using (FileStream fs = File.OpenRead(fileName))
                {
                    using (BinaryReader binaryReader = new BinaryReader(fs))
                    {
                        //3515682494 - _Getintopc.com_Blackmagic_Design_DaVinci_Resolve_Studio_18.1.4.0009.rar
                        if (fs.Length < 2147483647)//2,147,483,647 max value    1073741824=1GB
                        {
                            try
                            {
                                fileData = binaryReader.ReadBytes((int)fs.Length);
                                byte[] byteHash = _hashAlgorithm2.ComputeHash(fileData);
                                return BitConverter.ToString(byteHash);
                            }
                            catch {
                                //sometimes BinaryReader can not handle files
                                byte[] byteHash = _hashAlgorithm2.ComputeHash(fs);
                                return BitConverter.ToString(byteHash);
                            }
                        }
                        else {

                            byte[] byteHash = _hashAlgorithm2.ComputeHash(fs);
                            return BitConverter.ToString(byteHash);
                        }
                    }
                }
            }
            return null;
        }


        public byte[] FileToByteArray(string fileName)
        {
            byte[] fileData = null;

            using (FileStream fs = File.OpenRead(fileName))
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    fileData = binaryReader.ReadBytes((int)fs.Length);
                }
            }
            return fileData;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (processCompleted)
            {
                tootltip1label1.Text = stopwatch.Elapsed + " elapsed";
                processCompleted = false;
                NLog.LogManager.Flush(); // Flush and close down internal threads and timers
                NLog.LogManager.SuspendLogging();
                NLog.LogManager.ResumeLogging();
                this.btnFilesSearch.Enabled = true;
                tootltip1label2.Text = "Process completed successfully!";
                tootltip1label2.Text = "Process completed successfully!";
                tootltip1label2.Text = "Process completed successfully!";
                progressbarTimer.Stop();
                stopwatch.Stop();
                Thread.Sleep(300);//Do wait to write all the logs to output file
                timer1.Stop();
            }
            else
            {
                tootltip1label1.Text = stopwatch.Elapsed + " elapsed";
                tootltip1label2.Text = currentfilescan;
            }
            //this.textBox1.Text += sb_collectedText.ToString();
            //sb_collectedText.Clear();
        }

        private void progressbarTimer_Tick(object sender, EventArgs e)
        {
            //progressbarTimer
            if (!processCompleted)
                toolStripProgressBar1.Value = progressCounter;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && userExit == false)
            {
                FSW_trayicon.Visible = true;
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                
                thisForm = this;
                this.Hide();

                if (this.notifyIcon1 == null|| this.notifyIcon1.Container == null)
                {
                    this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
                    this.FSW_trayicon = new System.Windows.Forms.NotifyIcon(this.components);
                    //this.notifyIcon1 = new NotifyIcon(); 
                }

                this.notifyIcon1.Icon = new Icon(AssemblyDirectory+"\\Resources\\logo-p256.ico");
                this.notifyIcon1.Text = "File System Watcher Update!";
                this.notifyIcon1.Visible = true;                
                this.notifyIcon1.BalloonTipTitle = "Windows File Indexing Agent is still running in background";
                this.notifyIcon1.BalloonTipText = "Click to open the window again!";
                //this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
                this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_Click);                
                this.notifyIcon1.ShowBalloonTip(100);
                this.FSW_trayicon.Visible = false;
            }
            else
            {
                loger.Log(LogLevel.Info, "==================Closing Windows File Logger===============" + DateTime.UtcNow);

                FSW_trayicon.Visible = false;
                NLog.LogManager.Shutdown(); // Flush and close down internal threads and timers
            }
        }


        private void Exit_toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to close this application?", "Please confirm before closing!", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
            if (dialogResult == DialogResult.Yes)
            {
                FSW_trayicon.Visible = false;
                userExit = true;
                this.Close();
            }

        }

        public static void SetOnTop()
        {
            thisForm.Show();
            thisForm.WindowState = FormWindowState.Normal;
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        private void TaskScheduler_toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process taskScheduler = new Process();
            //SCHTASKS /CREATE /SC DAILY /TN "FOLDERPATH\TASKNAME" /TR "C:\SOURCE\FOLDER\APP-OR-SCRIPT" /ST HH:MM 
            //taskschd.msc /s
            string TaskParams = "/CREATE /SC DAILY /TN eSparkTask\\FSW" + DateTime.UtcNow.ToString() + "  /TR '" + AssemblyDirectory + "\\eSpark_WindowsFIA.exe' /ST 00:12 ";
            taskScheduler.StartInfo = new ProcessStartInfo("taskschd.msc", TaskParams);
            taskScheduler.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private String GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private void SetSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            if(configuration.AppSettings.Settings[key]!=null)
                configuration.AppSettings.Settings[key].Value = value;
            else configuration.AppSettings.Settings.Add(key,value);

            configuration.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
        private void FSWopen_toolStripMenuItem2_Click(object sender, EventArgs e)
        {
                FSW_trayicon.Visible = true;
                this.Show();
                this.WindowState = FormWindowState.Normal;
        }

        private void Quartz_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(quartzScheduler!=null)
                quartzScheduler.Show();
        }

        #region Public Methods

        /// <summary>
        ///   Shows the dialog...
        /// </summary>
        /// <returns>OK, if the user selected a folder or Cancel, if no folder is selected.</returns>
        /// 
        public string Description { get; set; } = "Chose folder...";

        /// <summary>
        ///   The ROOT path!
        /// </summary>
        public string RootPath { get; set; } = "";

        /// <summary>
        ///   The SelectedPath. Here is no initialization possible.
        /// </summary>
        public string SelectedPath { get; private set; } = "";

        private DialogResult ShowDialog1()
        {
            var shellType = Type.GetTypeFromProgID("Shell.Application");
            var shell = Activator.CreateInstance(shellType);
            var folder = shellType.InvokeMember("BrowseForFolder", BindingFlags.InvokeMethod, null,shell, new object[] { 0, Description, 0, RootPath, });
            if (folder is null)
            {
                return DialogResult.Cancel;
            }
            else
            {
                var folderSelf = folder.GetType().InvokeMember(
                                     "Self", BindingFlags.GetProperty, null,
                                     folder, null);
                SelectedPath = folderSelf.GetType().InvokeMember(
                                   "Path", BindingFlags.GetProperty, null,
                                   folderSelf, null) as string;
                // maybe ensure that SelectedPath is set
                return DialogResult.OK;
            }
        }

        #endregion Public Methods

        private void btnLogs_Click(object sender, EventArgs e)
        {
            UserControlLabel = "Please enter Logs and Database file location here";
            DialogResult result = ShowDialog1();

            if (result == DialogResult.OK)
            {
                //loger.Log(LogLevel.Trace, "===================Starting Scan =================== \r\n " + SelectedFldr);
                Description = Description;
                RootPath = RootPath;
                this.txtLogsAndDBpath.Text = SelectedPath;

                if (SelectedPath.Length > 0)
                    SetSetting("LogsDBPath", SelectedPath);
            }

        }

        public static String txtResult = "";
        public void ShowMyDialogBox()
        {
            Form2 testDialog = new Form2();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                //txtResult = testDialog.textBox1.Text;
            }
            else
            {
                //txtResult = "Cancelled";
            }
            testDialog.Dispose();
        }

        private void btnExcludefile_Click(object sender, EventArgs e)
        {
            txtResult = this.cmbExcludefileSize.Text;
            UserControlLabel = "Please enter Exclude File Filter Values Here";
            ShowMyDialogBox();
            this.cmbExcludefileSize.Text = txtResult;//combo text not replacing
            String CollectCollection = "";
            bool newRecExist = false;

            if (comboLastSelectedIndex > -1 && txtResult != this.cmbExcludefileSize.Items[comboLastSelectedIndex].ToString())
            {
                if (txtResult.Length < 3)
                    this.cmbExcludefileSize.Items.RemoveAt(comboLastSelectedIndex);
                else
                {
                    this.cmbExcludefileSize.Items.RemoveAt(comboLastSelectedIndex);
                    this.cmbExcludefileSize.Items.Add(txtResult);
                    CollectCollection += cmbExcludefileSize.SelectedText.ToString() + "~";
                }
            }

            
            if (txtResult.Length > 2 && this.cmbExcludefileSize.Items != null && this.cmbExcludefileSize.Items.Count > 0)
            {
                for (int i = 0; i < this.cmbExcludefileSize.Items.Count; i++)
                {
                    if (cmbExcludefileSize.Items[i].ToString().Contains(txtResult))
                        newRecExist = true;

                    if (!this.cmbExcludefileSize.Items.Contains(cmbExcludefileSize.Items[i].ToString()))
                        CollectCollection += cmbExcludefileSize.Items[i].ToString() + "~";
                    else if (!CollectCollection.Contains(cmbExcludefileSize.Items[i].ToString()))
                        CollectCollection += cmbExcludefileSize.Items[i].ToString() + "~";
                }
                CollectCollection = CollectCollection.Substring(0,CollectCollection.Length - 1);

                if (!newRecExist)
                    this.cmbExcludefileSize.Items.Add(txtResult);

                if (CollectCollection.Length > 0)
                    SetSetting("ExcludeFileSize", CollectCollection.Trim());
            }
            txtResult = "";
        }

        private void btnScanLoc_Click(object sender, EventArgs e)
        {
            txtResult = this.cmbScanLocations.Text;
            UserControlLabel = "Please enter Search Location Values Here";
            ShowMyDialogBox();
            this.cmbScanLocations.Text = txtResult;
            bool newRecExist = false;
            String CollectCollection = "";

            if (comboLastSelectedIndex > -1 && txtResult != this.cmbScanLocations.Items[comboLastSelectedIndex].ToString())
            {
                if (txtResult.Length < 3)
                    this.cmbScanLocations.Items.RemoveAt(comboLastSelectedIndex);
                else
                {
                    this.cmbScanLocations.Items.RemoveAt(comboLastSelectedIndex);
                    this.cmbScanLocations.Items.Add(txtResult);
                    CollectCollection += cmbScanLocations.SelectedText.ToString() + "~";
                }
            }

            if (txtResult.Length>2 && this.cmbScanLocations.Items != null && this.cmbScanLocations.Items.Count > 0)
            {
                for (int i = 0; i < this.cmbScanLocations.Items.Count; i++)
                {
                    if (cmbScanLocations.Items[i].ToString().Contains(txtResult))
                            newRecExist = true;

                    if (!CollectCollection.Contains(cmbScanLocations.Items[i].ToString()))
                        CollectCollection += cmbScanLocations.Items[i].ToString() + "~";
                    else if (!this.cmbScanLocations.Items.Contains(cmbScanLocations.Items[i].ToString()))
                        CollectCollection += cmbScanLocations.Items[i].ToString() + "~";
                }

                if (!newRecExist)
                        this.cmbScanLocations.Items.Add(txtResult);

                CollectCollection = CollectCollection.Substring(0, CollectCollection.Length - 1);

                if (CollectCollection.Length > 0)
                    SetSetting("ScanLocations", CollectCollection.Trim());
            }

            txtResult = "";
        }

        private void btnSrchFltr_Click(object sender, EventArgs e)
        {
            txtResult = this.cmbSrchFileFilter.Text;
            UserControlLabel = "Please enter File Search Filter Values Here";
            ShowMyDialogBox();
            this.cmbSrchFileFilter.Text = txtResult;
            bool newRecExist = false;

            String CollectCollection = "";

            if (comboLastSelectedIndex > 0 && txtResult != this.cmbSrchFileFilter.Items[comboLastSelectedIndex].ToString())
            {
                if (txtResult.Length < 3)
                    this.cmbSrchFileFilter.Items.RemoveAt(comboLastSelectedIndex);
                else
                {
                    this.cmbSrchFileFilter.Items.RemoveAt(comboLastSelectedIndex);
                    this.cmbSrchFileFilter.Items.Add(txtResult);
                    CollectCollection += cmbSrchFileFilter.SelectedText.ToString() + "~";
                }
            }

            if (txtResult.Length > 2 && this.cmbSrchFileFilter.Items != null && this.cmbSrchFileFilter.Items.Count > 0)
            {
                for (int i = 0; i < this.cmbSrchFileFilter.Items.Count; i++)
                {
                    if (cmbSrchFileFilter.Items[i].ToString().Contains(txtResult))
                        newRecExist = true;

                    if (comboLastSelectedIndex > 0 && i == comboLastSelectedIndex)
                    { 
                        CollectCollection += cmbSrchFileFilter.SelectedText.ToString()+ "~";
                        continue;
                    }

                    if (!this.cmbSrchFileFilter.Items.Contains(cmbSrchFileFilter.Items[i].ToString()))
                        CollectCollection += cmbSrchFileFilter.Items[i].ToString() + "~";
                    else if (!CollectCollection.Contains(cmbSrchFileFilter.Items[i].ToString()))
                        CollectCollection += cmbSrchFileFilter.Items[i].ToString() + "~";
                }

                if (!newRecExist)
                    this.cmbSrchFileFilter.Items.Add(txtResult);

                CollectCollection = CollectCollection.Substring(0, CollectCollection.Length - 1);
                if(CollectCollection.Length>0)
                    SetSetting("ExcludeFilterList", CollectCollection.Trim());
            }


            txtResult = "";
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.FSW_trayicon.Visible = true;
            //try { this.notifyIcon1.Dispose(); }
            //catch { }


        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            try { System.Diagnostics.Process.Start(AssemblyDirectory+"\\Help.chm"); } catch { }
        }

        private void cmbScanLocations_DropDownClosed(object sender, EventArgs e)
        {
             comboLastSelectedIndex = this.cmbScanLocations.SelectedIndex;
        }

        private void cmbExcludefileSize_DropDownClosed(object sender, EventArgs e)
        {
            comboLastSelectedIndex = this.cmbExcludefileSize.SelectedIndex;
        }

        private void cmbSrchFileFilter_DropDownClosed(object sender, EventArgs e)
        {
            comboLastSelectedIndex = this.cmbSrchFileFilter.SelectedIndex;
        }
    }
}