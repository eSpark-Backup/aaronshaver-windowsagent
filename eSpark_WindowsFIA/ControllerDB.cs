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
                String connStr = "Data Source=" + (Form1.logfilePath + "\\eSpark_FIA.sqlite").Replace("\\\\","\\")+";version=3";
                connectString = new SQLiteConnection(connStr);

                if (connectString.State != ConnectionState.Open)
                    connectString.Open();
            }
            catch (Exception ee)
            {
                Form1.loger.Log(LogLevel.Trace, " Database connection error::" + ee.Message);
            }
        }

        public bool CheckRecordExistManual(string ManualQuery)
        {
            try
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
                connectString.Close();

                return dt_temp.Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Form1.loger.Log(LogLevel.Trace, " Database existRecordManual::" + ex.Message);
            }
            return false;
        }


        public DataSet ReadData(string TableName, string whereclause)
        {
            try
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
                connectString.Close();

                return ds;
            }
            catch (Exception ex)
            {
                Form1.loger.Log(LogLevel.Trace, " Database ReadData::" + ex.Message);
                connectString.Close();
                //MessageBox.Show(ex.Message);
            }
            return null;
        }

        public bool DeleteData(string TableName, string whereclause)
        {
            try
            {
                if (connectString.State != ConnectionState.Open)
                    connectString.Open();

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
                connectString.Close();

                return true;
            }
            catch (Exception ex)
            {
                Form1.loger.Log(LogLevel.Trace, " Database DeleteData::" + ex.Message);
            }
            return false;
        }

        public bool UpdateData(string TableName, string whereclause, Dictionary<string, string> parms)
        {
            try
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
                connectString.Close();

                return true;
            }
            catch (Exception ex)
            {
                Form1.loger.Log(LogLevel.Trace, " Database UpdateData::" + ex.Message);
            }
            return false;
        }

        public bool InsertOnlyData(string TableName, string whereclause, Dictionary<string, string> parms)
        {
            try
            {
                if (connectString == null || connectString.State != ConnectionState.Open)
                    InitializeFlexMoldDB();

                if (connectString.State != ConnectionState.Open)
                    connectString.Open();
                cmd = new SQLiteCommand();
                String sqlQuery = "";

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
                connectString.Close();

                return true;
            }
            catch (Exception ex)
            {
                Form1.loger.Log(LogLevel.Trace, " Database InsertOnly::" + ex.Message);
                //MessageBox.Show(ex.Message);
            }
            return false;
        }


        public bool InsertOrUpdateData(string TableName, string whereclause, Dictionary<string, string> parms)
        {
            try
            {
                if (connectString == null || connectString.State != ConnectionState.Open)
                    InitializeFlexMoldDB();

                if (connectString.State != ConnectionState.Open)
                    connectString.Open();
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
                connectString.Close();

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
                    connectString.Close();

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
                    connectString.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Form1.loger.Log(LogLevel.Trace, " Database InsertOrUpdate::" + ex.Message);
                //MessageBox.Show(ex.Message);
            }
            return false;
        }


    }
}
