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
        List<Cash_payment> cash_payments = new List<Cash_payment>();

        public decimal GetTotalPrice()
        {
            return _total;
        }

        public decimal Pay(string betalings_type,decimal cash_amount)
        {
            decimal cash_back;
            Cash_payment current_cash = new Cash_payment();
            cash_back = current_cash.Cash_payment(cash_amount,this);
            cash_payments.Add(current_cash);
            return cash_back;
        }
    }
}
