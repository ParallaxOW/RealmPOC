using Realms;
using System;

namespace Acosta.RealmPOC.Core
{
    public class Cycle : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string CycleNumber { get; set; }
        public string CycleYear { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int? ESP { get; set; }

    }
}
