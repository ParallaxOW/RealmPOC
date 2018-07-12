using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace Acosta.RealmPOC.Core
{
    public class Conditions : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }
        public string condition_description { get; set; }
    }
}
