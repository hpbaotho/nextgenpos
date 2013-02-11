using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace NextGenPOSModel
{
    public class SalesLineItem : ISalesLineItem
    {
        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public int Sale_Id { get; private set; }
        public int Item_Id { get; private set; }

        public SalesLineItem(int id, int quantity, int sale_id, int item_id)
        {
            Id = id;
            Quantity = quantity;
            Sale_Id = sale_id;
            Item_Id = item_id;
        }
    }
}
