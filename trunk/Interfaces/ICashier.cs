using System;

namespace Interfaces
{
    public interface ICashier
    {
        int Cashier_id {get;}
        string Name { get; set; }
        decimal Salery { get; set; }
        string Telephone { get; set; }
    }
}
