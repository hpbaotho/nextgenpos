using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    public class Facade
    {
        DBFacade dbf;

        public Facade() {
            dbf = new DBFacade("Data Source=10.165.150.520;Initial Catalog=nextgenPOS;Persist Security Info=True;User ID=dm122;Password=dm122");
            dbf.connectDB();
            dbf.closeDB();

        }
    }
}
