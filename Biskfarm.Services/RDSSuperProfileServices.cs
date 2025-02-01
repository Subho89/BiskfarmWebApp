using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.Services
{
    public class RDSSuperProfileServices
    {
        private BiskfarmContext db;

        //public RDSSuperProfileServices(BiskfarmContext _db)
        //{
        //    db=_db;
        //}

        public RDSSuperProfileInputVM GetRDSSuperProfileInputParameters(BiskfarmContext context, string soId,string conStr)
        {
            int SO_ID = 0;
            if (soId.Contains("SO"))
            {
                soId=soId.Replace("SO",string.Empty);
            }
            if (soId.All(char.IsDigit)){
                SO_ID = Convert.ToInt32(soId);
            }
            
            db = context;
            RDSSuperProfileInputVM rDSSuperProfileInputVM = new RDSSuperProfileInputVM();

            rDSSuperProfileInputVM.Towns = new List<TownMastVM>();
            rDSSuperProfileInputVM.SOMasts = new List<SOMast>();
            rDSSuperProfileInputVM.Hierarchy = new List<HierarchyVM>();
            rDSSuperProfileInputVM.RSDVMs = new List<RSDVM>();

            // var towns=db.TOWN_MASTER.ToList();
            var so = db.SO_MAST.ToList();

            var hierarchy=db.RDS_Hierarchy.ToList();

            foreach(var h in hierarchy)
            {
                HierarchyVM hierarchyVM=new HierarchyVM();

                hierarchyVM.hierarchyId=h.hierarchyId;
                hierarchyVM.hierarchyName=h.hierarchyName;

                rDSSuperProfileInputVM.Hierarchy.Add(hierarchyVM);
            }

            foreach (var soMats in so)
            {
                SOMast s = new SOMast();
                s.SO_ID = soMats.SO_ID;
                s.SO_NAME = soMats.SO_NAME;
                s.Head_Qtr = soMats.Head_Qtr;
                s.Home_Town = soMats.Home_Town;
                s.HomeTown_Name = s.HomeTown_Name;

                rDSSuperProfileInputVM.SOMasts.Add(s);
            }

            List<OutletWiseSalesDatabase> outlet = new List<OutletWiseSalesDatabase>();

            using (SqlConnection con = new SqlConnection(conStr))
            {
                //using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    DataTable DataTbl1 = new DataTable();
                    string qry = "SELECT  NEW_ZONE_GRP REGION,(SELECT DISTINCT R.RSM_NAME FROM RSM_MAST R WHERE R.RSM_ID=VW.RSM_ID)  RSM_NAME,RSM_ID, BM_NAME BM_NAME,BM_ID,\r\n        ASM_NAME ASM_NAME,ASM_ID,\r\n        SO_NAME  SO_NAME,SO_ID,\r\n        RDS_NAME RDS_NAME,RDS_ID,ZONE_STATE\r\nFROM BM_ASM_SO_RDS_MAST VW(NOLOCK)\r\nWHERE RDS_NAME NOT LIKE '%INACTIVE%'";

                    SqlCommand cmd1 = new SqlCommand(qry, con);
                    cmd1.CommandType = CommandType.Text;

                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
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

            if (SO_ID != 0)
            {
                var rsd = outlet.Where(r => r.SO_ID == SO_ID.ToString()).Select(x => new { x.RDS_ID, x.RDS_NAME }).Distinct().ToList();

                foreach (var r in rsd)
                {
                    RSDVM objRDS = new RSDVM();
                    objRDS.RSD_ID = r.RDS_ID;
                    objRDS.RSD_NAME = r.RDS_NAME;
                    rDSSuperProfileInputVM.RSDVMs.Add(objRDS);
                }
            }
            else
            {

            }







            return rDSSuperProfileInputVM;
        }


        public bool SaveRDSSuperProfile(BiskfarmContext context,RDSSuperProfileVM profile)
        {
            try
            {
                db = context;

                RDS_SuperProfile rds = new RDS_SuperProfile();
                rds.principalCo = profile.principalCo;
                rds.nameOfProp1 = profile.nameOfProp1;
                rds.nameOfProp2 = profile.nameOfProp2;
                rds.residenceAddress1 = profile.residenceAddress1;
                rds.residenceAddress2 = profile.residenceAddress2;
                rds.contactNo1 = profile.contactNo1;
                rds.contactNo2 = profile.contactNo2;
                rds.emailAddress = profile.emailAddress;
                rds.closingDayId = profile.closingDayId;
                rds.officeAddress = profile.officeAddress;
                rds.pinCode = profile.pinCode;
                rds.town = profile.town;
                rds.district = profile.district;
                rds.state = profile.state;
                rds.townCode = profile.townCode;
                rds.soHeadQuarterId = profile.soHeadQuarterId;
                rds.soName = profile.soName;
                rds.reasonForAppointment = profile.reasonForAppointment;
                rds.populationOfTown=profile.populationOfTown;
                rds.expectedMonthlyBusiness = profile.expectedMonthlyBusiness;
                rds.nofMarketsLocalTown = profile.nofMarketsLocalTown;
                rds.nofExTown = profile.nofExTown;
                rds.nofRoutesLocalTown = profile.nofRoutesLocalTown;
                rds.nofRoutesExTown = profile.nofRoutesExTown;
                rds.totNofRoutes=profile.totNofRoutes;
                rds.totNofMarkets=profile.totNofMarkets;
                rds.godownAddress = profile.godownAddress;
                rds.nofDeliveryUnit = profile.nofDeliveryUnit;
                rds.secondaryOrderBillingSytem = profile.secondaryOrderBillingSytem;
                rds.areaOfGodown = profile.areaOfGodown;
                rds.dms = profile.dms;
                rds.nonDms = profile.nonDms;
                rds.scheduleDayOfPrimaryInvoicing = profile.scheduleDayOfPrimaryInvoicing;
                rds.expectedNofInvoices = profile.expectedNofInvoices;
                rds.valuePerOrder = profile.valuePerOrder;
                rds.cbbPerOrder = profile.cbbPerOrder;
                rds.areaOfOp = profile.areaOfOp;
                rds.inventoryNormPlan = profile.inventoryNormPlan;
                rds.marketCreditPlan = profile.marketCreditPlan;
                rds.rdIvst = profile.rdIvst;
                rds.rdsSubsidyReq = profile.rdsSubsidyReq;
                rds.nofDSIRSPlanned = profile.nofDSIRSPlanned;
                rds.nofMandays = profile.nofMandays;
                rds.asmComment = profile.asmComment;
                rds.bmFeedback = profile.bmFeedback;
                rds.yearOfEstablishment = profile.yearOfEstablishment;
                rds.gst = profile.gst;
                rds.panCard = profile.panCard;
                rds.fssai = profile.fssai;
                rds.bankName = profile.bankName;
                rds.branchName = profile.branchName;
                rds.accNo = profile.accNo;
                rds.ifsc = profile.ifsc;
                rds.typeOfAC = profile.typeOfAC;
                rds.paymentMode = profile.paymentMode;
                rds.transitDay = profile.transitDay;
                rds.typeOfOwnership = profile.typeOfOwnership;
                rds.personIncharge = profile.personIncharge;
                rds.mobileNofPersonIncharge = profile.mobileNofPersonIncharge;
                rds.sourceOfFund = profile.sourceOfFund;
                rds.branchAddress = profile.branchAddress;
                rds.recommendedBy = profile.recommendedBy;
                rds.approvedBy= profile.approvedBy;
                rds.acceptedBy= profile.acceptedBy;
                if (rds.reasonForAppointment == 1)
                {
                    rds.replacementRDSId = profile.replacementRDSId;
                }                
                rds.soId = profile.soId;

                rds.dateOfEntry = profile.dateOfEntry;
                rds.rdApproved=profile.rdApproved;
                db.RDS_SuperProfile.Add(rds);
                db.SaveChanges();

                foreach (var dst in profile.distributorsList)
                {

                    RDS_SuperProfile_CurrentBusinessDetails currentBusiness = new RDS_SuperProfile_CurrentBusinessDetails();
                    currentBusiness.distributorForCompany = dst.distributorForCompany;
                    currentBusiness.rdsSuperProfileId = rds.rdsSuperProfileId;
                    currentBusiness.nofOutlets = dst.nofOutlets;
                    currentBusiness.nofRoutes = dst.nofRoutes;
                    currentBusiness.currentAvgMonthlyBusiness = dst.currentAvgMonthlyBusiness;
                    currentBusiness.paymentTerm = dst.paymentTerm;
                    currentBusiness.dateOfAppointment = dst.dateOfAppointment;

                    db.RDS_SuperProfile_CurrentBusinessDetails.Add(currentBusiness);
                    db.SaveChanges();
                }

                foreach (var sub in profile.SubStockist)
                {
                    RDS_SuperProfile_RouteSubStockist subStockist = new RDS_SuperProfile_RouteSubStockist();
                    subStockist.rdsSuperProfileId = rds.rdsSuperProfileId;
                    subStockist.nameOfRouteSubStockist = sub.nameOfRouteSubStockist;
                    subStockist.freqOfVisit = sub.freqOfVisit;
                    subStockist.distanceFromRDS = sub.distanceFromRDS;
                    subStockist.expectedBusiness = sub.expectedBusiness;
                    subStockist.outlets = sub.outlets;

                    db.RDS_SuperProfile_RouteSubStockist.Add(subStockist);
                    db.SaveChanges();
                }

                return true;
            }
           catch(Exception ex)
            {
                return false;
            }

        }

        public RDSSuperProfileVM GetProfileById(BiskfarmContext context,int id, string conStr)
        {
            db = context;
            RDS_SuperProfile profile=db.RDS_SuperProfile.Where(r=>r.rdsSuperProfileId == id).FirstOrDefault();

            RDSSuperProfileVM rds=new RDSSuperProfileVM();

            rds.soId = profile.soId;
            rds.principalCo = profile.principalCo;
            rds.nameOfProp1 = profile.nameOfProp1;
            rds.nameOfProp2 = profile.nameOfProp2;
            rds.residenceAddress1 = profile.residenceAddress1;
            rds.residenceAddress2 = profile.residenceAddress2;
            rds.contactNo1 = profile.contactNo1;
            rds.contactNo2 = profile.contactNo2;
            rds.emailAddress = profile.emailAddress;
            rds.closingDayId = profile.closingDayId;
            rds.officeAddress = profile.officeAddress;
            rds.pinCode = profile.pinCode;
            rds.town = profile.town;
            rds.district = profile.district;
            rds.state = profile.state;
            rds.townCode = profile.townCode;
            rds.soHeadQuarterId = profile.soHeadQuarterId;
            rds.soName = profile.soName;
            rds.reasonForAppointment = profile.reasonForAppointment;
            rds.populationOfTown = profile.populationOfTown;
            rds.expectedMonthlyBusiness = profile.expectedMonthlyBusiness;
            rds.nofMarketsLocalTown = (int)profile.nofMarketsLocalTown;
            rds.nofExTown = (int)profile.nofExTown;
            rds.nofRoutesLocalTown = (int)profile.nofRoutesLocalTown;
            rds.nofRoutesExTown = (int)profile.nofRoutesExTown;
            rds.totNofRoutes = profile.totNofRoutes;
            rds.totNofMarkets = profile.totNofMarkets;
            rds.godownAddress = profile.godownAddress;
            rds.nofDeliveryUnit = profile.nofDeliveryUnit;
            rds.secondaryOrderBillingSytem = profile.secondaryOrderBillingSytem;
            rds.areaOfGodown = profile.areaOfGodown;
            rds.dms = profile.dms;
            rds.nonDms = profile.nonDms;
            rds.scheduleDayOfPrimaryInvoicing = profile.scheduleDayOfPrimaryInvoicing;
            rds.expectedNofInvoices = profile.expectedNofInvoices;
            rds.valuePerOrder = profile.valuePerOrder;
            rds.cbbPerOrder = profile.cbbPerOrder;
            rds.areaOfOp = profile.areaOfOp;
            rds.inventoryNormPlan = profile.inventoryNormPlan;
            rds.marketCreditPlan = profile.marketCreditPlan;
            rds.rdIvst = profile.rdIvst;
            rds.rdsSubsidyReq = profile.rdsSubsidyReq;
            rds.nofDSIRSPlanned = profile.nofDSIRSPlanned;
            rds.nofMandays = profile.nofMandays;
            rds.asmComment = profile.asmComment;
            rds.bmFeedback = profile.bmFeedback;
            rds.yearOfEstablishment = profile.yearOfEstablishment;
            rds.gst = profile.gst;
            rds.panCard = profile.panCard;
            rds.fssai = profile.fssai;
            rds.bankName = profile.bankName;
            rds.branchName = profile.branchName;
            rds.accNo = profile.accNo;
            rds.ifsc = profile.ifsc;
            rds.typeOfAC = profile.typeOfAC;
            rds.paymentMode = profile.paymentMode;
            rds.transitDay = profile.transitDay;
            rds.typeOfOwnership = profile.typeOfOwnership;
            rds.personIncharge = profile.personIncharge;
            rds.mobileNofPersonIncharge = profile.mobileNofPersonIncharge;
            rds.sourceOfFund = profile.sourceOfFund;
            rds.branchAddress = profile.branchAddress;
            //rds.recommendName = db.RDS_Hierarchy.FirstOrDefault(r=>r.hierarchyId== profile.recommendedBy).hierarchyName;
            //rds.approveName = db.RDS_Hierarchy.FirstOrDefault(r => r.hierarchyId == profile.acceptedBy).hierarchyName;
            //rds.acceptedName = db.RDS_Hierarchy.FirstOrDefault(r => r.hierarchyId == profile.approvedBy).hierarchyName;

            rds.dateOfEntry = profile.dateOfEntry;
            rds.replacementRDSId=(int)profile.replacementRDSId;
            rds.rdApproved=profile.rdApproved;

            List<RDS_Distributors> distributors = new List<RDS_Distributors>();
            
            var distList= db.RDS_SuperProfile_CurrentBusinessDetails.Where(r=>r.rdsSuperProfileId==id).ToList();


            foreach (var dst in distList)
            {

                RDS_Distributors currentBusiness = new RDS_Distributors();
                currentBusiness.distributorForCompany = dst.distributorForCompany;
                currentBusiness.nofOutlets = dst.nofOutlets;
                currentBusiness.nofRoutes = dst.nofRoutes;
                currentBusiness.currentAvgMonthlyBusiness = (decimal)dst.currentAvgMonthlyBusiness;
                currentBusiness.paymentTerm = dst.paymentTerm;
                currentBusiness.dateOfAppointment = (DateTime)dst.dateOfAppointment;

                distributors.Add(currentBusiness);
            }

            List<RDS_SubStockist> stockistList = new List<RDS_SubStockist>();

            var stockist=db.RDS_SuperProfile_RouteSubStockist.Where(r=>r.rdsSuperProfileId == id).ToList();

            foreach (var sub in stockist)
            {
                RDS_SubStockist subStockist = new RDS_SubStockist();
                subStockist.nameOfRouteSubStockist = sub.nameOfRouteSubStockist;
                subStockist.freqOfVisit = sub.freqOfVisit;
                subStockist.distanceFromRDS = sub.distanceFromRDS;
                subStockist.expectedBusiness = sub.expectedBusiness;
                subStockist.outlets = sub.outlets;

                stockistList.Add(subStockist);
            }


            rds.SOMasts = new List<SOMast>();
            // var towns=db.TOWN_MASTER.ToList();
            var so = db.SO_MAST.ToList();

            
            foreach (var soMats in so)
            {
                SOMast s = new SOMast();
                s.SO_ID = soMats.SO_ID;
                s.SO_NAME = soMats.SO_NAME;
                s.Head_Qtr = soMats.Head_Qtr;
                s.Home_Town = soMats.Home_Town;
                s.HomeTown_Name = s.HomeTown_Name;

                rds.SOMasts.Add(s);
            }

            int SO_ID = 0;
            if (rds.soId.Contains("SO"))
            {
                var soIdstr = rds.soId.Replace("SO", string.Empty);
                SO_ID = Convert.ToInt32(soIdstr);
            }
            

            List<OutletWiseSalesDatabase> outlet = new List<OutletWiseSalesDatabase>();

            using (SqlConnection con = new SqlConnection(conStr))
            {
                //using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    DataTable DataTbl1 = new DataTable();
                    string qry = "SELECT  NEW_ZONE_GRP REGION,(SELECT DISTINCT R.RSM_NAME FROM RSM_MAST R WHERE R.RSM_ID=VW.RSM_ID)  RSM_NAME,RSM_ID, BM_NAME BM_NAME,BM_ID,\r\n        ASM_NAME ASM_NAME,ASM_ID,\r\n        SO_NAME  SO_NAME,SO_ID,\r\n        RDS_NAME RDS_NAME,RDS_ID,ZONE_STATE\r\nFROM BM_ASM_SO_RDS_MAST VW(NOLOCK)\r\nWHERE RDS_NAME NOT LIKE '%INACTIVE%'";

                    SqlCommand cmd1 = new SqlCommand(qry, con);
                    cmd1.CommandType = CommandType.Text;

                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
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

            rds.RSDVMs = new List<RSDVM>();

            if (SO_ID != 0)
            {
                var rsd = outlet.Where(r => r.SO_ID == SO_ID.ToString()).Select(x => new { x.RDS_ID, x.RDS_NAME }).Distinct().ToList();

                foreach (var r in rsd)
                {
                    RSDVM objRDS = new RSDVM();
                    objRDS.RSD_ID = r.RDS_ID;
                    objRDS.RSD_NAME = r.RDS_NAME;
                    rds.RSDVMs.Add(objRDS);
                }
            }
            else
            {

            }


            rds.distributorsList=distributors;
            rds.SubStockist = stockistList;

            return rds;
        }

        public List<RDS_SuperProfile> GetAll(BiskfarmContext context,string soId)
        {
            db = context;
            return db.RDS_SuperProfile.Where(r=>r.soId==soId).ToList();
        }

    }
}
