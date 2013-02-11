using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
namespace NextGenPOSModel
{
   public class Item : IItem
    {
       int _ItemID;
       int _ItemStoreQuantity;

       public decimal ItemID { get; set; }
       public string ItemStoreQuantity { get; set; }
      

       public Item(int itemID, int itemStoreQuantity)
       {
           _ItemID = itemID;
           _ItemStoreQuantity = itemStoreQuantity;

       }


    }
}
