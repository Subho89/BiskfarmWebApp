using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.Services
{
    public class RDSSuperProfileVM
    {
        public int rdsSuperProfileId { get; set; }
        public string? principalCo { get; set; }
        public string? nameOfProp1 { get; set; }
        public string? nameOfProp2 { get; set; }
        public string? residenceAddress1 { get; set; }
        public string? residenceAddress2 { get; set; }
        public string? contactNo1 { get; set; }
        public string? contactNo2 { get; set; }
        public string? emailAddress { get; set; }
        public int closingDayId { get; set; }
        public string? officeAddress { get; set; }
        public string? pinCode { get; set; }
        public string? town { get; set; }
        public string? district { get; set; }
        public string? state { get; set; }
        public string? townCode { get; set; }
        public int soHeadQuarterId { get; set; }
        public string? soName { get; set; }
        public int reasonForAppointment { get; set; }
        public string populationOfTown { get; set; }
        public Nullable<decimal> expectedMonthlyBusiness { get; set; }
        public int nofMarketsLocalTown { get; set; }
        public int nofExTown { get; set; }
        public int nofRoutesLocalTown { get; set; }
        public int nofRoutesExTown { get; set; }
        public string? totNofMarkets { get; set; }
        public string? totNofRoutes { get; set; }
        public string? godownAddress { get; set; }
        public int nofDeliveryUnit { get; set; }
        public int secondaryOrderBillingSytem { get; set; }
        public string? areaOfGodown { get; set; }
        public int unitDetailsMechanical { get; set; }
        public int unitDetailsManual { get; set; }
        public int dms { get; set; }
        public int nonDms { get; set; }
        public int scheduleDayOfPrimaryInvoicing { get; set; }
        public int expectedNofInvoices { get; set; }
        public Nullable<decimal> valuePerOrder { get; set; }
        public Nullable<decimal> cbbPerOrder { get; set; }
        public string? areaOfOp { get; set; }
        public int inventoryNormPlan { get; set; }
        public int marketCreditPlan { get; set; }
        public Nullable<bool> rdIvst { get; set; }
        public Nullable<bool> rdsSubsidyReq { get; set; }
        public int nofDSIRSPlanned { get; set; }
        public int nofMandays { get; set; }
        public string? asmComment { get; set; }
        public string? bmFeedback { get; set; }
        public int yearOfEstablishment { get; set; }
        public string? gst { get; set; }
        public string? panCard { get; set; }
        public string? fssai { get; set; }
        public string? bankName { get; set; }
        public string? branchName { get; set; }
        public string? accNo { get; set; }
        public string? ifsc { get; set; }
        public string? branchAddress { get; set; }
        public int typeOfAC { get; set; }
        public int paymentMode { get; set; }
        public int transitDay { get; set; }
        public int typeOfOwnership { get; set; }
        public string? personIncharge { get; set; }
        public string? mobileNofPersonIncharge { get; set; }
        public string? sourceOfFund { get; set; }
        public int recommendedBy { get; set; }
        public int approvedBy { get; set; }
        public int acceptedBy { get; set; }
        public DateOnly dateOfEntry { get; set; }
        public string recommendName { get; set; }
        public string approveName { get; set; }
        public string acceptedName { get; set; }
        public List<RDS_Distributors> distributorsList { get; set; }
        public List<RDS_SubStockist> SubStockist { get; set; }
        public List<SOMast> SOMasts { get; set; }
    }

    public class RDS_Distributors
    {
        public string distributorForCompany { get; set; }
        public DateTime dateOfAppointment { get; set; }
        public decimal currentAvgMonthlyBusiness { get; set; }
        public string paymentTerm { get; set; }
        public string nofRoutes { get; set; }
        public string nofOutlets { get; set; }
        
    }


    public class RDS_Authorization
    {
        public int hierarchyRecommended { get; set; }
        public int hierarchyApproved { get; set; }
        public int hierarchyAccepted { get; set; }
    }
    public class RDS_SubStockist
    {
        public int rdsSuperProfileSubStockistId { get; set; }
        public string? nameOfRouteSubStockist { get; set; }
        public Nullable<int> freqOfVisit { get; set; }
        public string? distanceFromRDS { get; set; }
        public string? expectedBusiness { get; set; }
        public string? outlets { get; set; }
    }

    public class RDSSuperProfileInputVM
    {
        public List<HierarchyVM> Hierarchy { get; set; }
        public List<TownMastVM> Towns { get; set; }
        public List<SOMast> SOMasts { get; set; }
    }

    public class HierarchyVM
    {
        public int hierarchyId { get; set; }
        public string hierarchyName { get; set; }
    }
    public class TownMastVM
    {
        public long TOWN_CODE { get; set; }
        public string TOWN_NAME { get; set; }
        public int STATE_CODE { get; set; }
        public int DISTRICT_CODE { get; set; }
    }

    public class SOMast
    {
        public int SO_ID { get; set; }
        public string SO_NAME { get; set; }
        public Nullable<int> ASM_ID { get; set; }
        public string active { get; set; }
        public string Head_Qtr { get; set; }
        public string Home_Town { get; set; }
        public string Desig_Code { get; set; }
        public Nullable<int> FC_ID { get; set; }
        public Nullable<System.DateTime> DOCT { get; set; }
        public string HomeTown_Name { get; set; }
        public Nullable<bool> ReLoc_Allow { get; set; }
        public string Merchandiser_yn { get; set; }
        public string large_img { get; set; }
    }
}
