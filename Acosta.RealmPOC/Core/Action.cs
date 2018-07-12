using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace Acosta.RealmPOC.Core
{
    public class Action : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }
        public string action_description { get; set; }
    }
}
