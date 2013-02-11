using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace NextGenPOSModel
{
    static class Cash_payment : ICash_payment
    {
        decimal cashBack;
        decimal amountTendered;
        int cashPaymentID;

        public decimal Cash_payment(int id,decimal amount_tendered)
        {
            cashPaymentID = id;
            amountTendered = amount_tendered;

            //cashBack = amountTendered-itemPrice;

            return cashBack;
        }
    }
}
