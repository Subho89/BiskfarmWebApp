using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Model
{
    [Keyless]
    public class OutletWiseSalesDatabase
    {
        public string Region { get; set; }
        public string RSM_NAME { get; set; }
        public int RSM_ID { get; set; }
        public string BM_NAME { get; set; }
        public int BM_ID { get; set; }
        public string ASM_NAME { get; set; }
        public int ASM_ID { get; set; }
        public string SO_NAME { get; set; }
        public string SO_ID { get; set; }
        public string RDS_NAME { get; set; }
        public int RDS_ID { get; set; }
        public string ZONE_STATE { get; set; }
    }

  
}
