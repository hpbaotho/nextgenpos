using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
  public interface ICustomer
    {
        int Customer_id { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string AdressLine { get; set; }
        string ZipCode { get; set; }
    }
}
