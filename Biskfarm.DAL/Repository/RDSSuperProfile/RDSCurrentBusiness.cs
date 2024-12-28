using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Repository.RDSSuperProfile
{
    public class RDSCurrentBusiness : Repository<RDS_SuperProfile_CurrentBusinessDetails>, IRDSCurrentBusiness
    {
        private readonly BiskfarmContext db;
        public RDSCurrentBusiness(BiskfarmContext _db) : base(_db)
        {
            db = _db;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(RDS_SuperProfile_CurrentBusinessDetails rdsCurrentBusiness)
        {
            db.RDS_SuperProfile_CurrentBusinessDetails.Update(rdsCurrentBusiness);
        }
    }
}
