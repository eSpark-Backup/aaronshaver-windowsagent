using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSpark_WindowsFIA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        static void Main(String[] args)
        {
            bool instanceCountOne = false;

            using (Mutex mtex = new Mutex(true, "eSparkWindowsFIA", out instanceCountOne))
            {
                if (instanceCountOne)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(args));
                    mtex.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show("Only one instance of application can be run at a time!", "Application Already Running",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

        }
    }
}
