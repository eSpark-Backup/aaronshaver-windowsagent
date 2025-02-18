using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Threading;
using NLog;
using MetroSet_UI.Forms;

namespace eSpark_WindowsFIA
{
    public class ControllerDB
    {

        public static SQLiteConnection connectString;
        public static SQLiteCommand cmd;
        public static SQLiteDataAdapter adapter;
        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();

        public void InitializeFlexMoldDB()
        {
            try
            {
                //String connStr = "Data Source=" + Directory.GetCurrentDirectory() + "\\eSpark_FIA.sqlite;version=3";
                String connStr = "Data Source=" + (MainForm.logfilePath + "\\eSpark_FIA.sqlite").Replace("\\\\","\\")+";version=3";

                if(connectString==null)
                    connectString = new SQLiteConnection(connStr);

                if (connectString.State != ConnectionState.Open)
                    connectString.Open();

            }
            catch (Exception ee)
            {
                MainForm.loger.Log(LogLevel.Trace, " Database connection error::" + ee.Message);
            }
        }

        public bool CheckRecordExistManual(string ManualQuery)
        {
            try
            {
                lock (MainForm.lockwait)
                {
                    if (connectString == null || connectString.State != ConnectionState.Open)
                        InitializeFlexMoldDB();

                    cmd = new SQLiteCommand();
                    //String sql = "";
                    //if (whereclause != null && whereclause.Length > 1)
                    //    sql = "SELECT * FROM " + TableName + " where " + whereclause;
                    //else
                    //    sql = "SELECT * FROM " + TableName;

                    adapter = new SQLiteDataAdapter(ManualQuery, connectString);
                    DataTable dt_temp = new DataTable();

                    adapter.Fill(dt_temp);
                    try
                    {
                        if (connectString.State != ConnectionState.Closed) connectString.Close();
                    }
                    catch { }


                    return dt_temp.Rows.Count > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                MainForm.loger.Log(LogLevel.Trace, " Database existRecordManual::" + ex.Message);
            }
            return false;
        }

        public object SingleRecordManually(string ManualQuery)
        {
            try
            {
                lock (MainForm.lockwait)
                {
                    if (connectString == null || connectString.State != ConnectionState.Open)
                        InitializeFlexMoldDB();

                    cmd = new SQLiteCommand();
                    //String sql = "";
                    //if (whereclause != null && whereclause.Length > 1)
                    //    sql = "SELECT * FROM " + TableName + " where " + whereclause;
                    //else
                    //    sql = "SELECT * FROM " + TableName;

                    adapter = new SQLiteDataAdapter(ManualQuery, connectString);
                    DataTable dt_temp = new DataTable();

                    adapter.Fill(dt_temp);
                    try
                    {
                        if (connectString.State != ConnectionState.Closed) connectString.Close();
                    }
                    catch { }

                    if(dt_temp.Rows.Count > 0)
                        return dt_temp.Rows[0][0];

                }
            }
            catch (Exception ex)
            {
                MainForm.loger.Log(LogLevel.Trace, " Database existRecordManual::" + ex.Message);
            }
            return 0;
        }


        public DataSet ReadData(string TableName, string whereclause)
        {
            try
            {
                lock (MainForm.lockwait)
                {
                    if (connectString == null || connectString.State != ConnectionState.Open)
                        InitializeFlexMoldDB();

                    //if (connectString.State != ConnectionState.Open)
                    //    connectString.Open();
                    cmd = new SQLiteCommand();
                    String sql = "";
                    if (whereclause != null && whereclause.Length > 1)
                        sql = "SELECT * FROM " + TableName + " where " + whereclause;
                    else
                        sql = "SELECT * FROM " + TableName;

                    adapter = new SQLiteDataAdapter(sql, connectString);
                    ds.Reset();
                    adapter.Fill(ds);
                    try
                    {
                        if (connectString.State != ConnectionState.Closed) connectString.Close();
                    }
                    catch { }


                    return ds;
                }
            }
            catch (Exception ex)
            {
                MainForm.loger.Log(LogLevel.Trace, " Database ReadData::" + ex.Message);
                try
                {
                    if (connectString.State != ConnectionState.Closed) connectString.Close();
                }
                catch { }

                //MessageBox.Show(ex.Message);
            }
            return null;
        }

        public bool DeleteData(string TableName, string whereclause)
        {
            try
            {
                lock (MainForm.lockwait)
                {
                    if (connectString == null || connectString.State != ConnectionState.Open)
                        InitializeFlexMoldDB();

                    cmd = new SQLiteCommand();
                    String sql = "";
                    if (whereclause != null && whereclause.Length > 1)
                        sql = "Delete from " + TableName + " where " + whereclause;
                    else
                        sql = "Delete from " + TableName;

                    adapter = new SQLiteDataAdapter(sql, connectString);
                    ds.Reset();
                    adapter.Fill(ds);
                    //dt = ds.Tables[0];
                    try
                    {
                        if (connectString.State != ConnectionState.Closed) connectString.Close();
                    }
                    catch { }


                    return true;
                }
            }
            catch (Exception ex)
            {
                MainForm.loger.Log(LogLevel.Trace, " Database DeleteData::" + ex.Message);
            }
            return false;
        }

        public bool UpdateData(string TableName, string whereclause, Dictionary<string, string> parms)
        {
            try
            {
                String parasStr = "";

                lock (MainForm.lockwait)
                {
                    if (connectString == null || connectString.State != ConnectionState.Open)
                        InitializeFlexMoldDB();


                    foreach (KeyValuePair<string, string> entry in parms)
                    {
                        parasStr += entry.Key + "='" + entry.Value + "' ";
                        parasStr += " , ";
                    }
                    parasStr = parasStr.Remove(parasStr.Length - 2);

                    if (connectString.State != ConnectionState.Open)
                        connectString.Open();

                    cmd = new SQLiteCommand();
                    String sql = "";
                    if (whereclause != null && whereclause.Length > 1)
                        sql = "UPDATE " + TableName + " SET " + parasStr + " where " + whereclause;
                    else
                        sql = "UPDATE " + TableName + " SET " + parasStr;

                    adapter = new SQLiteDataAdapter(sql, connectString);
                    ds.Reset();
                    adapter.Fill(ds);
                    //dt = ds.Tables[0];
                    try
                    {
                        if (connectString.State != ConnectionState.Closed) connectString.Close();
                    }
                    catch { }
                }

                return true;
            }
            catch (Exception ex)
            {
                MainForm.loger.Log(LogLevel.Trace, " Database UpdateData::" + ex.Message);
            }
            return false;
        }

        public bool InsertOnlyData(string TableName, string whereclause, Dictionary<string, string> parms)
        {
            try
            {
                lock (MainForm.lockwait)
                {

                    if (connectString == null || connectString.State != ConnectionState.Open)
                        InitializeFlexMoldDB();

                    if (connectString.State != ConnectionState.Open)
                        connectString.Open();
                    cmd = new SQLiteCommand();

                    //if record exist then update it else insert it
                    String parasStrKeys = "";
                    String parasStrVals = "";

                    foreach (KeyValuePair<string, string> entry in parms)
                    {
                        parasStrKeys += "" + entry.Key + "";
                        parasStrKeys += " , ";

                        parasStrVals += "'" + entry.Value + "'";
                        parasStrVals += " , ";
                    }

                    parasStrKeys = parasStrKeys.Remove(parasStrKeys.Length - 2);
                    parasStrVals = parasStrVals.Remove(parasStrVals.Length - 2);


                    cmd = new SQLiteCommand();
                    String sql = "";
                    sql = "INSERT INTO " + TableName + " (" + parasStrKeys + ") values( " + parasStrVals + ") ";

                    adapter = new SQLiteDataAdapter(sql, connectString);
                    ds.Reset();
                    adapter.Fill(ds);
                    try
                    {
                        if (connectString.State != ConnectionState.Closed) connectString.Close();
                    }
                    catch { }
                }


                return true;
            }
            catch (Exception ex)
            {
                MainForm.loger.Log(LogLevel.Trace, " Database InsertOnly::" + ex.Message);
                //MessageBox.Show(ex.Message);
            }
            return false;
        }

        //public bool InsertOnlyBulkData(string TableName, List<Dictionary<int, string>> whereclause, List<Dictionary<string, string>> parms)
        //public async Task InsertOnlyBulkImport(string TableName,string ImportFileName, List<String> parms)
        public bool InsertOnlyBulkImport(string TableName, string ImportFileName, List<String> parms)
        {
            System.IO.File.WriteAllLines(MainForm.logfilePath+"\\"+ImportFileName, parms); try {


                //var name = "PATH";
                //var scope = EnvironmentVariableTarget.Machine; // or User
                //var oldValue = Environment.GetEnvironmentVariable(name, scope);
                //if (!oldValue.Contains(Path.GetDirectoryName(Application.ExecutablePath)))
                //{
                //    var newValue = oldValue + Path.GetDirectoryName(Application.ExecutablePath);
                //    Environment.SetEnvironmentVariable(name, newValue, scope);
                //}

                ExecuteCommand("echo .import " + MainForm.logfilePath + "\\" + ImportFileName + " " + TableName + " | "+ MainForm.logfilePath + "\\sqlite3.exe " + MainForm.logfilePath + "\\eSpark_FIA.sqlite",TableName );

                System.IO.File.Delete(MainForm.logfilePath + "\\" + ImportFileName);
            }
            catch (Exception ee) { }
            return true;
        }
        
        private void ExecuteCommand(String command, String TableName)
        {
            Process p = new Process();
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = @"/c " + command; // cmd.exe spesific implementation
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;

            MainForm.outputResultsDB = "";
            MainForm.outputResultsErr = "";
            int errcnt = 0;

            p.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                MainForm.outputResultsDB += e.Data+Environment.NewLine;
                MainForm.currentfilescan = " Please wait, while database is updating..........."+ e.Data;
            });
            p.ErrorDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                MainForm.outputResultsErr += e.Data+Environment.NewLine;
                MainForm.currentfilescan = " Please wait, while database is updating..........." + e.Data;
                errcnt++;
            });           

            p.Start();

            p.BeginOutputReadLine();
            p.BeginErrorReadLine();

            p.WaitForExit();

            if (errcnt > 2)
            {
                MetroSetMessageBox.Show(Dashboard.mainForm, "Errors occured while updating database>>>"+ MainForm.outputResultsErr, "Upload database errors occured.........", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public bool InsertOnlyBulkData(string TableName, List<Dictionary<string, string>> parms)
        {
            try
            {
                lock (MainForm.lockwait)
                {

                    if (connectString == null || connectString.State != ConnectionState.Open)
                        InitializeFlexMoldDB();

                    cmd = new SQLiteCommand();

                    //if record exist then update it else insert it
                    String parasStrKeys = "";
                    String parasStrVals = "";
                    String sql = "";// "BEGIN; ";
                    int SQLCounter = 0;

                    foreach (Dictionary<string, string> fileRecord in parms)
                    {
                        parasStrKeys = "";
                        parasStrVals = "";

                        foreach (KeyValuePair<string, string> entry in fileRecord)
                        {
                            parasStrKeys += "" + entry.Key + "";
                            parasStrKeys += " , ";

                            parasStrVals += "'" + entry.Value + "'";
                            parasStrVals += " , ";
                        }
                        parasStrKeys = parasStrKeys.Remove(parasStrKeys.Length - 2);
                        parasStrVals = parasStrVals.Remove(parasStrVals.Length - 2);

                        sql += "INSERT INTO " + TableName + " (" + parasStrKeys + ") values( " + parasStrVals + "); ";
                        SQLCounter++;
                        MainForm.currentfilescan = " Updating Database::: " + parasStrVals;
                        if (SQLCounter > 10000)
                        {
                            //sql += " END;";
                            cmd = new SQLiteCommand();

                            adapter = new SQLiteDataAdapter(sql, connectString);
                            ds.Reset();
                            adapter.Fill(ds);
                            sql = "";//" BEGIN;";
                            SQLCounter = 0;
                        }
                    }

                    //sql += " END;";

                    if (sql.Length > 10)
                    {
                        cmd = new SQLiteCommand();

                        adapter = new SQLiteDataAdapter(sql, connectString);
                        ds.Reset();
                        adapter.Fill(ds);
                    }
                    try
                    {
                        if (connectString.State != ConnectionState.Closed) connectString.Close();
                    }
                    catch { }
                }


                return true;
            }
            catch (Exception ex)
            {
                MainForm.loger.Log(LogLevel.Trace, " Database InsertOnly::" + ex.Message);
                //MessageBox.Show(ex.Message);
            }
            return false;
        }

        public bool InsertOrUpdateData(string TableName, string whereclause, Dictionary<string, string> parms)
        {
            try
            {
                lock (MainForm.lockwait)
                {

                    if (connectString == null || connectString.State != ConnectionState.Open)
                        InitializeFlexMoldDB();

                    cmd = new SQLiteCommand();
                    String sqlQuery = "";
                    if (whereclause != null && whereclause.Length > 1)
                        sqlQuery = "SELECT * FROM " + TableName + " where " + whereclause;
                    else
                        sqlQuery = "SELECT * FROM " + TableName;

                    adapter = new SQLiteDataAdapter(sqlQuery, connectString);
                    ds.Reset();
                    adapter.Fill(ds);
                    //dt = ds.Tables[0];
                    //dataGridView1.DataSource = dt;
                    try
                    {
                        if (connectString.State != ConnectionState.Closed) connectString.Close();
                    }
                    catch { }


                    //if record exist then update it else insert it
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        String parasStr = "";

                        foreach (KeyValuePair<string, string> entry in parms)
                        {
                            parasStr += entry.Key + "='" + entry.Value + "' ";
                            parasStr += " , ";
                        }
                        parasStr = parasStr.Remove(parasStr.Length - 2);

                        if (connectString.State != ConnectionState.Open)
                            connectString.Open();

                        cmd = new SQLiteCommand();
                        String sql = "";
                        if (whereclause != null && whereclause.Length > 1)
                            sql = "UPDATE " + TableName + " SET " + parasStr + " where " + whereclause;
                        else
                            sql = "UPDATE " + TableName + " SET " + parasStr;

                        adapter = new SQLiteDataAdapter(sql, connectString);
                        ds.Reset();
                        adapter.Fill(ds);
                        //dt = ds.Tables[0];
                        //dataGridView1.DataSource = dt;
                        try
                        {
                            if (connectString.State != ConnectionState.Closed) connectString.Close();
                        }
                        catch { }


                        return true;
                    }
                    else
                    { //insert data
                        String parasStrKeys = "";
                        String parasStrVals = "";

                        foreach (KeyValuePair<string, string> entry in parms)
                        {
                            parasStrKeys += "" + entry.Key + "";
                            parasStrKeys += " , ";

                            parasStrVals += "'" + entry.Value + "'";
                            parasStrVals += " , ";
                        }

                        parasStrKeys = parasStrKeys.Remove(parasStrKeys.Length - 2);
                        parasStrVals = parasStrVals.Remove(parasStrVals.Length - 2);

                        if (connectString.State != ConnectionState.Open)
                            connectString.Open();

                        cmd = new SQLiteCommand();
                        String sql = "";
                        //if (whereclause != null && whereclause.Length > 1)
                        sql = "INSERT INTO " + TableName + " (" + parasStrKeys + ") values( " + parasStrVals + ") ";
                        //else
                        //    sql = "UPDATE " + TableName + " SET " + parasStr;

                        adapter = new SQLiteDataAdapter(sql, connectString);
                        ds.Reset();
                        adapter.Fill(ds);
                        //dt = ds.Tables[0];
                        //dataGridView1.DataSource = dt;
                        try
                        {
                            if (connectString.State != ConnectionState.Closed) connectString.Close();
                        }
                        catch { }


                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MainForm.loger.Log(LogLevel.Trace, " Database InsertOrUpdate::" + ex.Message);
                //MessageBox.Show(ex.Message);
            }
            return false;
        }


    }
}
