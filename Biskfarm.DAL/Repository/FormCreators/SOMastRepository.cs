using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Repository.FormCreators
{
    public class SOMastRepository : Repository<SO_MAST>, ISOMast
    {
        private readonly BiskfarmContext db;
        public SOMastRepository(BiskfarmContext _db) : base(_db)
        {
            db = _db;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(SO_MAST soMast)
        {
            db.SO_MAST.Update(soMast);
        }
    }
}
