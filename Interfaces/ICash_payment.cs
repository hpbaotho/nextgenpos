using System;

namespace Interfaces
{
   public interface ICash_payment
    {

        int _cashPaymentID { get; }
        decimal _amountTendered { get; set; }
        decimal _cashBack { get; set; }
      
    }
}
