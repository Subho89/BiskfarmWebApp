using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Repository.RDSSuperProfile
{
    public interface IRDSCurrentBusiness : IRepository<RDS_SuperProfile_CurrentBusinessDetails>
    {
        void Update(RDS_SuperProfile_CurrentBusinessDetails rdsCurrentBusiness);
        void Save();
    }
}
