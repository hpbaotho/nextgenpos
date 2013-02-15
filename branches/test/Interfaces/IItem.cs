using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IItem
    {
        int ItemID { get; }
        int ItemStoreQuantity { get; set; }

    }
}
