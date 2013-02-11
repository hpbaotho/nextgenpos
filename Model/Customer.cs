using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace NextGenPOSModel
{
   public class Customer : ICustomer
    {
        public int Customer_id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdressLine { get; set; }
        public string ZipCode { get; set; }

        public Customer(int customer_id, string firstName, string lastName, string adressLine, string zipCode)
        {
            Customer_id = customer_id;
            FirstName = firstName;
            LastName = lastName;
            AdressLine = adressLine;
            ZipCode = zipCode;
        }

    }
}
