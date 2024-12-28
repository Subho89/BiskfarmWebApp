using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Repository.RDSSuperProfile
{
    public class RDSProfileRepository : Repository<RDS_SuperProfile>, IRDSSuperProfile
    {
        private readonly BiskfarmContext db;
        public RDSProfileRepository(BiskfarmContext _db) : base(_db)
        {
            db = _db;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(RDS_SuperProfile rdsSuperProfile)
        {
            db.RDS_SuperProfile.Update(rdsSuperProfile);
        }
    }
}
