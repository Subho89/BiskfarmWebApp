using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Repository.RDSHierarchy
{
    public class RDSHierarchy : Repository<RDS_Hierarchy>, IRDSHierarchy
    {
        private readonly BiskfarmContext db;
        public RDSHierarchy(BiskfarmContext _db) : base(_db)
        {
            db = _db;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(RDS_Hierarchy hierarchies)
        {
            db.RDS_Hierarchy.Update(hierarchies);
        }
    }
}
