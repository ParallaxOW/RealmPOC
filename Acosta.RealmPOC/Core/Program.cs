using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace Acosta.RealmPOC.Core
{
    public class Program : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }
        public string program_description { get; set; }
    }
}
