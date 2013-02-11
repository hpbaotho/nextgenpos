using System;

namespace Interfaces
{
   public class ISale
    {

        DateTime _dateTime {get; }
        decimal _total {get; }
        ICash_payment ICash_paymentList { get; }
       

    }
}
