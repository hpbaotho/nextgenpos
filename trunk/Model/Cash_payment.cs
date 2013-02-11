using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace NextGenPOSModel
{
    public class Cash_payment : ICash_payment
    {
        decimal _cashBack;
        decimal _amountTendered;
        int _cashPaymentID;

        public decimal Cash_payment(decimal amount_tendered, Sale sale)
        {
            _amountTendered = amount_tendered;

            _cashBack = _amountTendered-sale.GetTotalPrice();

            return _cashBack;
        }
    }
}
