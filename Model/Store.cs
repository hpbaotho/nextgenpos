using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextGenPOSModel
{
    public class Store
    {
        int storeID, product_catalog_ID;
        string store_name, store_address;

        public Store(int storeid, int productcatID, string storename, string address) 
        {
            this.storeID = storeid;
            this.product_catalog_ID = productcatID;
            this.store_name = storename;
            this.store_address = address;
        }

        public int StoreID { get; set; }
        public int ProductCatalogID { get; set; }
        public string Storename { get; set; }
        public string StoreAddress { get; set; }
    }
}
