using MetroSet_UI.Forms;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSpark_WindowsFIA
{
    public partial class Dashboard : MetroSetForm
    {
        //MainForm mainForm = new MainForm();
        public static MainForm mainForm = new MainForm();
        public static Form thisForm = null;
        private string strtup = "";
        

        public Dashboard(string[] srgs)
        {
            InitializeComponent();

            try
            {
                strtup = srgs[0];
            }
            catch { }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            thisForm = this;

            try
            {
                if (strtup.Contains("autostart"))
                {

                    this.Hide();
                    this.ShowInTaskbar = false;
                    this.ShowIcon = false;
                    this.ShowTitle = false;
                    
                    MainForm.loger.Log(LogLevel.Trace, "===================Autostart Called ===================");
                }
            }
            catch { }

        }

        private void _metroSetEllipse1_Click(object sender, EventArgs e)
        {
            this.Hide();

            mainForm.Show();
            //this.Dispose();
        }

        private void metroSetEllipse1_Click(object sender, EventArgs e)
        {
            if (MainForm.quartzScheduler != null)
                MainForm.quartzScheduler.Show();
        }

        private void metroSetEllipse2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(MainForm.AssemblyDirectory + "\\Help.chm"))
                    MetroSetMessageBox.Show(this, "No Help File Found! Please contact vendor!...", "Information not available...........", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                else
                    System.Diagnostics.Process.Start(MainForm.AssemblyDirectory + "\\Help.chm");
            }
            catch { }
        }

        private void metroSetEllipse3_Click(object sender, EventArgs e)
        {
            MetroSetMessageBox.Show(this, "Please wait for the next update?", "Update Available...........", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void Dashboard_DoubleClick(object sender, EventArgs e)
        {
            this.MaximumSize= new System.Drawing.Size(520, 580);
            this.MinimumSize = new System.Drawing.Size(520, 580);

        }

        private void Dashboard_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(520, 580);
            this.MinimumSize = new System.Drawing.Size(520, 580);
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MainForm.userExit)
                { }
                else
                {
                    try { e.Cancel = true; } catch { }
                    this.Hide();
                    this.ShowInTaskbar = false;
                    this.ShowIcon = false;
                    this.ShowTitle = false;
                }
            }
            catch { }
        }

        private void Dashboard_Validated(object sender, EventArgs e)
        {
            if (strtup.Contains("autostart"))
            {
                this.Hide();
                this.ShowInTaskbar = false;
                this.ShowIcon = false;
                this.ShowTitle = false;
                MessageBox.Show("Windows File Indexing Agent is still running in background", "AutoStartUp Called!");
            }
        }
    }
}
