using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Model
{
    public class RDS_SuperProfile_CurrentBusinessDetails
    {
        [Key]
        public int rdsBusinessDetailsId { get; set; }
        public Nullable<int> rdsSuperProfileId { get; set; }
        public Nullable<System.DateTime> dateOfAppointment { get; set; }
        public Nullable<decimal> currentAvgMonthlyBusiness { get; set; }
        public string? paymentTerm { get; set; }
        public string? nofRoutes { get; set; }
        public string? nofOutlets { get; set; }
        public string? distributorForCompany { get; set; }
    }
}
