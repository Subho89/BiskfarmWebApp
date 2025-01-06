
using Biskfarm.DAL.Model;
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
        public int RSM_ID { get; set; }
        public string BM_NAME { get; set; }
        public int BM_ID { get; set;}
        public string ASM_NAME { get; set; }
        public int ASM_ID { get; set;}
        public string SO_NAME { get; set; }
        public int SO_ID { get; set;}
        public string RSD_NAME { get; set;}
        public int RSD_ID { get;set;}
        public string ZONE_STATE { get; set; }
    }

    public class FormLoaderVM
    {
        public List<OutletWiseSalesDatabase> Outlets { get; set; }
        public List<YearVM> YearVMs { get; set; }
        public List<MonthVM> MonthVMs { get; set; }
    }

    public class SelectionVM
    {
        public string Region { get; set; }
        public int RSM_ID { get; set; }
        public string RSM_NAME { get; set; }
        public int BM_ID { get; set; }
        public string BM_NAME { get; set; }
        public string ASM_NAME { get; set; }
        public int ASM_ID { get; set; }
        public string SO_NAME { get; set; }
        public int SO_ID { get; set; }
        public string RSD_NAME { get; set; }
        public int RSD_ID { get; set; }
        public List<StateSelectionVM> Zone_States { get; set; }
        public List<BMVM> BMs { get; set; }
        public List<ASMVM> ASMs { get; set; }
        public List<SOVM> SOVMs { get; set; }
        public List<RSDVM> RSDVMs { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string filterType { get; set; }
        public string dataType { get; set; }
        public bool isOnlySub { get; set; }
        public string dataSource { get; set; }
        public List<YearVM> YearVMs { get; set; }
        public List<MonthVM> MonthVMs { get; set; }
        public string monthNo { get; set; }
        public string yearNo { get; set; }
    }

    public class YearVM
    {
        public string YEAR_NO { get; set; }
        public string FIN_YEAR { get; set; }
    }

    public class MonthVM
    {
        public string MON_NO { get; set; }
        public string ORDER_MONTH { get; set; }
    }
    public class StateSelectionVM
    {
        public string ZONE_STATE { get; set; }
    }

    public class BMVM
    {
        public int BM_ID { get; set; }
        public string BM_NAME { get; set; }
    }

    public class ASMVM
    {
        public int ASM_ID { get; set; }
        public string ASM_NAME { get; set; }
    }

    public class SOVM
    {
        public int SO_ID { get; set; }
        public string SO_NAME { get; set; }
    }

    public class RSDVM
    {
        public int RSD_ID { get; set; }
        public string RSD_NAME { get; set; }
    }

    
}
