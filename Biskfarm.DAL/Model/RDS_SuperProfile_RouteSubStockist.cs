using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Model
{
    public class RDS_SuperProfile_RouteSubStockist
    {
        [Key]
        public int rdsSuperProfileSubStockistId { get; set; }
        public Nullable<int> rdsSuperProfileId { get; set; }
        public string? nameOfRouteSubStockist { get; set; }
        public Nullable<int> freqOfVisit { get; set; }
        public string? distanceFromRDS { get; set; }
        public string? expectedBusiness { get; set; }
        public string? outlets { get; set; }
    }
}
