using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acosta.RealmPOC.Core
{
    public class Advertisement : RealmObject
    {
        [PrimaryKey]
        public int number { get; set; }
        public string ad_description { get; set; }
    }
}
