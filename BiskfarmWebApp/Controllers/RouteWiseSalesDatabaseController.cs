using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using Biskfarm.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BiskfarmWebApp.Controllers
{
    public class RouteWiseSalesDatabaseController : Controller
    {
        private readonly BiskfarmContext db;
        OutletWiseSalesDatabaseServices services = new OutletWiseSalesDatabaseServices();
        private IConfiguration configuration;
        public RouteWiseSalesDatabaseController(BiskfarmContext _db)
        {
            db= _db;
        }
        public IActionResult Index()
        {
            var outlet = services.LoadingOutletList(db);
            return View(outlet);
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
                                        cmd.CommandText = "DUMP_DATA_UNCOVERED_ROUTES";
                                        cmd.Parameters.AddWithValue("@REGION", selection.Region);
                                        cmd.Parameters.AddWithValue("@ZONE_STATE", state.ZONE_STATE);
                                        cmd.Parameters.AddWithValue("@RSM_ID", selection.RSM_ID);
                                        cmd.Parameters.AddWithValue("@BM_ID", bm.BM_ID);
                                        cmd.Parameters.AddWithValue("@ASM_ID", asm.ASM_ID);
                                        cmd.Parameters.AddWithValue("@SO_ID", so.SO_ID);
                                        cmd.Parameters.AddWithValue("@RDS_ID", rds.RSD_ID);
                                        cmd.Parameters.AddWithValue("@FROM_DATE", selection.fromDate);
                                        cmd.Parameters.AddWithValue("@TO_DATE", selection.toDate);
                                        cmd.Parameters.AddWithValue("@FILTER_TYPE", selection.filterType);
                                        cmd.Parameters.AddWithValue("@DATE_TYPE", selection.dataType);
                                        cmd.Parameters.AddWithValue("@IS_ONLY_SUB", 0);
                                        cmd.Parameters.AddWithValue("@DATA_SOURCE", "S");

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
                                                      SO_ID = Convert.ToInt32(dr["SO_ID"]),
                                                      SO_NAME = dr["SO_NAME"].ToString(),
                                                      RDS_ID = Convert.ToInt32(dr["RDS_ID"]),
                                                      RDS_NAME = dr["ASM_NAME"].ToString(),


                                                  }).ToList();
                                        // outlet=List<OutletWiseSalesDatabase>(adapter1);
                                        //SqlDataReader rdr = cmd.ExecuteReader();

                                        //while(rdr.Read()) {
                                        //    outlet.Add(new OutletWiseSalesDatabase()
                                        //    {
                                        //        RSM_NAME = rdr["RSM_NAME"].ToString(),
                                        //    }); 
                                        //}


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
