using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Repository.RDSHierarchy
{
    public interface IRDSHierarchy:IRepository<RDS_Hierarchy>
    {
        void Update(RDS_Hierarchy rdsHierarchy);
        void Save();
    }
}
