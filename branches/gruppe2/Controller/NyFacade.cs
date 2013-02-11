using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;
using System.Data.SqlClient;

namespace Controller
{
    public class NyFacade
    {
        public SqlConnection dbconn;

        public NyFacade()
        {
            ConnectDB("Data Source=10.165.150.52;Initial Catalog=nextgenPOS;Persist Security Info=True;User ID=dm122;Password=dm122");
        }

        public bool ConnectDB(string connectionString)
        {
            bool result;

            try
            {
                dbconn = new SqlConnection(connectionString);
                dbconn.Open();
                Console.WriteLine("Sql server version " + dbconn.ServerVersion);
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            return result;
        }

        public void CloseDB()
        {
            dbconn.Close();
        }
    }
}
