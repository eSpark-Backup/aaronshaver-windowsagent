using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSpark_WindowsFIA
{
    public partial class QuartzScheduler : Form
    {        

        public QuartzScheduler()
        {
            InitializeComponent();
            cmbRemoveJobs.SelectedIndex = 0;
            cmbRepeatDuration.SelectedIndex = 0;
        }

        public static void autoLoadJobsStartUp()
        {
            Scheduler newJob = new Scheduler();
            int totalJobs = 0;


            //Form1.loger.Log(LogLevel.Info,"THis is a Info test logger");
            //Form1.loger.Log(LogLevel.Warn, "THis is a Warn test logger");
            //Form1.loger.Log(LogLevel.Error, "THis is a Error test logger");
            //Form1.loger.Log(LogLevel.Trace, "THis is a Trace test logger");
            //Form1.loger.Log(LogLevel.Debug, "THis is a Debug test logger");

            try
            {
                ControllerDB controllerDB = new ControllerDB();

                DataSet dsTemp = controllerDB.ReadData("ScheduledQuartzJob", " JobCompleted=0 ");
                
                // if directory already exist then get record else create
                if (dsTemp!=null && dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Dr in dsTemp.Tables[0].Rows)
                    {
                        if (DateTime.Parse(Dr["ScannedDate"].ToString())< DateTime.Now)
                            continue;

                        newJob.Start(DateTime.Parse(Dr["CreationDate"].ToString()), DateTime.Parse(Dr["ScannedDate"].ToString()), Dr["ScanPath"].ToString(), bool.Parse(Dr["CalculateHash"].ToString() == "0" ? "False" : "True"), int.Parse(Dr["RepeatAfter"].ToString()),int.Parse( Dr["duration"].ToString()), true);

                        totalJobs++;
                    }

                }

            }
            catch(Exception eep) {
                var st = eep.Message;
            }

            if (totalJobs>0)
                MessageBox.Show("Total " + totalJobs + " Jobs rescheduled!", "Process completed successfully!", MessageBoxButtons.OK);

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

            int cmdRemoveJob = cmbRemoveJobs.SelectedIndex;

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
                    MessageBox.Show("Removed Scheduler Data Successfully!", "Process completed successfully!", MessageBoxButtons.OK);
                    return;
                }
            }


            int cmdNextRepeat = cmbRepeatDuration.SelectedIndex;

            DateTime creationDate = DateTime.Now;
            if ((int)numRepeatCntr.Value < 1)
                newJob.Start(creationDate, this.dtStartDate.Value, txtScanPath.Text, chkHashCalc.Checked, (int)numRepeatCntr.Value, cmdNextRepeat, false);
            else
            {
                //DateTime.Now.ToString()
                DateTime nextRepeatdt = this.dtStartDate.Value;
                int cntr = 0;
                for (int repeatcntr = 0; repeatcntr < (int)numRepeatCntr.Value; repeatcntr++)
                {
                    if (cmbRepeatDuration.SelectedIndex == 1)// daily seleced
                    {
                        newJob.Start(creationDate, nextRepeatdt, txtScanPath.Text, chkHashCalc.Checked, (int)numRepeatCntr.Value, cmdNextRepeat, false);
                        nextRepeatdt = nextRepeatdt.AddDays(1);
                        totalJobs++;
                    }
                    else if (cmbRepeatDuration.SelectedIndex == 2)// weekly seleced
                    {
                        while (cntr < 7)
                        {
                            newJob.Start(creationDate, nextRepeatdt, txtScanPath.Text, chkHashCalc.Checked, (int)numRepeatCntr.Value, cmdNextRepeat, false);
                            cntr++;
                            nextRepeatdt = nextRepeatdt.AddDays(1);
                            totalJobs++;
                        }
                    }
                    else if (cmbRepeatDuration.SelectedIndex == 3)// monthly seleced
                        while (cntr < 30)
                        {
                            newJob.Start(creationDate, nextRepeatdt, txtScanPath.Text, chkHashCalc.Checked, (int)numRepeatCntr.Value, cmdNextRepeat, false);
                            cntr++;
                            nextRepeatdt = nextRepeatdt.AddDays(1);
                            totalJobs++;
                        }
                    cntr = 0;

                }

            }

            MessageBox.Show("Total " + totalJobs + " Jobs added!", "Process completed successfully!", MessageBoxButtons.OK);
            try
            {
                this.Hide();
                Form1.SetOnTop();
            }
            catch { }
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
    }
}
