using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces; // Adgang til egne interfaces

namespace NextGenPOSModel
{
    public class Cashier : ICashier
    {

        //public int Cashier_id
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public string Name
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public decimal Salery
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public string Telephone
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public int Cashier_id { get; private set; }
        public string Name { get; set; }
        public decimal Salery { get; set; }
        public string Telephone { get; set; }

        public Cashier(int cashier_id, string name, 
                       decimal salery, string telephone) {
                           Cashier_id = cashier_id;
                           Name = name;
                           Salery = salery;
                           Telephone = telephone;
        } 
    }
}
