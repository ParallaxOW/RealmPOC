using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acosta.RealmPOC.Core;
using Newtonsoft.Json;
using Realms;

namespace Acosta.RealmPOC.Services
{
    public class CycleService
    {
        private Realm realm;

        
        public CycleService()
        {
            realm = Realm.GetInstance();
        }

        public IQueryable<Cycle> GetAllCycles()
        {
            var cycles = realm.All<Cycle>();
            return cycles;
        }

        public Cycle GetCycleById(int cycleId)
        {
            var result = realm.All<Cycle>().Where(c => c.Id == cycleId).FirstOrDefault();
            return result;
        }

        public void LoadCycles()
        {
            string cycleJSONString = "[";
            cycleJSONString += "{\"Id\":\"22\",\"CycleYear\":\"2018\",\"CycleNumber\":\"03\",\"ESP\":\"0\",\"StartDate\":\"2018-07-08T00:00:00\",\"EndDate\":\"2018-07-14T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"24\",\"CycleYear\":\"2018\",\"CycleNumber\":\"01\",\"ESP\":\"0\",\"StartDate\":\"2018-06-13T00:00:00\",\"EndDate\":\"2018-06-14T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"25\",\"CycleYear\":\"2018\",\"CycleNumber\":\"02\",\"ESP\":\"0\",\"StartDate\":\"2018-06-15T00:00:00\",\"EndDate\":\"2018-06-16T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"26\",\"CycleYear\":\"2018\",\"CycleNumber\":\"32\",\"ESP\":\"2\",\"StartDate\":\"2018-07-10T00:00:00\",\"EndDate\":\"2018-07-14T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"27\",\"CycleYear\":\"2018\",\"CycleNumber\":\"31\",\"ESP\":\"1\",\"StartDate\":\"2018-07-09T00:00:00\",\"EndDate\":\"2018-07-14T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"28\",\"CycleYear\":\"2017\",\"CycleNumber\":\"01\",\"ESP\":\"0\",\"StartDate\":\"2017-01-01T00:00:00\",\"EndDate\":\"2017-01-28T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"29\",\"CycleYear\":\"2017\",\"CycleNumber\":\"02\",\"ESP\":\"0\",\"StartDate\":\"2017-02-01T00:00:00\",\"EndDate\":\"2017-02-28T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"30\",\"CycleYear\":\"2017\",\"CycleNumber\":\"03\",\"ESP\":\"0\",\"StartDate\":\"2017-03-01T00:00:00\",\"EndDate\":\"2017-03-31T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"31\",\"CycleYear\":\"2017\",\"CycleNumber\":\"35\",\"ESP\":\"0\",\"StartDate\":\"2017-12-04T00:00:00\",\"EndDate\":\"2017-12-30T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"32\",\"CycleYear\":\"2017\",\"CycleNumber\":\"25\",\"ESP\":\"0\",\"StartDate\":\"2017-11-05T00:00:00\",\"EndDate\":\"2017-12-02T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"33\",\"CycleYear\":\"2017\",\"CycleNumber\":\"15\",\"ESP\":\"0\",\"StartDate\":\"2017-10-08T00:00:00\",\"EndDate\":\"2017-11-04T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"34\",\"CycleYear\":\"2017\",\"CycleNumber\":\"05\",\"ESP\":\"0\",\"StartDate\":\"2017-09-10T00:00:00\",\"EndDate\":\"2017-10-07T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"35\",\"CycleYear\":\"2017\",\"CycleNumber\":\"51\",\"ESP\":\"1\",\"StartDate\":\"2017-09-17T00:00:00\",\"EndDate\":\"2017-09-23T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"36\",\"CycleYear\":\"2018\",\"CycleNumber\":\"95\",\"ESP\":\"0\",\"StartDate\":\"2018-04-01T00:00:00\",\"EndDate\":\"2018-04-28T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"37\",\"CycleYear\":\"2017\",\"CycleNumber\":\"52\",\"ESP\":\"0\",\"StartDate\":\"2017-09-24T00:00:00\",\"EndDate\":\"2017-09-30T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"38\",\"CycleYear\":\"2018\",\"CycleNumber\":\"96\",\"ESP\":\"0\",\"StartDate\":\"2018-04-08T00:00:00\",\"EndDate\":\"2018-05-05T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"39\",\"CycleYear\":\"2018\",\"CycleNumber\":\"97\",\"ESP\":\"0\",\"StartDate\":\"2018-04-15T00:00:00\",\"EndDate\":\"2018-05-12T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"40\",\"CycleYear\":\"2018\",\"CycleNumber\":\"98\",\"ESP\":\"0\",\"StartDate\":\"2018-04-22T00:00:00\",\"EndDate\":\"2018-05-19T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"41\",\"CycleYear\":\"2018\",\"CycleNumber\":\"10\",\"ESP\":\"0\",\"StartDate\":\"2018-04-01T00:00:00\",\"EndDate\":\"2018-04-30T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"42\",\"CycleYear\":\"2018\",\"CycleNumber\":\"11\",\"ESP\":\"0\",\"StartDate\":\"2018-05-01T00:00:00\",\"EndDate\":\"2018-05-31T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"43\",\"CycleYear\":\"2018\",\"CycleNumber\":\"12\",\"ESP\":\"0\",\"StartDate\":\"2018-06-01T00:00:00\",\"EndDate\":\"2018-06-30T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"49\",\"CycleYear\":\"2016\",\"CycleNumber\":\"01\",\"ESP\":\"0\",\"StartDate\":\"2016-01-01T00:00:00\",\"EndDate\":\"2016-01-31T00:00:00\"},";
            cycleJSONString += "{\"Id\":\"50\",\"CycleYear\":\"2016\",\"CycleNumber\":\"02\",\"ESP\":\"0\",\"StartDate\":\"2016-02-01T00:00:00\",\"EndDate\":\"2016-02-29T00:00:00\"}";
            cycleJSONString += "]";

            List<Cycle> cycles = JsonConvert.DeserializeObject<List<Cycle>>(cycleJSONString);

            cycles.ForEach(x => {
                using (var transaction = realm.BeginWrite())
                {
                    realm.Add(new Cycle()
                    {
                        Id = x.Id,
                        CycleNumber = x.CycleNumber,
                        CycleYear = x.CycleYear,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        ESP = x.ESP
                    });
                    transaction.Commit();
                }
            });
        }
    }
}
