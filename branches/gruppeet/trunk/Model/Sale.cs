using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextGenPOSModel
{
    class Sale
    {
        DateTime dateTime;
        decimal total;
        int sale_id;

        public decimal GetTotalPrice()
        {
            return total;
        }

        public decimal Pay(string betalings_type,decimal cash_amount)
        {
            return Cash_payment.Cash_payment(cash_amount,this);
        }
    }
}
