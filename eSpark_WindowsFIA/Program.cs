using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace eSpark_WindowsFIA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 


        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);


        [STAThread]
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        static void Main(String[] args)
        {
            bool instanceCountOne = false;
            Mutex mtex;

            //if (Mutex.TryOpenExisting("eSparkWindowsFIA", out mtex))
            //{
            //    //MainForm.ShowFolderBrowserDialogAsync();  
            //    MessageBox.Show("Task Scheduler Called!");
            //    try { MainForm.timer_callByTaskSched.Start(); } catch (Exception x) { MessageBox.Show("Task Scheduler Called!2222" + x.Message); }


            //    //https://stackoverflow.com/questions/2461171/why-does-getwindowthreadprocessid-return-0-when-called-from-a-service
            //    var processesToAttachTo = Process.GetProcessesByName("eSparkWindowsFIA");
            //    var threadID = (uint)0;
            //    foreach (var process in processesToAttachTo)
            //        threadID = GetWindowThreadProcessId(process.MainWindowHandle, IntPtr.Zero);

            //}
            //else
            //{
            using (mtex = new Mutex(true, "eSparkWindowsFIA", out instanceCountOne))
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
                        //Application.SetCompatibleTextRenderingDefault(false);
                        //Application.Run(new Form1());
                        Application.Run(new Dashboard(args));

                    }
                    mtex.ReleaseMutex();
                }
                else
                {
                    //try
                    //{
                    //    if (!MainForm.timer_callByTaskSched.Enabled)
                    //        MainForm.timer_callByTaskSched.Start();
                    //}
                    //catch (Exception x) { MessageBox.Show(" Scheduler Services Not Running, Please Run Some Tasks From FileSystemAgent!", "Scheduler Services Not Running"); return; }

                    String logfilePath = ConfigurationManager.AppSettings["LogsDBPath"];
                    //2025-03-03 13:54:34.5834|INFO|eSpark_WindowsFIA.MainForm|==================Closing Windows File Logger===============3/3/2025 1:54:34 PM
                    try
                    { 
                        File.WriteAllText(MainForm.AssemblyDirectory + "\\callTaskScheduler", string.Join(" ", args));
 
                            //String LogFileName = Directory.GetFiles(logfilePath, "*.txt", SearchOption.AllDirectories)[0];
                            File.AppendAllText(logfilePath + "\\errLogs.txt", DateTime.Now + "|INFO|eSpark_WindowsFIA.MainForm|==================CalledByTaskScheduler===============" + string.Join(" ", args)+Environment.NewLine);

                    } catch(Exception ep) { File.AppendAllText(logfilePath+"\\errLogs.txt", DateTime.Now + "|INFO|eSpark_WindowsFIA.MainForm|*******************Error CalledByTaskScheduler===============" + string.Join(" ", args)+Environment.NewLine+" Error>>>"+ep.Message ); }
                    
                    //MessageBox.Show(MainForm.AssemblyDirectory + "\\callTaskScheduler >>>"+ string.Join(" ", args), "Application Already Running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //}
        }

        //private static void UpdateLogdbEntryMain()
        //{
        //    try
        //    {//Logs level
        //     //0=None
        //     //1=Errors Only
        //     //Errors and Search Results
        //     //Full Logs

        //        MainForm.LogsLevel = int.Parse(ConfigurationManager.AppSettings["LogsLevel"]);
        //    }
        //    catch { }


        //        String logfilePath = ConfigurationManager.AppSettings["LogsDBPath"];


        //    // Targets where to log to: File and Console
        //    var logfile = new NLog.Targets.FileTarget("logfile")
        //    {
        //        FileName = (logfilePath + "\\logfile.txt").Replace("\\\\", "\\"),
        //        ArchiveFileName = "logfile.{#}.txt",
        //        ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Date,
        //        ArchiveEvery = NLog.Targets.FileArchivePeriod.Day,
        //        ArchiveDateFormat = "yyyyMMdd"
        //    };

        //    // Rules for mapping loggers to targets            
        //    //config.AddRule(LogLevel.Info, LogLevel.Info, logfile);
        //    //config.AddRule(LogLevel.Debug, LogLevel.Debug, logfile);            
        //    if (MainForm.LogsLevel == 0) MainForm.config.AddRule(LogLevel.Info, LogLevel.Info, logfile);
        //    else if (MainForm.LogsLevel == 1) MainForm.config.AddRule(LogLevel.Error, LogLevel.Fatal, logfile);
        //    else if (MainForm.LogsLevel == 2) MainForm.config.AddRule(LogLevel.Trace, LogLevel.Info, logfile);
        //    else if (MainForm.LogsLevel == 3) MainForm.config.AddRule(LogLevel.Trace, LogLevel.Fatal, logfile);

        //    MainForm.config.Reload();

        //    // Apply config           
        //    NLog.LogManager.Configuration = MainForm.config;
        //    MainForm.loger = NLog.LogManager.GetCurrentClassLogger();

        //}

    }
}