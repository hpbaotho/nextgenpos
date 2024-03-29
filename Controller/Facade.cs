﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NextGenPOSModel;
using Interfaces; // Inkluder namespace for vores model

namespace Controller
{
    public class Facade
    {
        DBFacadeCashier dbf;

        /* Alt for cashiers */
        CashierCollection cashierCollection;
        public ICashier actualCashier {get; set;}

        public Facade()
        {
            dbf = new DBFacadeCashier("Data Source=10.165.150.52;Initial Catalog=nextgenPOS;Persist Security Info=True;User ID=dm122;Password=dm122");
            dbf.connectDB();
            cashierCollection = new CashierCollection();
            Cashier c = new Cashier(42, "Morten", 59000m, "51255919");
            cashierCollection.Add(c);
            //            dbf.closeDB();

        }

        public List<ICashier> LoadCashiers() {
            List<ICashier> cashiers;
            
            cashiers = dbf.LoadCashiers();

            cashierCollection.Clear();

            // Cashier collection i model lag
            cashierCollection.AddRange(cashiers.Cast<Cashier>());

            return cashiers;
        }

        public void CreateCashier(string name, decimal salery, string telephone) { 
            ICashier c =  dbf.CreateCashier( name,  salery,  telephone);
            cashierCollection.Add((Cashier) c);
            actualCashier = c;
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

          actualCashier = theCashier;
           

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
            dbf = new DBFacadeCashier("Data Source=10.165.150.52;Initial Catalog=nextgenPOS;Persist Security Info=True;User ID=dm122;Password=dm122");
            dbf.connectDB();
            //dbf.GetDataTest();
            //dbf.SearchForCashierUglyWay("henning");
            dbf.closeDB();

        }
    }
}
