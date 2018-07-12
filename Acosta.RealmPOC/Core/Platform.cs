using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acosta.RealmPOC.Core
{
    public class Platform : RealmObject
    {
        [PrimaryKey]
        public int platform_id { get; set; }
        public string platform_name { get; set; }
    }
}
