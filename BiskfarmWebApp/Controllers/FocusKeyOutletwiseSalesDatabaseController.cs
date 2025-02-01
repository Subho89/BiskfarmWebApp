using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using Biskfarm.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BiskfarmWebApp.Controllers
{
    public class FocusKeyOutletwiseSalesDatabaseController : Controller
    {
        private readonly BiskfarmContext db;
        OutletWiseSalesDatabaseServices services = new OutletWiseSalesDatabaseServices();
        private IConfiguration configuration;
        public FocusKeyOutletwiseSalesDatabaseController(BiskfarmContext _db, IConfiguration _con)
        {
            db = _db;
            configuration = _con;
        }
        public IActionResult Index()
        {
            var outlet = services.LoadingOutletList(db);

            List<OutletWiseSalesDatabaseVM> outletVM = new List<OutletWiseSalesDatabaseVM>();

            FormLoaderVM loaderVM = new FormLoaderVM();

            loaderVM.Outlets = outlet;

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();

                    DataTable DataTbl1 = new DataTable();
                    string qry =
                        "WITH CTE" + System.Environment.NewLine +
                        "AS" + System.Environment.NewLine +
                        "(" + System.Environment.NewLine +
                        "    SELECT 1 MON_NO,CONVERT(VARCHAR(50), DATENAME(MONTH, '2024-'+CAST(1 AS VARCHAR(50))+'-01')) AS ORDER_MONTH" + System.Environment.NewLine +
                        "    UNION ALL" + System.Environment.NewLine +
                        "    SELECT CTE.MON_NO+1 MON_NO,CONVERT(VARCHAR(50),DATENAME(MONTH, '2024-'+CAST(CTE.MON_NO+1 AS VARCHAR(50))+'-01')) AS ORDER_MONTH" + System.Environment.NewLine +
                        "    FROM CTE" + System.Environment.NewLine +
                        "    WHERE MON_NO<=11" + System.Environment.NewLine +
                        ")" + System.Environment.NewLine +

                        "SELECT * FROM CTE";

                    SqlCommand cmd1 = new SqlCommand(qry, con);
                    cmd1.CommandType = CommandType.Text;
                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);

                    adapter1.Fill(DataTbl1);

                    loaderVM.MonthVMs = (from DataRow dr in DataTbl1.Rows
                                         select new MonthVM()
                                         {
                                             MON_NO = (dr["MON_NO"].ToString()),
                                             ORDER_MONTH = dr["ORDER_MONTH"].ToString(),



                                         }).ToList();



                    DataTbl1 = new DataTable();
                    qry =
                        "WITH CTE" + System.Environment.NewLine +
                        "AS" + System.Environment.NewLine +
                        "(" + System.Environment.NewLine +
                        "	SELECT 1 SL_NO,(MAX(CM_CMDATE)) [MAX_DATE],[DBO].[GET_FINANCIAL_YEAR](CAST(MAX(CM_CMDATE) AS DATE)) FIN_YEAR" + System.Environment.NewLine +
                        "	FROM IIMS_CMFILE(NOLOCK)" + System.Environment.NewLine +
                        "	UNION ALL" + System.Environment.NewLine +
                        "	SELECT CTE.SL_NO+1 SL_NO,(DATEADD(YEAR,-1,CTE.[MAX_DATE])) [MAX_DATE],[DBO].[GET_FINANCIAL_YEAR](DATEADD(YEAR,-1,CTE.[MAX_DATE])) FIN_YEAR" + System.Environment.NewLine +
                        "	FROM CTE" + System.Environment.NewLine +
                        "	WHERE SL_NO<=2" + System.Environment.NewLine +
                        ")" + System.Environment.NewLine +

                        "SELECT YEAR([MAX_DATE]) YEAR_NO,FIN_YEAR " + System.Environment.NewLine +
                        "FROM CTE";

                    cmd1 = new SqlCommand(qry, con);
                    cmd1.CommandType = CommandType.Text;
                    adapter1 = new SqlDataAdapter(cmd1);

                    adapter1.Fill(DataTbl1);

                    loaderVM.YearVMs = (from DataRow dr in DataTbl1.Rows
                                        select new YearVM()
                                        {
                                            YEAR_NO = (dr["YEAR_NO"].ToString()),
                                            FIN_YEAR = dr["FIN_YEAR"].ToString(),



                                        }).ToList();

                }
            }

            return View(loaderVM);
        }

        private string GetConnectionString()
        {
            return this.configuration.GetConnectionString("dbBiskfarm");
        }


        public IActionResult GetRawData(SelectionVM selection)
        {
            List<OutletWiseSalesDatabase> outlet = new List<OutletWiseSalesDatabase>();

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
                                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                                {
                                    using (SqlCommand cmd = new SqlCommand())
                                    {
                                        con.Open();
                                        DataTable DataTbl1 = new DataTable();

                                        cmd.Connection = con;
                                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                        cmd.CommandTimeout = 0;
                                        cmd.CommandText = "DUMP_DATA_UNBILLED_UNBILLED_FOCUS_SKU_OUTLETS";
                                        cmd.Parameters.AddWithValue("@REGION", selection.Region);
                                        cmd.Parameters.AddWithValue("@ZONE_STATE", state.ZONE_STATE);
                                        cmd.Parameters.AddWithValue("@RSM_ID", selection.RSM_ID);
                                        cmd.Parameters.AddWithValue("@BM_ID", bm.BM_ID);
                                        cmd.Parameters.AddWithValue("@ASM_ID", asm.ASM_ID);
                                        cmd.Parameters.AddWithValue("@SO_ID", so.SO_ID);
                                        cmd.Parameters.AddWithValue("@RDS_ID", rds.RSD_ID);
                                        cmd.Parameters.AddWithValue("@MON_NO", selection.monthNo);
                                        cmd.Parameters.AddWithValue("@YEAR_NO", selection.yearNo);
                                        cmd.Parameters.AddWithValue("@FILTER_TYPE", selection.filterType);
                                        cmd.Parameters.AddWithValue("@DATE_TYPE", selection.dataType);
                                        cmd.Parameters.AddWithValue("@IS_KEY_OUTLET", 1);
                                        cmd.Parameters.AddWithValue("@DATA_SOURCE", selection.dataSource);

                                        SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                                        adapter1.Fill(DataTbl1);
                                        outlet = (from DataRow dr in DataTbl1.Rows
                                                  select new OutletWiseSalesDatabase()
                                                  {
                                                      Region = (dr["Region"].ToString()),
                                                      ZONE_STATE = dr["ZONE_STATE"].ToString(),
                                                      RSM_ID = Convert.ToInt32(dr["RSM_ID"]),
                                                      RSM_NAME = dr["RSM_NAME"].ToString(),
                                                      BM_ID = Convert.ToInt32(dr["BM_ID"]),
                                                      BM_NAME = dr["BM_NAME"].ToString(),
                                                      ASM_ID = Convert.ToInt32(dr["ASM_ID"]),
                                                      ASM_NAME = dr["ASM_NAME"].ToString(),
                                                      SO_ID = (dr["SO_ID"]).ToString(),
                                                      SO_NAME = dr["SO_NAME"].ToString(),
                                                      RDS_ID = Convert.ToInt32(dr["RDS_ID"]),
                                                      RDS_NAME = dr["ASM_NAME"].ToString(),


                                                  }).ToList();

                                    }
                                }


                            }
                        }
                    }
                }
            }



            return PartialView(outlet);
        }
    }
}
