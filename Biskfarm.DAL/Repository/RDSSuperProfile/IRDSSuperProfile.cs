using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Repository.RDSSuperProfile
{
    public interface IRDSSuperProfile:IRepository<RDS_SuperProfile>
    {
        void Update(RDS_SuperProfile rdsSuperProfile);
        void Save();
    }
}
