using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSpark_WindowsFIA
{
    public class FSW_BulkWriter
    {
        public ControllerDB controllerDB = new ControllerDB();

        public void CreateRecords(string FullPath,string OldPath,DateTime dtUpdated)
        {
            controllerDB.InitializeFlexMoldDB();

            Dictionary<string, string> parms = new Dictionary<string, string>();
            FileInfo fin = new FileInfo(FullPath);

            Random rnd = new Random();
            int num = rnd.Next(int.MinValue, FullPath.GetHashCode());
            String DirectoryIDNew = num.ToString();
            try
            {


                if (File.Exists(FullPath)) //Create a file record
                {
                    DataSet dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + Path.GetDirectoryName(FullPath) + "' ");
                    DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();

                    dsTemp = controllerDB.ReadData("ScannedFileLogs", " DirectoryID ='" + DirectoryIDNew + "' and FileName='" + FullPath + "' ");

                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count < 1)
                    {

                        parms.Add("DirectoryID", DirectoryIDNew);
                        parms.Add("FileName", fin.Name);
                        parms.Add("CreationDate", DateTime.Now.ToString());
                        parms.Add("FileSize", fin.Length.ToString());


                        if (MainForm.chkHashCalc)
                        {
                            parms.Add("FileHash", MainForm.Compute256Hash(fin.FullName));
                        }
                        else parms.Add("FileHash", "0000000");
                        controllerDB.InsertOnlyData("ScannedFileLogs", null, parms);
                    }
                }
                else//create directory
                {

                    //first check if a moved directory?
                    DataSet dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + "~"+FullPath + "' ");
                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)//when one record found
                    {
                        Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                        //DirectoryInf.Add("DirectoryID", DirectoryIDNew);
                        //DirectoryInf.Add("DirectoryPath", Path.GetDirectoryName(FullPath));
                        DirectoryInf.Add("DirectoryPath", FullPath);
                        DirectoryInf.Add("ModifiedDate", DateTime.Now.ToString());

                        controllerDB.UpdateData("ScannedDirectoryLogs", " DirectoryPath='" + FullPath + "' ", DirectoryInf);
                    }
                    else//This is newly created directory with files
                    {
                        dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + FullPath + "' ");
                        if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count < 1)//when no record found
                        {
                            Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                            DirectoryInf.Add("DirectoryID", DirectoryIDNew);
                            //DirectoryInf.Add("DirectoryPath", Path.GetDirectoryName(FullPath));
                            DirectoryInf.Add("DirectoryPath", FullPath);
                            DirectoryInf.Add("CreationDate", DateTime.Now.ToString());

                            controllerDB.InsertOnlyData("ScannedDirectoryLogs", " DirectoryPath='" + Path.GetDirectoryName(FullPath) + "' ", DirectoryInf);
                        }

                        dsTemp = controllerDB.ReadData("ScannedFileLogs", " DirectoryID ='" + DirectoryIDNew + "' and FileName='" + FullPath + "' ");

                        if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count < 1)
                        {

                            parms.Add("DirectoryID", DirectoryIDNew);
                            parms.Add("FileName", fin.Name);
                            parms.Add("CreationDate", DateTime.Now.ToString());
                            parms.Add("FileSize", fin.Length.ToString());


                            if (MainForm.chkHashCalc)
                            {
                                parms.Add("FileHash", MainForm.Compute256Hash(fin.FullName));
                            }
                            else parms.Add("FileHash", "0000000");
                            controllerDB.InsertOnlyData("ScannedFileLogs", null, parms);
                        }
                    }
                }

                MainForm.currentfilescan = "FileSystemWatcher Created > " + FullPath;

            }
            catch { }

        }

        public void ChangeRecords(string FullPath, string OldPath, DateTime dtUpdated)
        {
            controllerDB.InitializeFlexMoldDB();

            Dictionary<string, string> parms = new Dictionary<string, string>();
            FileInfo fin = new FileInfo(FullPath);

            String DirectoryIDNew = FullPath.GetHashCode().ToString();
            try
            {
                DataSet dsTemp = null;

                if (!File.Exists(FullPath)) // This is directory
                {
                    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + FullPath + "' ");
                    // if directory already exist then get record else create
                    // else condition will never happen in change event
                    if (dsTemp != null && dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                    {
                        DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();

                        Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                        DirectoryInf.Add("ModifiedDate", DateTime.Now.ToString());
                        controllerDB.UpdateData("ScannedDirectoryLogs", " DirectoryID ='" + DirectoryIDNew + "' ", DirectoryInf);
                        MainForm.currentfilescan = "FileSystemWatcher Changed > " + FullPath;
                        return;

                    }
                }
                else
                {
                    //Add directory record
                    // will never happen in change BECAUSE in change directory must exist


                    //Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                    //DirectoryInf.Add("DirectoryID", DirectoryIDNew);
                    //DirectoryInf.Add("DirectoryPath", fin.Directory.FullName);
                    //DirectoryInf.Add("ScannedDate", DateTime.Now.ToString());

                    //controllerDB.InsertOnlyData("ScannedDirectoryLogs", " DirectoryPath='" + fin.Directory.FullName + "' ", DirectoryInf);

                    //DirectoryInf.Clear();
                    //DirectoryInf.Add("ModifiedDate", DateTime.Now.ToString());

                    //parms.Add("FileName", fin.Name);
                    //parms.Add("CreationDate", DateTime.Now.ToString());
                    //parms.Add("ModifiedDate", null);
                    //parms.Add("AccessedDate", null);
                    //parms.Add("ScannedDate", DateTime.Now.ToString());
                    //parms.Add("FileSize", fin.Length.ToString());

                    //controllerDB.InsertOnlyData("ScannedFileLogs", " DirectoryID ='" + DirectoryIDNew + "' ", DirectoryInf);
                    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + fin.Directory.FullName + "' ");
                    if (dsTemp != null && dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                    {
                        DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();
                    }

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
                    parms.Add("ModifiedDate", DateTime.Now.ToString());
                    parms.Add("FileSize", fileLengthKB.ToString() + fileSizeUnit);
                    controllerDB.UpdateData("ScannedFileLogs", "  DirectoryID ='" + DirectoryIDNew + "' and FileName='" + fin.Name + "' ", parms);
                }

            }
            catch { }

            MainForm.currentfilescan = "FileSystemWatcher Changed > " + FullPath;

        }

        public void DeleteRecords(string FullPath, string OldPath, DateTime dtUpdated)
        {
            controllerDB.InitializeFlexMoldDB();

            Dictionary<string, string> parms = new Dictionary<string, string>();
            FileInfo fin = new FileInfo(FullPath);

            String DirectoryIDNew = FullPath.GetHashCode().ToString();
            try
            {

                DataSet dsTemp = null;

                if (Path.GetExtension(FullPath).Length > 3 && Path.GetExtension(FullPath).Length < 9) // This is File deleted
                {
                    //dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + FullPath + "' ");
                    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + Path.GetDirectoryName(FullPath) + "' ");

                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                    {
                        DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();
                        parms.Clear();
                        //parms.Add("DeleteDate", DirectoryIDNew);
                        parms.Add("DeleteDate", DateTime.Now.ToString());
                        parms.Add("FileName", "~" + FullPath);
                        controllerDB.UpdateData("ScannedFileLogs", " DirectoryID ='" + DirectoryIDNew + "' and FileName='" + Path.GetFileName(FullPath) + "' ", parms);
                        MainForm.currentfilescan = "FileSystemWatcher Deleted > " + FullPath;
                    }
                }
                else
                {

                    // This is directory deleted
                    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + FullPath + "' ");
                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                    {
                        DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();
                        Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                        DirectoryInf.Add("DirectoryPath", "~"+FullPath);
                        DirectoryInf.Add("DeleteDate", dtUpdated.ToString());
                        //controllerDB.DeleteData("ScannedDirectoryLogs", " DirectoryID ='" + DirectoryIDNew + "' ");
                        //controllerDB.DeleteData("ScannedFileLogs", " DirectoryID ='" + DirectoryIDNew + "' ");
                        controllerDB.UpdateData("ScannedDirectoryLogs", " DirectoryPath ='" + FullPath + "' ", DirectoryInf);
                        MainForm.currentfilescan = "FileSystemWatcher Deleted > " + FullPath;
                    }
                }

                //else
                //{
                //    //Add directory record
                //    Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                //    //DirectoryInf.Add("DirectoryID", DirectoryIDNew);
                //    DirectoryInf.Add("DeleteDate", DateTime.Now.ToString());
                //    controllerDB.UpdateData("ScannedDirectoryLogs", " DirectoryID ='" + DirectoryIDNew + "' ", DirectoryInf);
                //}
            }
            catch { }
        }

        public void RenameRecords(string FullPath, string OldPath, DateTime dtUpdated)
        {

            controllerDB.InitializeFlexMoldDB();

            Dictionary<string, string> parms = new Dictionary<string, string>();
            FileInfo fin = new FileInfo(FullPath);

            String DirectoryIDNew = FullPath.GetHashCode().ToString();
            try
            {
                DataSet dsTemp = null;

                //ifthis is directory renamed?
                if (!File.Exists(FullPath)) // This is old directory renamed
                {
                    //if (!File.Exists(FullPath)) // This is new directory
                    //    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + OldPath + "' ");
                    //else                         
                    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + OldPath + "' ");

                    // if directory already exist then get record else create
                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                    {
                        DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();

                        if (!File.Exists(FullPath)) // This is directory
                        {
                            Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                            DirectoryInf.Add("RenamedDate", DateTime.Now.ToString());
                            DirectoryInf.Add("DirectoryPath", FullPath);
                            DirectoryInf.Add("OldName", Path.GetFileName(OldPath));

                            controllerDB.UpdateData("ScannedDirectoryLogs", " DirectoryID ='" + DirectoryIDNew + "' ", DirectoryInf);
                        }
                    }

                }
                else// This is old file renamed 
                {
                    dsTemp = controllerDB.ReadData("ScannedDirectoryLogs", " DirectoryPath = '" + Path.GetDirectoryName(OldPath) + "' ");

                    // if directory already exist then get record else create
                    if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                    {
                        DirectoryIDNew = dsTemp.Tables[0].Rows[0]["DirectoryID"].ToString();

                        if (!File.Exists(OldPath)) // This is directory
                        {
                            Dictionary<String, String> DirectoryInf = new Dictionary<string, string>();
                            DirectoryInf.Add("RenamedDate", DateTime.Now.ToString());
                            DirectoryInf.Add("FileName", Path.GetFileName(FullPath));
                            DirectoryInf.Add("OldName", Path.GetFileName(OldPath));

                            controllerDB.UpdateData("ScannedFileLogs", " DirectoryID ='" + DirectoryIDNew + "' and FileName='" + Path.GetFileName(OldPath) + "' ", DirectoryInf);
                        }
                    }

                }
            }
            catch { }
            MainForm.currentfilescan = "FileSystemWatcher Renamed > " + FullPath;
        }
    }
}
