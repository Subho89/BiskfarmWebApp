using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public RDSSuperProfileInputVM GetRDSSuperProfileInputParameters(BiskfarmContext context)
        {
            db = context;
            RDSSuperProfileInputVM rDSSuperProfileInputVM = new RDSSuperProfileInputVM();

            rDSSuperProfileInputVM.Towns = new List<TownMastVM>();
            rDSSuperProfileInputVM.SOMasts = new List<SOMast>();
            rDSSuperProfileInputVM.Hierarchy = new List<HierarchyVM>();

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
                rds.expectedMonthlyBusiness = profile.expectedMonthlyBusiness;
                rds.nofMarketsLocalTown = profile.nofMarketsLocalTown;
                rds.nofExTown = profile.nofExTown;
                rds.nofRoutesLocalTown = profile.nofRoutesLocalTown;
                rds.nofRoutesExTown = profile.nofRoutesExTown;
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
                rds.investmentProposedAndAgreed = profile.investmentProposedAndAgreed;
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

                rds.dateOfEntry = profile.dateOfEntry;

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

        public List<RDS_SuperProfile> GetAll(BiskfarmContext context)
        {
            db = context;
            return db.RDS_SuperProfile.ToList();
        }

    }
}
