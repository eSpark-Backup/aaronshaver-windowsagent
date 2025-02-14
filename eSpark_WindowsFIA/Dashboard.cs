using MetroSet_UI.Forms;
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

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            thisForm = this;
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
    }
}
