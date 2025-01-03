using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Repository.RDSBusinessProposal
{
    public interface IRDSBusinessProposal : IRepository<RDS_BUSINESS_PROPOSAL>
    {
        void Update(RDS_BUSINESS_PROPOSAL rdsBusinesssProposal);
        void Save();
    }
}
