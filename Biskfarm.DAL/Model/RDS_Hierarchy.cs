using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Model
{
    public class RDS_Hierarchy
    {
        [Key]
        public int hierarchyId { get; set; }
        public string hierarchyName { get; set; }
    }
}
