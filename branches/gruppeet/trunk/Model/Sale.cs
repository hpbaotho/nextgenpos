using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextGenPOSModel
{
    class Sale
    {
        DateTime dateTime;
        decimal _total;

        public decimal GetTotalPrice()
        {
            return _total;
        }
    }
}
