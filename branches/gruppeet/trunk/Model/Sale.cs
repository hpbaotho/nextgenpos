﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextGenPOSModel
{
    class Sale
    {
        DateTime dateTime;
        decimal _total;
        List<Cash_payment> cash_paymets = new List<Cash_payment>();

        public decimal GetTotalPrice()
        {
            return _total;
        }

        public bool Pay(string betalings_type,decimal cash_amount)
        {
            decimal cash_back;
            Cash_payment current_cash = new Cash_payment();
            cash_back = current_cash.Cash_payment(cash_amount,this);
            if(cash_back >= 0)
            {
                cash_paymets.Add(current_cash);
                return true;
            }
            return false;
        }
    }
}