using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextGenPOSModel
{
    public class StoreCollection
    {
        List<Store> listeafstores;

        public StoreCollection() 
        {
            listeafstores = new List<Store>();
        }

        public List<Store> ListeafStores { get; set; }
    }
}