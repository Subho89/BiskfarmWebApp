using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.Services
{
    public class RDSBusinessProposalServices
    {
        private BiskfarmContext db;

        public bool SaveRDSBusinessProposal(BiskfarmContext context, RDS_BUSINESS_PROPOSAL business)
        {
            db = context;

            try
            {
                db.RDS_BUSINESS_PROPOSAL.Add(business);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public List<RDS_Hierarchy> HeirarchyList(BiskfarmContext context)
        {
            db = context;
            return db.RDS_Hierarchy.ToList();
        }

        public List<RDS_BUSINESS_PROPOSAL> GetAll(BiskfarmContext context)
        {
            db = context;



            return db.RDS_BUSINESS_PROPOSAL.ToList();
        }
    }
}
