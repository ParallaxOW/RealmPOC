using System;
using System.Collections.Generic;
using System.Text;
using Realms;
namespace Acosta.RealmPOC.Core
{
    public class Store : RealmObject
    {
        [PrimaryKey]
        public int AcostaNumber { get; set; }
        public string TDLINX { get; set; }
        public string StoreName { get; set; }
        public string StoreNumber { get; set; }
        public string StoreAddress { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public string StoreZip { get; set; }
        public string StorePhone { get; set; }
        public double StoreLat { get; set; }
        public double StoreLon { get; set; }

    }
}
