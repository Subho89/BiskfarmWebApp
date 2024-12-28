
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.Services
{
    [Keyless]
    public class OutletWiseSalesDatabaseVM
    {
        public string Region { get; set; }
        public string RSM_NAME { get; set; }
        public string RSM_ID { get; set; }
        public string BM_NAME { get; set; }
        public string BM_ID { get; set;}
        public string ASM_NAME { get; set; }
        public string ASM_ID { get; set;}
        public string SO_NAME { get; set; }
        public string SO_ID { get; set;}
        public string RSD_NAME { get; set;}
        public string RSD_ID { get;set;}
        public string ZONE_STATE { get; set; }
    }

    public class SelectionVM
    {
        public string Region { get; set; }
        public string RSM_NAME { get; set; }
        public List<StateSelectionVM> States { get; set; }
        public List<BMVM> BMs { get; set; }
        public List<ASMVM> ASMs { get; set; }
        public List<SOVM> SOVMs { get; set; }
        public List<RSDVM> RSDVMs { get; set; }
    }

    public class StateSelectionVM
    {
        public string ZONE_STATE { get; set; }
    }

    public class BMVM
    {
        public string BM_NAME { get; set; }
    }

    public class ASMVM
    {
        public string ASM_NAME { get; set; }
    }

    public class SOVM
    {
        public string SO_NAME { get; set; }
    }

    public class RSDVM
    {
        public string RSD_NAME { get; set; }
    }

    
}
