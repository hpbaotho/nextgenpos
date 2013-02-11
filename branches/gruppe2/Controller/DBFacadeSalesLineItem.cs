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
            cmd.CommandType =CommandType.StoredProcedure;

            SqlParameter parameter;

            parameter = new SqlParameter("@SaleLineItemId", SqlDbType.Int);
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

            int saleLineItemId = (int)cmd.Parameters["@SaleLineItemId"].Value;

            ISalesLineItem salesLineItem = new SalesLineItem(saleLineItemId, quantity, sale_id, item_id);

            return salesLineItem;
        }
    }
}
