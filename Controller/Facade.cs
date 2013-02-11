using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NextGenPOSModel;
using Interfaces; // Inkluder namespace for vores model

namespace Controller
{
    public class Facade
    {
        DBFacade dbf;
        DBFacadeCustomer dbfCustomer;

        CashierCollection cashierCollection;
        CustomerCollection customerCollection;

        public Facade()
        {
            dbf = new DBFacade("Data Source=10.165.150.52;Initial Catalog=nextgenPOS;Persist Security Info=True;User ID=dm122;Password=dm122");
            dbf.connectDB();
            dbfCustomer = new DBFacadeCustomer("Data Source=10.165.150.52;Initial Catalog=nextgenPOS;Persist Security Info=True;User ID=dm122;Password=dm122")
            dbfCustomer.connectDB();
            cashierCollection = new CashierCollection();
            Cashier c = new Cashier(42, "Morten", 59000m, "51255919");
            cashierCollection.Add(c);
            CustomerCollection cc = new CustomerCollection();
            //            dbf.closeDB();
            //            dbfCustomer.closeDB();

        }

        public void CreateCashier(string name, decimal salery, string telephone) { 
            ICashier c =  dbf.CreateCashier( name,  salery,  telephone);
            cashierCollection.Add((Cashier) c);
        }

        public void DeleteCashier(ICashier c)
        { 
             // Kald til DB...
            dbf.DeleteCashier(c);
            
            // Opdater model
            cashierCollection.Remove((Cashier) c);
        }

        public void UpdateCashier(int cashier_id, string name,
                       decimal salery, string telephone) { 
          Cashier theCashier;
          
          // Opdater  model
          theCashier = cashierCollection.First(c => c.Cashier_id == cashier_id);
          theCashier.Name = name;
          theCashier.Salery = salery;
          theCashier.Telephone = telephone;

          // Opdatere DB
          dbf.UpdateCashier(cashier_id, name, salery, telephone);
        }

        public void testAfModel() {
            Cashier c = new Cashier(42, "Morten", 59000m, "51255919");
            CashierCollection cc = new CashierCollection();
            cc.Add(c);

            foreach (Cashier tmpc in cc) { 
            }
        }

        public void GrimmeTests() {
            testAfModel();
            dbf = new DBFacade("Data Source=10.165.150.52;Initial Catalog=nextgenPOS;Persist Security Info=True;User ID=dm122;Password=dm122");
            dbf.connectDB();
            //dbf.GetDataTest();
            //dbf.SearchForCashierUglyWay("henning");
            dbf.SearchForCashierBetterWay("henning");
            dbf.closeDB();

        }

        public void CreateCustomer(string firstName, string lastName, string addressLine, string fk_zipCode)
        {
           ICustomer c = dbfCustomer.CreateCustomer(firstName, lastName, addressLine, fk_zipCode);

           customerCollection.Add((Customer)c);
        }
    }
}
