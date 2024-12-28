using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Repository.RDSSuperProfile
{
    public interface IRDSSubstockist : IRepository<RDS_SuperProfile_RouteSubStockist>
    {
        void Update(RDS_SuperProfile_RouteSubStockist rdsSubStockist);
        void Save();
    }
}
