using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using System.Globalization;
using System.IO;
using MetroSet_UI.Forms;

namespace eSpark_WindowsFIA
{
    public partial class SchedulerNew : MetroSetForm
    {
        public SchedulerNew()
        {
            InitializeComponent();
            cmbRemoveJobs.SelectedIndex = 0;
        }

        public static void autoLoadJobsStartUp()
        {
            Scheduler newJob = new Scheduler();
            int totalJobs = 0;


            //MainForm.loger.Log(LogLevel.Info,"THis is a Info test logger");
            //MainForm.loger.Log(LogLevel.Warn, "THis is a Warn test logger");
            //MainForm.loger.Log(LogLevel.Error, "THis is a Error test logger");
            //MainForm.loger.Log(LogLevel.Trace, "THis is a Trace test logger");
            //MainForm.loger.Log(LogLevel.Debug, "THis is a Debug test logger");

            try
            {
                ControllerDB controllerDB = new ControllerDB();

                DataSet dsTemp = controllerDB.ReadData("ScheduledQuartzJob", " JobCompleted=0 and IsquartzJob=1 ");
                
                // if directory already exist then get record else create
                if (dsTemp!=null && dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Dr in dsTemp.Tables[0].Rows)
                    {
                        if (DateTime.Parse(Dr["ScannedDate"].ToString())< DateTime.Now)
                            continue;

                        newJob.Start(DateTime.Parse(Dr["CreationDate"].ToString()), DateTime.Parse(Dr["ScannedDate"].ToString()), Dr["ScanPath"].ToString(), bool.Parse(Dr["CalculateHash"].ToString() == "0" ? "False" : "True"), int.Parse(Dr["RepeatAfter"].ToString()),int.Parse( Dr["duration"].ToString()), true,true);

                        totalJobs++;
                    }

                }

            }
            catch(Exception eep) {
                var st = eep.Message;
                MainForm.loger.Log(LogLevel.Error, "===================AutoLoadJob_SchedullerErr =================== \r\n " + eep.StackTrace);
            }

            if (totalJobs>0)
                MessageBox.Show("Total " + totalJobs + " Jobs rescheduled!", "Process completed successfully! @ " + DateTime.Now.ToString(), MessageBoxButtons.OK);

        }

        private void btnNewJob_Click(object sender, EventArgs e)
        {
            Scheduler newJob = new Scheduler();
            int totalJobs = 0;

            if (txtScanPath.Text.Length < 1)
            {
                MessageBox.Show("Please select Scan Path", "No path selected!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cmdRemoveJob = this.cmbRemoveJobs.SelectedIndex;
            
            metroSetLabel3.Text = "Please wait.....";
            if (cmdRemoveJob > 0)
            {
                ControllerDB controllerDB = new ControllerDB();
                //None
                //Scan Path
                //Before StartDt
                //After StartDt
                //All

                if (cmdRemoveJob == 1)//Scan Path
                    controllerDB.DeleteData("ScheduledQuartzJob", " ScanPath like'" + this.txtScanPath.Text + "%'");
                //else if (cmdRemoveJob == 2)//Before StartDt
                //    controllerDB.DeleteData("ScheduledQuartzJob", " ScannedDate like'" + this.txtScanPath.Text + "%'");
                //else if (cmdRemoveJob == 3)//After StartDt
                //    controllerDB.DeleteData("ScheduledQuartzJob", " ScannedDate like'" + this.txtScanPath.Text + "%'");
                else if (cmdRemoveJob == 2)//All
                    controllerDB.DeleteData("ScheduledQuartzJob", null);

                if (this.chkRemove.Checked)
                {
                    MessageBox.Show("Removed Scheduler Data Successfully!", "Process completed successfully! @ " + DateTime.Now.ToString(), MessageBoxButtons.OK);
                    return;
                }
            }


            //int cmdNextRepeat = this.cmbRepeatDuration.SelectedIndex;

            //DateTime creationDate = DateTime.Now;
            //if ((int)numRepeatCntr.Value < 1)
            //    newJob.Start(creationDate, this.dtStartDate.Value, this.txtScanPath.Text, this.chkHashCalc.Checked, (int)this.numRepeatCntr.Value, cmdNextRepeat, false);
            //else
            //{
            //    //DateTime.Now.ToString()
            //    DateTime nextRepeatdt = this.dtStartDate.Value;
            //    int cntr = 0;
            //    for (int repeatcntr = 0; repeatcntr < (int)this.numRepeatCntr.Value; repeatcntr++)
            //    {
            //        if (this.cmbRepeatDuration.SelectedIndex == 1)// daily seleced
            //        {
            //            newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Checked, (int)this.numRepeatCntr.Value, cmdNextRepeat, false);
            //            nextRepeatdt = nextRepeatdt.AddDays(1);
            //            totalJobs++;
            //        }
            //        else if (this.cmbRepeatDuration.SelectedIndex == 2)// weekly seleced
            //        {
            //            while (cntr < 7)
            //            {
            //                newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Checked, (int)this.numRepeatCntr.Value, cmdNextRepeat, false);
            //                cntr++;
            //                nextRepeatdt = nextRepeatdt.AddDays(1);
            //                totalJobs++;
            //            }
            //        }
            //        else if (cmbRepeatDuration.SelectedIndex == 3)// monthly seleced
            //            while (cntr < 30)
            //            {
            //                newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Checked, (int)this.numRepeatCntr.Value, cmdNextRepeat, false);
            //                cntr++;
            //                nextRepeatdt = nextRepeatdt.AddDays(1);
            //                totalJobs++;
            //            }
            //        cntr = 0;

            //    }

            //int cmdNextRepeat = this.cmbRepeatDuration.SelectedIndex;

            DateTime creationDate = DateTime.Now;
            //if ((int)numRepeatCntr.Value < 1)
            //    newJob.Start(creationDate, this.dtStartDate.Value, this.txtScanPath.Text, this.chkHashCalc.Checked, (int)this.numRepeatCntr.Value, cmdNextRepeat, false);
            //else
            //{
            //DateTime.Now.ToString()
            DateTime nextRepeatdt = this.dtStartDate.Value;
            int cntr = 0;
            int createJobsfor = 1;
            try
            {
                createJobsfor = int.Parse(ConfigurationManager.AppSettings["createJobDays"]);
            }
            catch {
                //createJobDays
                MessageBox.Show("Application settings parameter -> createJobDays has incorrect value!", "Application settings error!", MessageBoxButtons.OK);
                return;
            }

            for (int repeatcntrYear = 0; repeatcntrYear <= createJobsfor; repeatcntrYear++)//create whole year jobs
            {
                if (!this.Monday.Checked && nextRepeatdt.ToString("dddd") == this.Monday.Name)//Monday
                {
                    if (this.chkQuartzJobs.Switched)
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, true);
                    else
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, false);
                }
                else if (!this.Tuesday.Checked && nextRepeatdt.ToString("dddd") == this.Tuesday.Name)//Tuesday
                {
                    if (this.chkQuartzJobs.Switched)
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, true);
                    else
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, false);
                }

                else if (!this.Wednesday.Checked && nextRepeatdt.ToString("dddd") == this.Wednesday.Name)//Wedday
                {
                    if (this.chkQuartzJobs.Switched)
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, true);
                    else
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, false);
                }

                else if (!this.Thursday.Checked && nextRepeatdt.ToString("dddd") == this.Thursday.Name)//Thursday
                {
                    if (this.chkQuartzJobs.Switched)
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, true);
                    else
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, false);
                }

                else if (!this.Friday.Checked && nextRepeatdt.ToString("dddd") == this.Friday.Name)//Friday
                {
                    if (this.chkQuartzJobs.Switched)
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, true);
                    else
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, false);
                }

                else if (!this.Saturday.Checked && nextRepeatdt.ToString("dddd") == this.Saturday.Name)//Saturday
                {
                    if (this.chkQuartzJobs.Switched)
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, true);
                    else
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, false);
                }

                else if (!this.Sunday.Checked && nextRepeatdt.ToString("dddd") == this.Sunday.Name)//Sunday
                {
                    if (this.chkQuartzJobs.Switched)
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, true);
                    else
                        newJob.Start(creationDate, nextRepeatdt, this.txtScanPath.Text, this.chkHashCalc.Switched, 1, 1, false, false);
                }

                else
                {
                    cntr++;
                    nextRepeatdt = nextRepeatdt.AddDays(1);
                    continue;
                }

                CreateWindowsTask(nextRepeatdt);

                cntr++;
                nextRepeatdt = nextRepeatdt.AddDays(1);
                totalJobs++;
            }

            MessageBox.Show("Total " + totalJobs + " Jobs added!", "Process completed successfully! @ " + DateTime.Now.ToString(), MessageBoxButtons.OK);
            try
            {
                this.Hide();
                MainForm.SetOnTop();
            }
            catch(Exception ep) { MainForm.loger.Log(LogLevel.Error, "===================SchedullerErr =================== \r\n " + ep.StackTrace); 
            }

            metroSetLabel3.Text = "";
        }

    private void btnScanPath_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();

            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtScanPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void SchedulerNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                //this.WindowState = FormWindowState.Minimized;
                this.Hide();
                try
                {
                    if (Dashboard.mainForm != null)
                        Dashboard.mainForm.Show();
                    else
                        MetroSetMessageBox.Show(this, "Error loading Application! Please contact vendor!...", "Information not available...........", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                catch
                {
                    MetroSetMessageBox.Show(this, "Error loading Application! Please contact vendor!...", "Information not available...........", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        //private bool createTaskSchedulerTask(DateTime dtStart)
        //{
        //    // To check the task : "C:\WINDOWS\system32\mmc.exe" "C:\WINDOWS\system32\taskschd.msc" /s  

        //    // Add reference to : TaskScheduler 1.1 Type Library  
        //    // Add : using TaskScheduler;  
        //    ITaskService ts = new TaskScheduler.TaskScheduler();
        //    try
        //    {
        //        ts.Connect(null, null, null, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show("Error : " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    ITaskDefinition td = ts.NewTask(0);
        //    td.RegistrationInfo.Author = "Task Author";
        //    td.RegistrationInfo.Description = "Task Description";

        //    //ITimeTrigger tt = (ITimeTrigger)td.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME);  
        //    //tt.Enabled = true;  
        //    //tt.StartBoundary = (DateTime.Now.AddSeconds(60)).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");  
        //    //tt.Repetition.Interval = "PT1M";  

        //    CultureInfo cultinfo = new CultureInfo("en-US");
        //    DateTime startDate = Convert.ToDateTime("04-01-2021 12:10:15 AM", cultinfo);
        //    DateTime endDate = Convert.ToDateTime("04-01-2022 12:10:15 AM", cultinfo);

        //    // https://learn.microsoft.com/en-us/windows/win32/taskschd/monthlytrigger  
        //    IMonthlyTrigger mt = (IMonthlyTrigger)td.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_MONTHLY);
        //    mt.StartBoundary = startDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
        //    mt.EndBoundary = endDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
        //    mt.DaysOfMonth = 0x20000000 | 0x40000000; // 30 and 31  
        //    //mt.MonthsOfYear = MonthsOfTheYear.AllMonths;  
        //    mt.MonthsOfYear = 0X400 | 0X800; // November and December  

        //    td.Settings.MultipleInstances = _TASK_INSTANCES_POLICY.TASK_INSTANCES_PARALLEL;

        //    IExecAction execAction = (IExecAction)td.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
        //    execAction.Path = @"c:\windows\notepad.exe";
        //    var rootFolder = ts.GetFolder("\\");
        //    try
        //    {
        //        IRegisteredTask ticket = rootFolder.RegisterTaskDefinition("MyNewTask", td, (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE, null, null, _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show("Could not add a task : " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    return true
        //}

        private void CreateWindowsTask(DateTime TaskStartDT )
        {
            // Get the service on the local machine
            using (var ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.Settings.MultipleInstances = TaskInstancesPolicy.IgnoreNew;
                td.RegistrationInfo.Description = "eSpark_WindowsFIA_"+this.txtScanPath.Text.Replace('\\','-').Replace(':', '-');                
                // Create a trigger that will execute very 2 minutes. 
                var trigger = new TimeTrigger();

                td.Principal.RunLevel = TaskRunLevel.Highest;

                //trigger.Repetition.Interval = TimeSpan.FromMinutes(2);
                trigger.StartBoundary = TaskStartDT;                
                td.Triggers.Add(trigger);
                

                // Create an action that will launch my jobs whenever the trigger fires -- Path,Argument,WorkingDir
                td.Actions.Add(new ExecAction(System.Reflection.Assembly.GetExecutingAssembly().Location, " r=taskschd.msc ScannedDate=" + TaskStartDT.ToString(), Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
                //"eSpark_WindowsFIA"

                // Register the task in the root folder
                //ts.RootFolder.RegisterTaskDefinition(@"WindowsFIA_" + TaskStartDT.ToString().Replace('/', '-').Replace(' ', '-'), td);

                // Create SubFolder under RootFolder, if you require
                TaskFolder rootFolder = ts.GetFolder(@"\");// ‘6’ as argument means this task can be created or updated [“CreateOrUpdate” flag]
                                                           // if Name id empty or null, System will create a task with name as GUID
                try { rootFolder.CreateFolder("eSpark", TaskSecurity.DefaultTaskSecurity); } catch(Exception tep) { }

                //"WindowsFIA_07-02-2025-6:00:00-am"
                //NotAllowedChars//\ / : * ? " < > |
                try { 
                String pat = "WindowsFIA_" + TaskStartDT.ToString().Replace('/', '-').Replace(' ', '_').Replace(":", "");
                ts.RootFolder.SubFolders["eSpark"].RegisterTaskDefinition(pat, td);
                    //Microsoft.Win32.TaskScheduler.Task task = ts.RootFolder.SubFolders["eSpark"].RegisterTaskDefinition(pat, td);

                    //ts.RootFolder.SubFolders["eSpark"].RegisterTaskDefinition(@"WindowsFIA_" + TaskStartDT.ToString().Replace('/', '-').Replace(' ', '-'), td);
                }
                catch
                {
                    MainForm.loger.Log(LogLevel.Error, "===================ErrorCreatingWindowsTaskSchedulerJobs =================== \r\n ");
                    //MetroSetMessageBox.Show(this, "Error loading Application! Please contact vendor!...", "Information not available...........", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
