using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Repository.RDSSuperProfile
{
    public class RDSSubStockist : Repository<RDS_SuperProfile_RouteSubStockist>, IRDSSubstockist
    {
        private readonly BiskfarmContext db;
        public RDSSubStockist(BiskfarmContext _db) : base(_db)
        {
            db = _db;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(RDS_SuperProfile_RouteSubStockist rdsSubStockist)
        {
            db.RDS_SuperProfile_RouteSubStockist.Update(rdsSubStockist);
        }
    }
}
