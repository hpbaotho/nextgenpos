using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data; // Inkluder for DB adgang

using Interfaces; // Adgang til vores egne interfaces
using NextGenPOSModel; // Adgang til modellen

namespace Controller
{
    public class DBFacadeCashier
    { // Jan Writes subversion comment here
        string ConnectionString { get; set; }
        SqlConnection dbconn;

        public DBFacadeCashier(string connectionstring)
        {
            ConnectionString = connectionstring;
        }

        public bool connectDB() {
            bool result;
            
            try
            {
                dbconn = new SqlConnection(ConnectionString);
                dbconn.Open();
                Console.WriteLine("Sql server version " + dbconn.ServerVersion);
                result = true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                result = false;
            }
            return result;
        }

        public void closeDB() {
            dbconn.Close();
        }

        public void SearchForCashier(string searchtext)
        {
            SqlCommand    cmd;     // Bruges til at lave sql commandoer mod DMBMS'et
            SqlDataReader myreader; // Bruges til at få returværdier fra DMBMS'et
            SqlParameter parameter = new SqlParameter("@searchparam", SqlDbType.NVarChar, 30);

            string sqlString = "select * from cashier where lower(name) like '%' + @searchparam + '%'";

            if (searchtext.Length > 30) {
             searchtext = searchtext.Substring(0,30);
            } 
            parameter.Value = searchtext;

            cmd = new SqlCommand(sqlString, dbconn);
            cmd.Parameters.Add(parameter);


            myreader = cmd.ExecuteReader();

            while (myreader.Read())
            {
                Console.Write(myreader["cashier_id"].ToString() + " ");
                Console.Write(myreader["name"].ToString() + " ");
                Console.Write(myreader["salery"].ToString() + " ");
                Console.WriteLine(myreader["telephone"].ToString() + " ");

            }
            myreader.Close();

        }

        public ICashier CreateCashier(string name, decimal salery, string telephone) 
        {
            int cashier_id = -42;

            // Bruges til at lave sql commandoer mod DMBMS'et
            // "createCashier" - Navn på den gemte procedure i DB'en
            SqlCommand cmd = new SqlCommand("createCashier", dbconn);
            cmd.CommandType = CommandType.StoredProcedure; // VIGTIG!!!!
           
            SqlParameter parameter;

            parameter = new SqlParameter("@cashier_id", SqlDbType.Int);
            //parameter.Value = DBNull.Value;
            parameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@name", SqlDbType.NVarChar, 30);
            parameter.Value = name;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@salery", SqlDbType.Decimal);
            parameter.Value = salery;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@telephone", SqlDbType.VarChar, 200);
            parameter.Value = telephone;
            cmd.Parameters.Add(parameter);
            cmd.ExecuteNonQuery();

            cashier_id = (int) cmd.Parameters["@cashier_id"].Value;

            ICashier theCashier = new Cashier(cashier_id, name, salery, telephone);


            //createCashier
            return theCashier;
        }

        public void UpdateCashier(int cashier_id, string name,
                      decimal salery, string telephone) {
            SqlCommand cmd;     // Bruges til at lave sql commandoer mod DMBMS'et
            SqlParameter parameter;
            
            
            string sqlString = "update cashier set name = @name, salery = @salery, telephone = @telephone where cashier_id = @cashier_id";

           

            cmd = new SqlCommand(sqlString, dbconn);

            parameter = new SqlParameter("@cashier_id", SqlDbType.Int);
            parameter.Value = cashier_id;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@name", SqlDbType.NVarChar, 30);
            parameter.Value = name;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@salery", SqlDbType.Decimal);
            parameter.Value = salery;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@telephone", SqlDbType.VarChar, 200);
            parameter.Value = telephone;
            cmd.Parameters.Add(parameter);

            cmd.ExecuteNonQuery();
        }

        public void DeleteCashier(ICashier c)
        {
            // Her skal jeres trylleri være der sletter i DB'EN
            
            SqlCommand cmd = new SqlCommand("DeleteCashier", dbconn);
            cmd.CommandType = CommandType.StoredProcedure; // VIGTIG!!!!

            SqlParameter parameter;
            
            // Slet post med id  c.Cashier_id
            parameter = new SqlParameter("@cashier_id", SqlDbType.Int);
            parameter.Value = c.Cashier_id;
            cmd.Parameters.Add(parameter);

            cmd.ExecuteNonQuery();

           
        }

        public List<ICashier> LoadCashiers()
        {
            List<ICashier> cashiers = new List<ICashier>();

            SqlCommand cmd = new SqlCommand("LoadCashiers", dbconn);
            cmd.CommandType = CommandType.StoredProcedure; // VIGTIG!!!!

          
           

            SqlDataReader myreader = cmd.ExecuteReader();

            while (myreader.Read())
            {
                ICashier c = new Cashier(
                    (int) myreader["cashier_id"],
                    (string) myreader["name"],
                    (decimal) myreader["salery"],
                    (string) myreader["telephone"]);
                cashiers.Add(c);
            }
            myreader.Close();
            return cashiers;
        }

    }
}
