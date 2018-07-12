using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace Acosta.RealmPOC.Core
{
    public class Visit : RealmObject
    {
        [PrimaryKey]
        public int assignment_number { get; set; }
        public int acosta_store_number { get; set; }
        public int visit_id { get; set; }
        public int cycle_id { get; set; }
        public int platform_id { get; set; }
        public int program_id { get; set; }
        public int ad_number { get; set; }
        public int action_id { get; set; }
        public IList<int> question_id { get; }

        //public Store Store { get; set; }
        //public Cycle Cycle { get; set; }
        //public Platform Platform { get; set; }
        //public Program Program { get; set; }
        //public Advertisement Advertisement { get; set; }
        //public Action Action { get; set; }
        //public IList<Question> Questions { get;  }
    }
}
