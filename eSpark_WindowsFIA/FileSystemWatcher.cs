using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using static System.ConsoleColor;
using System.Security.Cryptography;
using System.Data;
using System.Threading;
using NLog;

namespace eSpark_WindowsFIA
{
    public class WindowsFIA_FSW
    {
        public void Initiate(string SubFolder)
        {

            // Create a new FileSystemWatcher instance
            FileSystemWatcher Watcher = new FileSystemWatcher()
            {

                IncludeSubdirectories = true,
                // Set the path to the directory you want to monitor
                Path = SubFolder,
                // Set the file filters (optional)
                Filter = "*.*",
                EnableRaisingEvents = true
            };

            // instantiate the object
            //var fileSystemWatcher = new FileSystemWatcher();

            // Associate event handlers with the events
            Watcher.Created += FileSystemWatcher_Created;
            Watcher.Changed += FileSystemWatcher_Changed;
            Watcher.Deleted += FileSystemWatcher_Deleted;
            Watcher.Renamed += FileSystemWatcher_Renamed;
            Watcher.Error += FileSystemWatcher_Error;

            //MainForm.IsFSWRunning = true;

        }

        private void FileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            //MainForm.IsFSWRunning = true;
            MainForm.currentfilescan = "FileSystemWatcher Error > " + e.ToString();

            MainForm.loger.Log(LogLevel.Info, "==================FileSystemWatcher Error===============" + DateTime.Now + " --- " + e.ToString());
            //MainForm.IsFSWRunning = false;
        }

        private void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            MainForm.IsFSWRunning = true;
            if (!e.FullPath.Contains(MainForm.logfilePath))
            {
            //new DataColumn("EventType", typeof(int)),//1=create,2=change/modify,3=delete,4=rename
            //new DataColumn("FullPath", typeof(string)),
            //new DataColumn("OldFullPath", typeof(string)),
            //new DataColumn("DatetimeCalled", typeof(DateTime))
            retrylab3:
                try
                {
                    lock (MainForm.DS_FSW)
                    {
                        var result = MainForm.DS_FSW.AsEnumerable().Where(myRow => myRow.Field<int>("EventType") == 4 && myRow.Field<string>("FullPath") == e.FullPath);

                        if (result.Count() < 1)
                        {
                            MainForm.DS_FSW.Rows.Add("4", e.FullPath, e.OldFullPath, DateTime.Now);
                            MainForm.DS_FSW.AcceptChanges();
                        }


                    }
                }
                catch (Exception ee) { goto retrylab3; }
            }
        }

        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            MainForm.IsFSWRunning = true;
            if (!e.FullPath.Contains(MainForm.logfilePath))
            {

            //new DataColumn("EventType", typeof(int)),//1=create,2=change/modify,3=delete,4=rename
            //new DataColumn("FullPath", typeof(string)),
            //new DataColumn("OldFullPath", typeof(string)),
            //new DataColumn("DatetimeCalled", typeof(DateTime))
            retrylab4: try
                {
                    lock (MainForm.DS_FSW)
                    {
                        var result = MainForm.DS_FSW.AsEnumerable().Where(myRow => myRow.Field<int>("EventType") == 3 && myRow.Field<string>("FullPath") == e.FullPath);

                        if (result.Count() < 1)
                        {
                            MainForm.DS_FSW.Rows.Add("3", e.FullPath, null, DateTime.Now);
                            MainForm.DS_FSW.AcceptChanges();
                        }

                    }
                }
                catch (Exception ee) { goto retrylab4; }
            }
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            MainForm.IsFSWRunning = true;
            //Modified
            //new DataColumn("EventType", typeof(int)),//1=create,2=change/modify,3=delete,4=rename
            //new DataColumn("FullPath", typeof(string)),
            //new DataColumn("OldFullPath", typeof(string)),
            //new DataColumn("DatetimeCalled", typeof(DateTime))
            if (!e.FullPath.Contains(MainForm.logfilePath))
            {
            retrylab1:
                try
                {
                    lock (MainForm.DS_FSW)
                    {
                        var result = MainForm.DS_FSW.AsEnumerable().Where(myRow => myRow.Field<int>("EventType") == 2 && myRow.Field<string>("FullPath") == e.FullPath);

                        if (result.Count() < 1)
                        {
                            MainForm.DS_FSW.Rows.Add("2", e.FullPath, null, DateTime.Now);
                            MainForm.DS_FSW.AcceptChanges();
                        }
                    }
                }
                catch (Exception ee) { goto retrylab1; }
            }
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            MainForm.IsFSWRunning = true;
            //new DataColumn("EventType", typeof(int)),//1=create,2=change/modify,3=delete,4=rename
            //new DataColumn("FullPath", typeof(string)),
            //new DataColumn("OldFullPath", typeof(string)),
            //new DataColumn("DatetimeCalled", typeof(DateTime))
            if (!e.FullPath.Contains(MainForm.logfilePath))
            {

            retrylab2: try
                {
                    lock (MainForm.DS_FSW)
                    {
                        var result = MainForm.DS_FSW.AsEnumerable().Where(myRow => myRow.Field<int>("EventType") == 1 && myRow.Field<string>("FullPath") == e.FullPath);

                        if (result.Count() < 1)
                        {
                            MainForm.DS_FSW.Rows.Add("1", e.FullPath, null, DateTime.Now);
                            MainForm.DS_FSW.AcceptChanges();
                        }

                    }
                }
                catch (Exception ee) { goto retrylab2; }

            }
        }
    }
}