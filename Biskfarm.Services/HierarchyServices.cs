using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.Services
{
    public class HierarchyServices
    {
        private BiskfarmContext db;

        
        public void AddHierarchy(RDS_Hierarchy hierarchy,BiskfarmContext context)
        {
            db= context;
            db.RDS_Hierarchy.Add(hierarchy);
            db.SaveChanges();
            
        }

        public List<RDS_Hierarchy> GetAllHierarchy(BiskfarmContext context)
        {
            db=context;
            List<RDS_Hierarchy> hierarches=new List<RDS_Hierarchy>();
            hierarches = db.RDS_Hierarchy.ToList();
            return (hierarches);
        }
    }
}
