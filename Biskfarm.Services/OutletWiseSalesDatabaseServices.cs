using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.Services
{
    public class OutletWiseSalesDatabaseServices
    {
        //+' ('+CAST(RSM_ID AS VARCHAR(50))+')'
        public List<OutletWiseSalesDatabase> LoadingOutletList(BiskfarmContext db)        
        {
            List<OutletWiseSalesDatabase> outlet = db.OutletSalesDb.FromSqlRaw<OutletWiseSalesDatabase>("SELECT  NEW_ZONE_GRP REGION,(SELECT DISTINCT R.RSM_NAME FROM RSM_MAST R WHERE R.RSM_ID=VW.RSM_ID)  RSM_NAME,RSM_ID, BM_NAME BM_NAME,BM_ID,\r\n        ASM_NAME ASM_NAME,ASM_ID,\r\n        SO_NAME  SO_NAME,SO_ID,\r\n        RDS_NAME RDS_NAME,RDS_ID,ZONE_STATE\r\nFROM BM_ASM_SO_RDS_MAST VW(NOLOCK)\r\nWHERE RDS_NAME NOT LIKE '%INACTIVE%'").ToList();

            return outlet;

        }

        public List<OutletWiseSalesDatabase> GetData(BiskfarmContext db, SelectionVM selection)
        {
            var region = new SqlParameter("@REGION", System.Data.SqlDbType.VarChar);
            var zoneState = new SqlParameter("@ZONE_STATE", System.Data.SqlDbType.VarChar);
            var rsmId = new SqlParameter("@RSM_ID", System.Data.SqlDbType.VarChar);
            var bmId = new SqlParameter("@BM_ID", System.Data.SqlDbType.VarChar);
            var asmId = new SqlParameter("@ASM_ID", System.Data.SqlDbType.VarChar);
            var soId = new SqlParameter("@SO_ID", System.Data.SqlDbType.VarChar);
            var rdsId = new SqlParameter("@RDS_ID", System.Data.SqlDbType.VarChar);
            var frmDate = new SqlParameter("@FROM_DATE", System.Data.SqlDbType.VarChar);
            var toDate = new SqlParameter("@TO_DATE", System.Data.SqlDbType.VarChar);
            SqlParameter filterType = new SqlParameter("@FILTER_TYPE", 'A');
            var dateType = new SqlParameter("@DATE_TYPE", System.Data.SqlDbType.VarChar);
            var onlySub = new SqlParameter("@IS_ONLY_SUB", System.Data.SqlDbType.Bit);
            var dataSource = new SqlParameter("@DATA_SOURCE", System.Data.SqlDbType.VarChar);

            List<OutletWiseSalesDatabase> outputSlaesLst = new List<OutletWiseSalesDatabase>();

            region.Value =  "REGION 6";
            zoneState.Value =  "TELANGANA";
            rsmId.Value = "30";
            bmId.Value = "1015";
            asmId.Value = "10059";
            soId.Value = "100064279";
            rdsId.Value = "2565243";
            frmDate.Value = "";
            toDate.Value = "";
            //filterType.Value = "A";
            dateType.Value = "6";
            onlySub.Value = 0;
            dataSource.Value = "S";




            //List<OutletWiseSalesDatabase> outlet = db.OutletSalesDb.FromSqlRaw<OutletWiseSalesDatabase>("DUMP_DATA_UNBILLED_OUTLETS @REGION,@ZONE_STATE,@RSM_ID,@BM_ID,@ASM_ID,@SO_ID,@RDS_ID,@FROM_DATE,@TO_DATE,@FILTER_TYPE,@DATE_TYPE,@IS_ONLY_SUB,@DATA_SOURCE", @region, @zoneState, @rsmId, @bmId, @asmId, @soId, @rdsId, @frmDate, @toDate, @filterType, @dateType, @onlySub, @dataSource).ToList();

            //List<OutletWiseSalesDatabase> outlet = db.OutletSalesDb.FromSqlRaw<OutletWiseSalesDatabase>("DUMP_DATA_UNBILLED_OUTLETS {0}", filterType).ToList();

            var outlet = db.OutletSalesDb.FromSqlRaw("DUMP_DATA_UNBILLED_OUTLETS @FILTER_TYPE", filterType).ToList();


            //outputSlaesLst.AddRange(outlet);

            foreach (var state in selection.Zone_States)
            {
                foreach (var bm in selection.BMs)
                {
                    foreach (var asm in selection.ASMs)
                    {
                        foreach (var so in selection.SOVMs)
                        {
                            foreach (var rds in selection.RSDVMs)
                            {
                                //region.Value = selection.Region == "0" ? null : selection.Region;
                                //zoneState.Value = state.ZONE_STATE == "0" ? null : state.ZONE_STATE;
                                //rsmId.Value = selection.RSM_ID == 0 ? null : selection.RSM_ID;
                                //bmId.Value = bm.BM_ID == 0 ? null : bm.BM_ID;
                                //asmId.Value = asm.ASM_ID == 0 ? null : asm.ASM_ID;
                                //soId.Value = so.SO_ID == 0 ? null : so.SO_ID;
                                //rdsId.Value = rds.RSD_ID == 0 ? null : rds.RSD_ID;
                                //frmDate.Value = selection.fromDate;
                                //toDate.Value = selection.toDate;
                                //filterType.Value = selection.filterType;
                                //dateType.Value = selection.dataType;
                                //onlySub.Value = 0;
                                //dataSource.Value = "D";
                                //frmDate.Value = "";
                                //toDate.Value = "";

                                //List<OutletWiseSalesDatabase> outlet = db.OutletSalesDb.FromSqlRaw<OutletWiseSalesDatabase>("DUMP_DATA_UNBILLED_OUTLETS @REGION,@ZONE_STATE,@RSM_ID,@BM_ID,@ASM_ID,@SO_ID,@RDS_ID,@FROM_DATE,@TO_DATE,@FILTER_TYPE,@DATE_TYPE,@IS_ONLY_SUB,@DATA_SOURCE", @region, @zoneState, @rsmId, @bmId, @asmId, @soId, @rdsId, @frmDate, @toDate, @filterType, @dateType, @onlySub, @dataSource).ToList();

                                //outputSlaesLst.AddRange(outlet);


                                

                            }
                        }
                    }
                }
            }




            //List<OutletWiseSalesDatabase> outlet = db.OutletSalesDb.FromSqlRaw<OutletWiseSalesDatabase>("DUMP_DATA_UNBILLED_OUTLETS").ToList();//

            return outputSlaesLst;
        }
    }
}
