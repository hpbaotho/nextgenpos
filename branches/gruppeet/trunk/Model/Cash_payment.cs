using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace NextGenPOSModel
{
    static class Cash_payment : ICash_payment
    {
        public static decimal Cash_payment(decimal amount_tendered, Sale sale)
        {
            return amount_tendered - sale.GetTotalPrice();
        }
    }
}
