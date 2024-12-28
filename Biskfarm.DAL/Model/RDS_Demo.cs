using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Model
{
    public class RDS_Demo
    {
        [Key]
        public int equipmentId { get; set; }
        public string equipmentName { get; set; }
        public Nullable<int> equipmentQty { get; set; }
    }
}
