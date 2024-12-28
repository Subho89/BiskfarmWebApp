using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Repository.FormCreators
{
    public interface ISOMast:IRepository<SO_MAST>
    {
        void Update(SO_MAST soMast);
        void Save();
    }
}
