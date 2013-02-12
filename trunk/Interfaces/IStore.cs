using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IStore
    {
        int StoreID { get; set; }
        int ProductCatalogID { get; set; }
        string Storename { get; set; }
        string StoreAddress { get; set; }
    }
}