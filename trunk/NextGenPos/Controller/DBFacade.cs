using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient; // Inkluder for DB adgang

namespace Controller
{
    public class DBFacade
    {
        string ConnectionString { get; set; }
        SqlConnection dbconn;

        public DBFacade(string connectionstring)
        {
            ConnectionString = connectionstring;
        }

        public void connectDB() {
            dbconn = new SqlConnection(ConnectionString);
            dbconn.Open();
            Console.WriteLine("Sql server version " + dbconn.ServerVersion);
        }

        public void closeDB() {
            dbconn.Close();
        }


    }
}
