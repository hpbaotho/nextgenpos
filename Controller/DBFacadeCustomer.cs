using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Interfaces;
using NextGenPOSModel;

namespace Controller
{
    class DBFacadeCustomer
    {
        string ConnectionString { get; set; }
        SqlConnection dbconn;

        public DBFacadeCustomer(string connectionstring)
        {
            ConnectionString = connectionstring;
        }

        public bool connectDB()
        {
            bool result;

            try
            {
                dbconn = new SqlConnection(ConnectionString);
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

        public ICustomer CreateCustomer(string firstName, string lastName, string addressLine, string fk_zipCode)
        {
            int customer_id = 10;
            // Bruges til at lave sql commandoer mod DMBMS'et
            // "CreateCustomer" - Navn på den gemte procedure i DB'en
            SqlCommand cmd = new SqlCommand("CreateCustomer", dbconn);
            cmd.CommandType = CommandType.StoredProcedure; // VIGTIG!!!!

            SqlParameter parameter;

            parameter = new SqlParameter("@customer_id", SqlDbType.Int);
            //parameter.Value = DBNull.Value;
            parameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@firstName", SqlDbType.NVarChar, 50);
            parameter.Value = firstName;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@lastName", SqlDbType.NVarChar, 50);
            parameter.Value = lastName;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@adressLine", SqlDbType.NVarChar, 60);
            parameter.Value = addressLine;
            cmd.Parameters.Add(parameter);


            parameter = new SqlParameter("@zipCode", SqlDbType.NVarChar, 15);
            parameter.Value = fk_zipCode;
            cmd.Parameters.Add(parameter);
            cmd.ExecuteNonQuery();

            customer_id = (int)cmd.Parameters["@customerID"].Value;


            Customer theCustomer = new Customer(customer_id, firstName, lastName, addressLine, fk_zipCode);

            //CreateCustomer
            return (ICustomer)theCustomer;
        }
    }
}
