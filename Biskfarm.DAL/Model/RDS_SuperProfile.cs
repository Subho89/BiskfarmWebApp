using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Model
{
    public class RDS_SuperProfile
    {
        [Key]
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
        public Nullable<decimal> expectedMonthlyBusiness { get; set; }
        public string? populationOfTown { get; set; }
        public Nullable<int> nofMarketsLocalTown { get; set; }
        public Nullable<int> nofExTown { get; set; }
        public Nullable<int> nofRoutesLocalTown { get; set; }
        public Nullable<int> nofRoutesExTown { get; set; }
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
        public string? branchAddress { get; set; }
        public Nullable<int> replacementRDSId { get; set; }
        public string? soId { get; set; }
        public Nullable<bool> rdApproved { get; set; }
    }
}
