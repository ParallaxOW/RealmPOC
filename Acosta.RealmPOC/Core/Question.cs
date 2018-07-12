using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace Acosta.RealmPOC.Core
{
    public class Question : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }
        public string question_category { get; set; }
        public string question_type { get; set; }
        public int sequence { get; set; }
        public IList<Valid_Response> valid_responses { get; }
    }
}
