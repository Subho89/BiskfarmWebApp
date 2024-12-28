using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.Services
{
    public class OutletWiseSalesDatabaseServices
    {
        //+' ('+CAST(RSM_ID AS VARCHAR(50))+')'
        public List<OutletWiseSalesDatabase> LoadingOutletList(BiskfarmContext db)        
        {
            List<OutletWiseSalesDatabase> outlet=  db.OutletSalesDb.FromSqlRaw<OutletWiseSalesDatabase>("SELECT  NEW_ZONE_GRP REGION,(SELECT DISTINCT R.RSM_NAME FROM RSM_MAST R WHERE R.RSM_ID=VW.RSM_ID)  RSM_NAME,RSM_ID, BM_NAME BM_NAME,BM_ID,\r\n        ASM_NAME ASM_NAME,ASM_ID,\r\n        SO_NAME  SO_NAME,SO_ID,\r\n        RDS_NAME RDS_NAME,RDS_ID,ZONE_STATE\r\nFROM BM_ASM_SO_RDS_MAST VW(NOLOCK)\r\nWHERE RDS_NAME NOT LIKE '%INACTIVE%'").ToList();

            return outlet;
        }
    }
}
