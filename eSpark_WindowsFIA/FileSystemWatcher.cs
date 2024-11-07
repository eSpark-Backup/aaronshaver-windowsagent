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
        public ControllerDB controllerDB = new ControllerDB();
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

            controllerDB = new ControllerDB();
            Form1.IsFSWRunning = true;

        }

        private void FileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            Form1.IsFSWRunning = true;
            Form1.currentfilescan = "FileSystemWatcher Error > " + e.ToString();
            
                Form1.loger.Log(LogLevel.Info, "==================FileSystemWatcher Error===============" + DateTime.UtcNow+" --- "+e.ToString());
            Form1.IsFSWRunning = false;
        }

        private void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            Form1.IsFSWRunning = true;
            controllerDB.InitializeFlexMoldDB();
            //controllerDB.DeleteData("ScannedFileLogs", " DirectoryID in (Select Distinct DirectoryID as DirectoryID from ScannedDirectoryLogs where DirectoryPath like '" + SelectedFldr + "%') ");
            //controllerDB.DeleteData("ScannedDirectoryLogs", " DirectoryPath like '" + SelectedFldr + "%'");

            Dictionary<string, string> parms = new Dictionary<string, string>();
            FileInfo fin = new FileInfo(e.FullPath);

            //if (!File.Exists(e.FullPath)) // This is directory
            //{
            //    //If directory already exist
            //    if (controllerDB.CheckRecordExistManual("Select DISTINCT d.DirectoryPath , f.FileName from ScannedFileLogs f , ScannedDirectoryLogs D where f.DirectoryID=D.DirectoryID and D.DirectoryPath =" + fin.Directory + "' "))
            //    {
            //        parms.Add("CreationDate", DateTime.UtcNow.ToString());
            //        parms.Add("DirectoryPath", e.FullPath);
            //        controllerDB.UpdateData("ScannedDirectoryLogs", " DirectoryPath =" + e.FullPath + "' ", parms);
            //    }
            //    else//Insert new record for directory
            //    {
            //        parms.Add("DirectoryID", e.FullPath.GetHashCode().ToString());
            //        parms.Add("DirectoryPath", e.FullPath);
            //        parms.Add("CreationDate", DateTime.UtcNow.ToString());
            //        parms.Add("ModifiedDate", null);
            //        parms.Add("AccessedDate", null);
            //        parms.Add("ScannedDate", null);

            //        controllerDB.InsertOnlyData("ScannedDirectoryLogs", null, parms);
            //    }

            //}
            //else //This is file                 
            //{                

            //if file exist then only update the file record for FAST process
            //if (controllerDB.CheckRecordExistManual("Select DISTINCT d.DirectoryPath , f.FileName from ScannedFileLogs f , ScannedDirectoryLogs D where f.DirectoryID=D.DirectoryID and D.DirectoryPath =" + fin.Directory + "' and f.FileName ='" + fin.Name + "'"))
            //{
            //    parms.Add("CreationDate", DateTime.UtcNow.ToString());
            //    controllerDB.UpdateData("ScannedFileLogs", " DirectoryPath =" + e.FullPath + "' ", parms);
            //}
            //else//Inser new record for directory and File
            //{
            String DirectoryIDNew = e.FullPath.GetHashCode().ToString();
            try
            {
                DataSet dsTemp = null;

                //ifthis is directory renamed?
                if (!File.Exists(e.FullPath)) // This is old directory renamed
                {
                    //if (!File.Exists(e.FullPath)) // This is new directory
                    //    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + e.OldFullPath + "' ");
                    //else                         
                    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + e.OldFullPath + "' ");

                    // if directory already exist then get record else create
                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                    {
                        DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();

                        if (!File.Exists(e.FullPath)) // This is directory
                        {
                            Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                            DirectoryInf.Add("RenamedDate", DateTime.UtcNow.ToString());
                            DirectoryInf.Add("DirectoryPath", e.FullPath);
                            DirectoryInf.Add("OldName", Path.GetFileName(e.OldFullPath));

                            controllerDB.UpdateData("ScannedDirectoryLogs", " DirectoryID ='" + DirectoryIDNew + "' ", DirectoryInf);
                        }
                    }

                }
                else// This is old file renamed 
                {
                    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + Path.GetDirectoryName(e.OldFullPath) + "' ");

                    // if directory already exist then get record else create
                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                    {
                        DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();

                        if (!File.Exists(e.OldFullPath)) // This is directory
                        {
                            Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                            DirectoryInf.Add("RenamedDate", DateTime.UtcNow.ToString());
                            DirectoryInf.Add("FileName", Path.GetFileName(e.FullPath));
                            DirectoryInf.Add("OldName", Path.GetFileName(e.OldFullPath));

                            controllerDB.UpdateData("ScannedFileLogs", " DirectoryID ='" + DirectoryIDNew + "' and FileName='" + Path.GetFileName(e.OldFullPath) + "' ", DirectoryInf);
                        }
                    }

                }
            }
            catch { }



            Form1.currentfilescan = "FileSystemWatcher Renamed > " + e.FullPath;
        }

        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Form1.IsFSWRunning = true;
            controllerDB.InitializeFlexMoldDB();
            //controllerDB.DeleteData("ScannedFileLogs", " DirectoryID in (Select Distinct DirectoryID as DirectoryID from ScannedDirectoryLogs where DirectoryPath like '" + SelectedFldr + "%') ");
            //controllerDB.DeleteData("ScannedDirectoryLogs", " DirectoryPath like '" + SelectedFldr + "%'");

            Dictionary<string, string> parms = new Dictionary<string, string>();
            FileInfo fin = new FileInfo(e.FullPath);

            String DirectoryIDNew = e.FullPath.GetHashCode().ToString();
            try
            {

                DataSet dsTemp = null;


                if (File.Exists(e.FullPath)) // This is File deleted
                {
                    //dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + e.FullPath + "' ");
                    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + Path.GetDirectoryName(e.FullPath) + "' ");

                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                    {
                        DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();
                        parms.Clear();
                        //parms.Add("DeleteDate", DirectoryIDNew);
                        parms.Add("DeleteDate", DateTime.UtcNow.ToString());
                        parms.Add("FileName", "~" + e.FullPath);
                        controllerDB.UpdateData("ScannedFileLogs", " DirectoryID ='" + DirectoryIDNew + "' and FileName='" + Path.GetFileName(e.FullPath) + "' ", parms);
                        Form1.currentfilescan = "FileSystemWatcher Deleted > " + e.FullPath;
                    }
                }
                else {

                    // This is directory deleted
                    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + e.FullPath + "' ");
                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                    {
                        DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();
                            //Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                            //DirectoryInf.Add("DirectoryPath", "~"+e.FullPath);
                            //DirectoryInf.Add("DeleteDate", DateTime.UtcNow.ToString());
                            
                        controllerDB.DeleteData("ScannedDirectoryLogs", " DirectoryID ='" + DirectoryIDNew + "' ");
                            
                        controllerDB.DeleteData("ScannedFileLogs", " DirectoryID ='" + DirectoryIDNew + "' ");


                        Form1.currentfilescan = "FileSystemWatcher Deleted > " + e.FullPath;
                    }
                }

                //else
                //{
                //    //Add directory record
                //    Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                //    //DirectoryInf.Add("DirectoryID", DirectoryIDNew);
                //    DirectoryInf.Add("DeleteDate", DateTime.UtcNow.ToString());
                //    controllerDB.UpdateData("ScannedDirectoryLogs", " DirectoryID ='" + DirectoryIDNew + "' ", DirectoryInf);
                //}
            }
            catch { }
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Form1.IsFSWRunning = true;
            //Modified
            controllerDB.InitializeFlexMoldDB();
            //controllerDB.DeleteData("ScannedFileLogs", " DirectoryID in (Select Distinct DirectoryID as DirectoryID from ScannedDirectoryLogs where DirectoryPath like '" + SelectedFldr + "%') ");
            //controllerDB.DeleteData("ScannedDirectoryLogs", " DirectoryPath like '" + SelectedFldr + "%'");

            Dictionary<string, string> parms = new Dictionary<string, string>();
            FileInfo fin = new FileInfo(e.FullPath);

            //if (!File.Exists(e.FullPath)) // This is directory
            //{
            //    //If directory already exist
            //    if (controllerDB.CheckRecordExistManual("Select DISTINCT d.DirectoryPath , f.FileName from ScannedFileLogs f , ScannedDirectoryLogs D where f.DirectoryID=D.DirectoryID and D.DirectoryPath =" + fin.Directory + "' "))
            //    {
            //        parms.Add("CreationDate", DateTime.UtcNow.ToString());
            //        parms.Add("DirectoryPath", e.FullPath);
            //        controllerDB.UpdateData("ScannedDirectoryLogs", " DirectoryPath =" + e.FullPath + "' ", parms);
            //    }
            //    else//Insert new record for directory
            //    {
            //        parms.Add("DirectoryID", e.FullPath.GetHashCode().ToString());
            //        parms.Add("DirectoryPath", e.FullPath);
            //        parms.Add("CreationDate", DateTime.UtcNow.ToString());
            //        parms.Add("ModifiedDate", null);
            //        parms.Add("AccessedDate", null);
            //        parms.Add("ScannedDate", null);

            //        controllerDB.InsertOnlyData("ScannedDirectoryLogs", null, parms);
            //    }

            //}
            //else //This is file                 
            //{                

            //if file exist then only update the file record for FAST process
            //if (controllerDB.CheckRecordExistManual("Select DISTINCT d.DirectoryPath , f.FileName from ScannedFileLogs f , ScannedDirectoryLogs D where f.DirectoryID=D.DirectoryID and D.DirectoryPath =" + fin.Directory + "' and f.FileName ='" + fin.Name + "'"))
            //{
            //    parms.Add("CreationDate", DateTime.UtcNow.ToString());
            //    controllerDB.UpdateData("ScannedFileLogs", " DirectoryPath =" + e.FullPath + "' ", parms);
            //}
            //else//Inser new record for directory and File
            //{
            String DirectoryIDNew = e.FullPath.GetHashCode().ToString();
            try
            {
                DataSet dsTemp = null;

                if (!File.Exists(e.FullPath)) // This is directory
                {
                    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + e.FullPath + "' ");
                    // if directory already exist then get record else create
                    // else condition will never happen in change event
                    if (dsTemp != null && dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                    {
                        DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();

                        if (!File.Exists(e.FullPath)) // This is directory
                        {
                            Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                            DirectoryInf.Add("ModifiedDate", DateTime.UtcNow.ToString());
                            controllerDB.UpdateData("ScannedDirectoryLogs", " DirectoryID ='" + DirectoryIDNew + "' ", DirectoryInf);
                            Form1.currentfilescan = "FileSystemWatcher Changed > " + e.FullPath;
                            return;
                        }

                    }
                }
                else
                {
                    //Add directory record
                    // will never happen in change BECAUSE in change directory must exist


                    //Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                    //DirectoryInf.Add("DirectoryID", DirectoryIDNew);
                    //DirectoryInf.Add("DirectoryPath", fin.Directory.FullName);
                    //DirectoryInf.Add("ScannedDate", DateTime.UtcNow.ToString());

                    //controllerDB.InsertOnlyData("ScannedDirectoryLogs", " DirectoryPath='" + fin.Directory.FullName + "' ", DirectoryInf);

                    //DirectoryInf.Clear();
                    //DirectoryInf.Add("ModifiedDate", DateTime.UtcNow.ToString());

                    //parms.Add("FileName", fin.Name);
                    //parms.Add("CreationDate", DateTime.UtcNow.ToString());
                    //parms.Add("ModifiedDate", null);
                    //parms.Add("AccessedDate", null);
                    //parms.Add("ScannedDate", DateTime.UtcNow.ToString());
                    //parms.Add("FileSize", fin.Length.ToString());

                    //controllerDB.InsertOnlyData("ScannedFileLogs", " DirectoryID ='" + DirectoryIDNew + "' ", DirectoryInf);
                    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + fin.Directory.FullName + "' ");

                    String fileSizeUnit = "Bytes";
                    double fileLengthKB = Math.Ceiling(fin.Length / 1024D);

                    if (fin.Length < 1024)
                    {
                        fileLengthKB = fin.Length;
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


                    parms.Clear();
                    parms.Add("ModifiedDate", DateTime.UtcNow.ToString());
                    parms.Add("FileSize", fileLengthKB.ToString() + fileSizeUnit);
                    controllerDB.UpdateData("ScannedFileLogs", "  DirectoryID ='" + DirectoryIDNew + "' ", parms);
                }

            }
            catch { }

            Form1.currentfilescan = "FileSystemWatcher Changed > " + e.FullPath;

        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Form1.IsFSWRunning = true;
            controllerDB.InitializeFlexMoldDB();
            //controllerDB.DeleteData("ScannedFileLogs", " DirectoryID in (Select Distinct DirectoryID as DirectoryID from ScannedDirectoryLogs where DirectoryPath like '" + SelectedFldr + "%') ");
            //controllerDB.DeleteData("ScannedDirectoryLogs", " DirectoryPath like '" + SelectedFldr + "%'");

            Dictionary<string, string> parms = new Dictionary<string, string>();
            FileInfo fin = new FileInfo(e.FullPath);

            //if (!File.Exists(e.FullPath)) // This is directory
            //{
            //    //If directory already exist
            //    if (controllerDB.CheckRecordExistManual("Select DISTINCT d.DirectoryPath , f.FileName from ScannedFileLogs f , ScannedDirectoryLogs D where f.DirectoryID=D.DirectoryID and D.DirectoryPath =" + fin.Directory + "' "))
            //    {
            //        parms.Add("CreationDate", DateTime.UtcNow.ToString());
            //        parms.Add("DirectoryPath", e.FullPath);
            //        controllerDB.UpdateData("ScannedDirectoryLogs", " DirectoryPath =" + e.FullPath + "' ", parms);
            //    }
            //    else//Insert new record for directory
            //    {
            //        parms.Add("DirectoryID", e.FullPath.GetHashCode().ToString());
            //        parms.Add("DirectoryPath", e.FullPath);
            //        parms.Add("CreationDate", DateTime.UtcNow.ToString());
            //        parms.Add("ModifiedDate", null);
            //        parms.Add("AccessedDate", null);
            //        parms.Add("ScannedDate", null);

            //        controllerDB.InsertOnlyData("ScannedDirectoryLogs", null, parms);
            //    }

            //}
            //else //This is file                 
            //{                

                //if file exist then only update the file record for FAST process
                //if (controllerDB.CheckRecordExistManual("Select DISTINCT d.DirectoryPath , f.FileName from ScannedFileLogs f , ScannedDirectoryLogs D where f.DirectoryID=D.DirectoryID and D.DirectoryPath =" + fin.Directory + "' and f.FileName ='" + fin.Name + "'"))
                //{
                //    parms.Add("CreationDate", DateTime.UtcNow.ToString());
                //    controllerDB.UpdateData("ScannedFileLogs", " DirectoryPath =" + e.FullPath + "' ", parms);
                //}
                //else//Inser new record for directory and File
                //{

            String DirectoryIDNew = e.FullPath.GetHashCode().ToString();
            try
            {
                
                
                if(File.Exists(e.FullPath)) //Create a file record
                {
                    DataSet dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + Path.GetDirectoryName(e.FullPath) + "' ");
                    DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();

                    dsTemp = controllerDB.ReadData("ScannedFileLogs", " DirectoryID ='" + DirectoryIDNew + "' and FileName='" + e.FullPath + "' ");

                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count < 1)
                    {

                        parms.Add("DirectoryID", DirectoryIDNew);
                        parms.Add("FileName", fin.Name);
                        parms.Add("CreationDate", DateTime.UtcNow.ToString());
                        parms.Add("FileSize", fin.Length.ToString());


                        if (Form1.calculateHash)
                        {
                            parms.Add("FileHash", Form1.Compute256Hash(fin.FullName));
                        }
                        else parms.Add("FileHash", "0000000");
                        controllerDB.InsertOnlyData("ScannedFileLogs", null, parms);
                    }
                }
                else//if (File.Exists(e.FullPath))
                {
                    DataSet dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + e.FullPath + "' ");

                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count < 1)
                    {
                        Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                        DirectoryInf.Add("DirectoryID", DirectoryIDNew);
                        DirectoryInf.Add("DirectoryPath", Path.GetDirectoryName(e.FullPath));
                        DirectoryInf.Add("CreationDate", DateTime.UtcNow.ToString());

                        controllerDB.InsertOnlyData("ScannedDirectoryLogs", " DirectoryPath='" + Path.GetDirectoryName(e.FullPath) + "' ", DirectoryInf);
                    }

                    dsTemp = controllerDB.ReadData("ScannedFileLogs", " DirectoryID ='" + DirectoryIDNew + "' and FileName='" + e.FullPath + "' ");

                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count < 1)
                    {

                        parms.Add("DirectoryID", DirectoryIDNew);
                        parms.Add("FileName", fin.Name);
                        parms.Add("CreationDate", DateTime.UtcNow.ToString());
                        parms.Add("FileSize", fin.Length.ToString());


                        if (Form1.calculateHash)
                        {
                            parms.Add("FileHash", Form1.Compute256Hash(fin.FullName));
                        }
                        else parms.Add("FileHash", "0000000");
                        controllerDB.InsertOnlyData("ScannedFileLogs", null, parms);
                    }
                }

                Form1.currentfilescan = "FileSystemWatcher Created > " + e.FullPath;

            }
            catch { }

            //}
            //}
        }

    }
}