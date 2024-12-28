using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.Services
{
    public class RDSDemoServices
    {
        public List<RDS_Demo> GetList(BiskfarmContext db)
        {
            return db.RDS_Demo.ToList();
        }
    }
}
