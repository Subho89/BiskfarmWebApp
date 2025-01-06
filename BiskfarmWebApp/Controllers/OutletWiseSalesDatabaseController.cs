using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using Biskfarm.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace BiskfarmWebApp.Controllers
{
    public class OutletWiseSalesDatabaseController : Controller
    {
        private readonly BiskfarmContext db;
        OutletWiseSalesDatabaseServices services = new OutletWiseSalesDatabaseServices();
        List<OutletWiseSalesDatabase> databases = new List<OutletWiseSalesDatabase>(); 
        private IConfiguration configuration;
        public OutletWiseSalesDatabaseController(BiskfarmContext _db,IConfiguration _con)
        {
            db=_db;
            configuration = _con;
        }
        public IActionResult Index()
        {

            databases = services.LoadingOutletList(db);
            return View(databases);
        }

        private string GetConnectionString()
        {
            return this.configuration.GetConnectionString("dbBiskfarm");
        }
        public JsonResult GetRSMData(int RSM_ID)
        {
            databases = services.LoadingOutletList(db);
            var rsmLst = databases.Where(r => r.RSM_ID == RSM_ID).Select(r=>r.Region).Distinct().ToList();

            return Json(rsmLst);
        }

        public JsonResult GetRegionData(OutletWiseSalesDatabaseVM vm )
        {
            databases = services.LoadingOutletList(db);
            var rsmLst = databases.Where(r => r.RSM_ID == vm.RSM_ID &&r.Region==vm.Region).Select(r => r.ZONE_STATE).Distinct().ToList();

            return Json(rsmLst);
        }

        public JsonResult GetStatesData(SelectionVM vm)
        {
            databases = services.LoadingOutletList(db);
            var rsmLst = databases.Where(r => r.RSM_ID == vm.RSM_ID && r.Region == vm.Region).Distinct().ToList();

            

            List<BMVM> bmList = new List<BMVM>();

            if(vm.Zone_States!=null) {
                foreach (var state in vm.Zone_States)
                {
                    
                    var bm = rsmLst.Where(r => r.ZONE_STATE.ToString() == state.ZONE_STATE).Select(x => new { x.BM_ID, x.BM_NAME }).Distinct().ToList();

                    foreach (var b in bm)
                    {
                        BMVM objBM = new BMVM();
                        objBM.BM_ID = b.BM_ID;
                        objBM.BM_NAME = b.BM_NAME;
                        bmList.Add(objBM);
                    }



                }
            }
            

            

            return Json(bmList.GroupBy(r=>r.BM_ID).Select(r=>r.First()));
        }

        public JsonResult GetBMData(SelectionVM vm)
        {
            databases = services.LoadingOutletList(db);
            var rsmLst = databases.Where(r => r.RSM_ID == vm.RSM_ID && r.Region == vm.Region).Distinct().ToList();



            List<OutletWiseSalesDatabase> bmList = new List<OutletWiseSalesDatabase>();

            if (vm.Zone_States != null)
            {
                foreach (var state in vm.Zone_States)
                {

                    var bm = rsmLst.Where(r => r.ZONE_STATE.ToString() == state.ZONE_STATE).Distinct().ToList();

                    
                    bmList.AddRange(bm);


                }
            }


            

            List<ASMVM> asmList = new List<ASMVM>();

            if(vm.BMs != null)
            {
                foreach (var b in vm.BMs)
                {
                    var asm=bmList.Where(r=>r.BM_ID==b.BM_ID).Select(x => new { x.ASM_ID, x.ASM_NAME }).Distinct().ToList();

                    foreach(var a  in asm)
                    {
                        ASMVM objAsm=new ASMVM();

                        objAsm.ASM_ID=a.ASM_ID;
                        objAsm.ASM_NAME=a.ASM_NAME;

                        asmList.Add(objAsm);
                    }
                }
            }



            return Json(asmList.GroupBy(r=>r.ASM_ID).Select(r=>r.First()));
        }

        public JsonResult GetASMData(SelectionVM vm)
        {
            databases = services.LoadingOutletList(db);
            var rsmLst = databases.Where(r => r.RSM_ID == vm.RSM_ID && r.Region == vm.Region).Distinct().ToList();



            List<OutletWiseSalesDatabase> bmList = new List<OutletWiseSalesDatabase>();

            if (vm.Zone_States != null)
            {
                foreach (var state in vm.Zone_States)
                {

                    var bm = rsmLst.Where(r => r.ZONE_STATE.ToString() == state.ZONE_STATE).Distinct().ToList();


                    bmList.AddRange(bm);


                }
            }




            List<OutletWiseSalesDatabase> asmList = new List<OutletWiseSalesDatabase>();

            if (vm.BMs != null)
            {
                foreach (var b in vm.BMs)
                {
                    var asm = bmList.Where(r => r.BM_ID == b.BM_ID).Distinct().ToList();

                    asmList.AddRange(asm);
                }
            }


            List<SOVM> soLst = new List<SOVM>();
            if(vm.ASMs != null)
            {
                foreach(var a in vm.ASMs)
                {
                    var so=asmList.Where(r=>r.ASM_ID==a.ASM_ID).Select(x => new { x.SO_ID, x.SO_NAME }).Distinct().ToList();


                    foreach (var s in so)
                    {
                        SOVM objSO = new SOVM();
                        objSO.SO_ID = s.SO_ID;
                        objSO.SO_NAME = s.SO_NAME;
                        soLst.Add(objSO);
                    }
                }
            }



            return Json(soLst.GroupBy(r => r.SO_ID).Select(r => r.First()));
        }

        public JsonResult GetSOData(SelectionVM vm)
        {
            databases = services.LoadingOutletList(db);
            var rsmLst = databases.Where(r => r.RSM_ID == vm.RSM_ID && r.Region == vm.Region).Distinct().ToList();



            List<OutletWiseSalesDatabase> bmList = new List<OutletWiseSalesDatabase>();

            if (vm.Zone_States != null)
            {
                foreach (var state in vm.Zone_States)
                {

                    var bm = rsmLst.Where(r => r.ZONE_STATE.ToString() == state.ZONE_STATE).Distinct().ToList();


                    bmList.AddRange(bm);


                }
            }




            List<OutletWiseSalesDatabase> asmList = new List<OutletWiseSalesDatabase>();

            if (vm.BMs != null)
            {
                foreach (var b in vm.BMs)
                {
                    var asm = bmList.Where(r => r.BM_ID == b.BM_ID).Distinct().ToList();

                    asmList.AddRange(asm);
                }
            }


            List<OutletWiseSalesDatabase> soLst = new List<OutletWiseSalesDatabase>();
            if (vm.ASMs != null)
            {
                foreach (var a in vm.ASMs)
                {
                    var so = asmList.Where(r => r.ASM_ID == a.ASM_ID).Distinct().ToList();


                    soLst.AddRange(so);
                }
            }

            List<RSDVM> rsdLst = new List<RSDVM>();
            if (vm.SOVMs != null)
            {
                foreach (var s in vm.SOVMs)
                {
                    var rsd = soLst.Where(r => r.SO_ID == s.SO_ID).Select(x => new { x.RDS_ID, x.RDS_NAME }).Distinct().ToList();


                    foreach (var r in rsd)
                    {
                        RSDVM objRDS = new RSDVM();
                        objRDS.RSD_ID = r.RDS_ID;
                        objRDS.RSD_NAME = r.RDS_NAME;
                        rsdLst.Add(objRDS);
                    }
                }
            }


            return Json(rsdLst.GroupBy(r => r.RSD_ID).Select(r => r.First()));
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
                                        cmd.CommandText = "DUMP_DATA_UNBILLED_OUTLETS";
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



            //using (SqlConnection con = new SqlConnection(GetConnectionString()))
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        con.Open();
            //        DataTable DataTbl1 = new DataTable();

            //        cmd.Connection = con;
            //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //        cmd.CommandTimeout = 0;
            //        cmd.CommandText = "DUMP_DATA_UNBILLED_OUTLETS";
            //        cmd.Parameters.AddWithValue("@REGION", "REGION 6");
            //        cmd.Parameters.AddWithValue("@ZONE_STATE", "TELANGANA");
            //        cmd.Parameters.AddWithValue("@RSM_ID", "30");
            //        cmd.Parameters.AddWithValue("@BM_ID", "1015");
            //        cmd.Parameters.AddWithValue("@ASM_ID", "10059");
            //        cmd.Parameters.AddWithValue("@SO_ID", "100064279");
            //        cmd.Parameters.AddWithValue("@RDS_ID", "2565243");
            //        cmd.Parameters.AddWithValue("@FROM_DATE", "");
            //        cmd.Parameters.AddWithValue("@TO_DATE", "");
            //        cmd.Parameters.AddWithValue("@FILTER_TYPE", "A");
            //        cmd.Parameters.AddWithValue("@DATE_TYPE", "6");
            //        cmd.Parameters.AddWithValue("@IS_ONLY_SUB", 0);
            //        cmd.Parameters.AddWithValue("@DATA_SOURCE", "S");


            //        SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            //        adapter1.Fill(DataTbl1);
            //        outlet = (from DataRow dr in DataTbl1.Rows
            //                  select new OutletWiseSalesDatabase()
            //                  {
            //                      Region = (dr["Region"].ToString()),
            //                      ZONE_STATE = dr["ZONE_STATE"].ToString(),
            //                      RSM_ID = Convert.ToInt32(dr["RSM_ID"]),
            //                      RSM_NAME = dr["RSM_NAME"].ToString(),
            //                      BM_ID = Convert.ToInt32(dr["BM_ID"]),
            //                      BM_NAME = dr["BM_NAME"].ToString(),
            //                      ASM_ID = Convert.ToInt32(dr["ASM_ID"]),
            //                      ASM_NAME = dr["ASM_NAME"].ToString(),
            //                      SO_ID = Convert.ToInt32(dr["SO_ID"]),
            //                      SO_NAME = dr["SO_NAME"].ToString(),
            //                      RDS_ID = Convert.ToInt32(dr["RDS_ID"]),
            //                      RDS_NAME = dr["ASM_NAME"].ToString(),
            //                  }).ToList();
            //        // outlet=List<OutletWiseSalesDatabase>(adapter1);
            //        //SqlDataReader rdr = cmd.ExecuteReader();

            //        //while(rdr.Read()) {
            //        //    outlet.Add(new OutletWiseSalesDatabase()
            //        //    {
            //        //        RSM_NAME = rdr["RSM_NAME"].ToString(),
            //        //    }); 
            //        //}

            //        var v = outlet;
            //    }
            //}


            return PartialView(outlet);
        }


        //public List<OutletWiseSalesDatabase> GetOutlets()
        //{



        //}
    }
}
