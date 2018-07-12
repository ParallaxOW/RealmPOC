using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace Acosta.RealmPOC.Core
{
    public class Valid_Response : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }
        public string valid_response_text { get; set; }
        public int sequence { get; set; }
    }
}
