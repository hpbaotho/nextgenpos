using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface ISalesLineItem
    {
        int Id { get; }
        int Quantity { get; }
        int Sale_Id { get; }
        int Item_Id { get; }
    }
}
