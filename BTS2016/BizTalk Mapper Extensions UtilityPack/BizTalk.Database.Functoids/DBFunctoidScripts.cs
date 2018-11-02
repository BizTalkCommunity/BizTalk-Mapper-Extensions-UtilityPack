using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BizTalk.Database.Functoids
{
    [ComVisible(false)]
    public sealed class DBFunctoidScripts
    {
        [ThreadStatic]
        private static Hashtable myDBFunctoidHelperList;

        public string AdvDBErrorExtract(int index)
        {
            string error = "";
            AdvInitDBFunctoidHelperList();
            try
            {
                if (myDBFunctoidHelperList.Contains(index))
                {
                    AdvDBFunctoidHelper helper = (AdvDBFunctoidHelper)myDBFunctoidHelperList[index];
                    if (helper != null)
                        error = helper.Error;
                }
            }
            catch (Exception)
            {
            }
            if (error == null)
                error = "";
            return error;
        }

        public string AdvDBLookup(string connectionString, string table, string where)
        {
            return AdvDBLookup(0, connectionString, table, where);
        }

        public string AdvDBLookup(int index, string connectionString, string table, string where)
        {
            AdvDBFunctoidHelper helper = null;
            bool flag = false;
            AdvInitDBFunctoidHelperList();
            if (!myDBFunctoidHelperList.Contains(index))
            {
                helper = new AdvDBFunctoidHelper();
                myDBFunctoidHelperList.Add(index, helper);
            }
            else
            {
                helper = (AdvDBFunctoidHelper)myDBFunctoidHelperList[index];
            }
            try
            {
                if (((helper.ConnectionString == null) || ((helper.ConnectionString != null) && (string.Compare(helper.ConnectionString, connectionString, StringComparison.Ordinal) != 0))) || (helper.Connection.State != ConnectionState.Open))
                {
                    flag = true;
                    helper.MapValues.Clear();
                    helper.Error = "";
                    if (helper.Connection.State == ConnectionState.Open)
                    {
                        helper.Connection.Close();
                    }
                    helper.ConnectionString = connectionString;
                    helper.Connection.ConnectionString = connectionString;
                    helper.Connection.Open();
                }
                if ((flag || (string.Compare(helper.Table, table, StringComparison.Ordinal) != 0)) || (((string.Compare(helper.Where, where, StringComparison.OrdinalIgnoreCase) != 0)) || ((helper.Error != null) && (helper.Error.Length > 0))))
                {
                    helper.Table = table;
                    helper.Where = where;
                    helper.MapValues.Clear();
                    helper.Error = "";
                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM " + table + " WHERE " + where, helper.Connection))
                    {
                        IDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string str = reader.GetName(i).ToLower(CultureInfo.InvariantCulture);
                                object obj2 = reader.GetValue(i);
                                helper.MapValues[str] = obj2;
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (OleDbException exception)
            {
                if (exception.Errors.Count > 0)
                {
                    helper.Error = exception.Errors[0].Message;
                }
            }
            catch (Exception exception2)
            {
                helper.Error = exception2.Message;
            }
            finally
            {
                if (helper.Connection.State == ConnectionState.Open)
                {
                    helper.Connection.Close();
                }
            }
            return index.ToString(CultureInfo.InvariantCulture);
        }

        public string AdvDBLookupShutdown() =>
            string.Empty;

        public string AdvDBValueExtract(int index, string columnName)
        {
            string str = "";
            AdvInitDBFunctoidHelperList();
            if (myDBFunctoidHelperList.Contains(index) && !string.IsNullOrEmpty(columnName))
            {
                AdvDBFunctoidHelper helper = (AdvDBFunctoidHelper)myDBFunctoidHelperList[index];
                columnName = columnName.ToLower(CultureInfo.InvariantCulture);
                object obj2 = helper.MapValues[columnName];
                if (obj2 != null)
                {
                    str = obj2.ToString();
                }
            }
            return str;
        }

        private static void AdvInitDBFunctoidHelperList()
        {
            if (myDBFunctoidHelperList == null)
            {
                myDBFunctoidHelperList = new Hashtable();
            }
        }
    }
}
