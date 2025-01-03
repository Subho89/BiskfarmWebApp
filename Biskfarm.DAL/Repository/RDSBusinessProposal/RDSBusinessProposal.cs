using Biskfarm.DAL.Model;
using Biskfarm.DAL.Repository.RDSHierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Repository.RDSBusinessProposal
{
    public class RDSBusinessProposal : Repository<RDS_BUSINESS_PROPOSAL>, IRDSBusinessProposal
    {
        private readonly BiskfarmContext db;
        public RDSBusinessProposal(BiskfarmContext _db) : base(_db)
        {
            db = _db;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(RDS_BUSINESS_PROPOSAL businessProposal)
        {
            db.RDS_BUSINESS_PROPOSAL.Update(businessProposal);
        }
    }
}
