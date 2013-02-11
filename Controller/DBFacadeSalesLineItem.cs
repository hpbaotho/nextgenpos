using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using NextGenPOSModel;
using Interfaces;

namespace Controller
{
    public class DBFacadeSalesLineItem
    {
        private SqlConnection dbconn;

        public DBFacadeSalesLineItem(SqlConnection dbconn)
        {
            this.dbconn = dbconn;
        }

        public ISalesLineItem CreateSalesLineItem(int quantity, int sale_id, int item_id)
        {
            SqlCommand cmd = new SqlCommand("CreateSalesLineItem", dbconn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter;

            parameter = new SqlParameter("@SalesLineItemId", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@Quantity", SqlDbType.Int);
            parameter.Value = quantity;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@Sale_id", SqlDbType.Int);
            parameter.Value = sale_id;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@Item_id", SqlDbType.Int);
            parameter.Value = item_id;
            cmd.Parameters.Add(parameter);

            cmd.ExecuteNonQuery();

            int salesLineItemId = (int)cmd.Parameters["@SalesLineItemId"].Value;

            ISalesLineItem salesLineItem = new SalesLineItem(salesLineItemId, quantity, sale_id, item_id);

            return salesLineItem;
        }

        public void UpdateSalesLineItem(int salesLineItemId, int quantity, int sale_id, int item_id)
        {
            SqlCommand cmd = new SqlCommand("UpdateSalesLineItem", dbconn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter;

            parameter = new SqlParameter("@SalesLineItemId", SqlDbType.Int);
            parameter.Value = salesLineItemId;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@Quantity", SqlDbType.Int);
            parameter.Value = quantity;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@Sale_id", SqlDbType.Int);
            parameter.Value = sale_id;
            cmd.Parameters.Add(parameter);

            parameter = new SqlParameter("@Item_id", SqlDbType.Int);
            parameter.Value = item_id;
            cmd.Parameters.Add(parameter);

            cmd.ExecuteNonQuery();
        }

        public void DeleteSalesLineItem(ISalesLineItem sli)
        {
            SqlCommand cmd = new SqlCommand("DeleteSalesLineItem", dbconn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter;

            parameter = new SqlParameter("@SalesLineItemId", SqlDbType.Int);
            parameter.Value = sli.Id;
            cmd.Parameters.Add(parameter);

            cmd.ExecuteNonQuery();
        }
        
    }
}
