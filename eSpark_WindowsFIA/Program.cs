using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Security.Principal;
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
                    var wi = WindowsIdentity.GetCurrent();
                    var wp = new WindowsPrincipal(wi);

                    bool runAsAdmin = wp.IsInRole(WindowsBuiltInRole.Administrator);

                    if (!runAsAdmin)
                    {
                        // It is not possible to launch a ClickOnce app as administrator directly,
                        // so instead we launch the app as administrator in a new process.
                        var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase);

                        // The following properties run the new process as administrator
                        processInfo.UseShellExecute = true;
                        processInfo.Verb = "runas";

                        try
                        {
                            Process.Start(processInfo);
                        }
                        catch (Exception)
                        {
                            // The user did not allow the application to run as administrator
                            MessageBox.Show("The program needs to run with administrative rights only!");
                        }

                        // Shutdown the current process
                        Application.Exit();
                    }
                    else
                    {
                        // We are running as administrator
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1(args));
                    }

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