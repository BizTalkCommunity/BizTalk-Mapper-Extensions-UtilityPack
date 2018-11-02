using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace BizTalk.Database.Functoids
{
    class AdvDBFunctoidHelper
    {
        private string where;
        private OleDbConnection conn = new OleDbConnection();
        private string connectionString;
        private string error;
        private Hashtable mapValues = new Hashtable();
        private string table;

        public string Where
        {
            get
            {
                return this.where;
            }
            set
            {
                this.where = value;
            }
        }

        public OleDbConnection Connection =>
            this.conn;

        public string ConnectionString
        {
            get
            {
                return this.connectionString;
            }
            set
            {
                this.connectionString = value;
            }
        }

        public string Error
        {
            get
            {
                return this.error;
            }
            set
            {
                this.error = value;
            }
        }

        public Hashtable MapValues =>
            this.mapValues;

        public string Table
        {
            get
            {
                return this.table;
            }
            set
            {
                this.table = value;
            }
        }
    }
}
