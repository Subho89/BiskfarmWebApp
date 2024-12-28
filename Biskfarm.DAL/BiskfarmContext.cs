using Biskfarm.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL 
{
    public class BiskfarmContext : DbContext
    {

        public BiskfarmContext(DbContextOptions<BiskfarmContext> options) : base(options)
        {

        }

        public DbSet<RDS_SuperProfile_CurrentBusinessDetails> RDS_SuperProfile_CurrentBusinessDetails { get; set; }
        public DbSet<RDS_SuperProfile_RouteSubStockist> RDS_SuperProfile_RouteSubStockist { get; set; }
        public DbSet<RDS_SuperProfile> RDS_SuperProfile { get; set; }
        public DbSet<SO_MAST> SO_MAST { get; set; }
        public DbSet<RDS_Hierarchy> RDS_Hierarchy { get; set; }
        public DbSet<OutletWiseSalesDatabase> OutletSalesDb { get; set; }
        public DbSet<RDS_Demo> RDS_Demo { get; set; }
    }   
}
