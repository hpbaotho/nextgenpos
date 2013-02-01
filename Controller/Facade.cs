using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NextGenPOSModel; // Inkluder namespace for vores model

namespace Controller
{
    public class Facade
    {
        DBFacade dbf;

        CashierCollection cashierCollection;

        public Facade()
        {
            dbf = new DBFacade("Data Source=10.165.150.52;Initial Catalog=nextgenPOS;Persist Security Info=True;User ID=dm122;Password=dm122");
            dbf.connectDB();
            cashierCollection = new CashierCollection();
            Cashier c = new Cashier(42, "Morten", 59000m, "51255919");
            cashierCollection.Add(c);
            //            dbf.closeDB();

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
          dbf.
        }

        public void testAfModel() {
            Cashier c = new Cashier(42, "Morten", 59000m, "51255919");
            CashierCollection cc = new CashierCollection();
            cc.Add(c);

            foreach (Cashier tmpc in cc) { 
            }
        }

        public GrimmeTests() {
            testAfModel();
            dbf = new DBFacade("Data Source=10.165.150.52;Initial Catalog=nextgenPOS;Persist Security Info=True;User ID=dm122;Password=dm122");
            dbf.connectDB();
            //dbf.GetDataTest();
            //dbf.SearchForCashierUglyWay("henning");
            dbf.SearchForCashierBetterWay("henning");
            dbf.closeDB();

        }
    }
}
