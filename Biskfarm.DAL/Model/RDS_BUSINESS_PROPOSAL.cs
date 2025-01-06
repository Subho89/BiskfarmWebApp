using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Model
{
    public class RDS_BUSINESS_PROPOSAL
    {
        [Key]
        public int rdsBusinessProposalId { get; set; }
        public string? principalCo { get; set; }
        public Nullable<System.DateTime> dateOfEntry { get; set; }
        public string? nameOfRDSSuperStockist { get; set; }
        public Nullable<int> appointmentPlanId { get; set; }
        public string? town { get; set; }
        public string? district { get; set; }
        public string? state { get; set; }
        public Nullable<decimal> salesGenRetail { get; set; }
        public Nullable<decimal> salesKeyOutlet { get; set; }
        public Nullable<decimal> salesWholesale { get; set; }
        public Nullable<decimal> salesOther { get; set; }
        public Nullable<decimal> stockDayNormTotal { get; set; }
        public Nullable<decimal> stockValueNormTotal { get; set; }
        public Nullable<decimal> marketDiscCatGenRetail { get; set; }
        public Nullable<decimal> marketDiscCatKeyOutlet { get; set; }
        public Nullable<decimal> marketDiscCatWholesale { get; set; }
        public Nullable<decimal> marketDiscCatOther { get; set; }
        public Nullable<decimal> outletsGR { get; set; }
        public Nullable<decimal> outletsKO { get; set; }
        public Nullable<decimal> outletsW { get; set; }
        public Nullable<decimal> outletsO { get; set; }
        public Nullable<decimal> cdNormGR { get; set; }
        public Nullable<decimal> cdNormKO { get; set; }
        public Nullable<decimal> cdNormW { get; set; }
        public Nullable<decimal> cdNormO { get; set; }
        public Nullable<decimal> cvNormGR { get; set; }
        public Nullable<decimal> cvNormKO { get; set; }
        public Nullable<decimal> cvNormW { get; set; }
        public Nullable<decimal> cvNormO { get; set; }
        public Nullable<decimal> com1Tot { get; set; }
        public Nullable<decimal> com2Tot { get; set; }
        public Nullable<decimal> othersTot { get; set; }
        public string? routesWeekly { get; set; }
        public string? routesFortNight { get; set; }
        public string? outletsWeekly { get; set; }
        public string? outletsFortNight { get; set; }
        public string? salesWeekly { get; set; }
        public string? salesFortNight { get; set; }
        public string? ourShareOfBusiness { get; set; }
        public string? nofUnits { get; set; }
        public string? nofAutomated { get; set; }
        public string? nofManual { get; set; }
        public string? nofExclusive { get; set; }
        public string? nofShared { get; set; }
        public string? unitShareAutomated { get; set; }
        public string? unitShareManual { get; set; }
        public string? driverAutomated { get; set; }
        public string? driverManual { get; set; }
        public string? helperAutomated { get; set; }
        public string? helperManual { get; set; }
        public string? unitRunningCostAutomated { get; set; }
        public string? unitRunningCostManual { get; set; }
        public Nullable<decimal> salesmanSalary { get; set; }
        public Nullable<decimal> salesmanTA { get; set; }
        public Nullable<decimal> godownAmount { get; set; }
        public string? godownRemarks { get; set; }
        public Nullable<decimal> computerAmount { get; set; }
        public string? computerRemarks { get; set; }
        public Nullable<decimal> officeAmount { get; set; }
        public string? officeRemarks { get; set; }
        public Nullable<decimal> overheadAmount { get; set; }
        public string? overheadRemarks { get; set; }
        public Nullable<decimal> accountingAmount { get; set; }
        public string? accountingRemarks { get; set; }
        public Nullable<decimal> sundryAmount { get; set; }
        public string? sundryRemarks { get; set; }
        public Nullable<decimal> siVal { get; set; }
        public string? siDays { get; set; }
        public string? siNorm { get; set; }
        public Nullable<decimal> moVal { get; set; }
        public string? moDays { get; set; }
        public string? moNorm { get; set; }
        public Nullable<decimal> claimsVal { get; set; }
        public string? claimsDays { get; set; }
        public string? claimsNorm { get; set; }
        public Nullable<decimal> comCreditVal { get; set; }
        public string? roiPlanPercent { get; set; }
        public Nullable<decimal> rdsSubsidyApproved { get; set; }
        public Nullable<int> recommended { get; set; }
        public Nullable<int> accepted { get; set; }
        public Nullable<int> approved { get; set; }
        public Nullable<decimal> rdsSubsidyProposed { get; set; }
        public Nullable<decimal> salesTot { get; set; }
        public Nullable<decimal> outletsTot { get; set; }
        public Nullable<decimal> cdNormTot { get; set; }
        public Nullable<decimal> cvNormTot { get; set; }
        public Nullable<decimal> comTot { get; set; }
        public Nullable<decimal> routesTot { get; set; }
        public Nullable<decimal> outletsTotal { get; set; }
        public Nullable<decimal> salesTotal { get; set; }
        public Nullable<decimal> totRedAuto { get; set; }
        public Nullable<decimal> totRedManual { get; set; }
        public Nullable<decimal> totUnit { get; set; }
        public Nullable<decimal> dsCost { get; set; }
        public Nullable<decimal> totExpenditure { get; set; }
        public Nullable<decimal> indirectCost { get; set; }
        public Nullable<decimal> giVal { get; set; }
        public Nullable<decimal> niVal { get; set; }
        public Nullable<decimal> arVal { get; set; }
        public Nullable<int> giDays { get; set; }
        public Nullable<int> giNorm { get; set; }
        public Nullable<decimal> tmsOut { get; set; }
        public Nullable<decimal> marginPercent { get; set; }
        public Nullable<decimal> giOut { get; set; }
        public Nullable<decimal> tmDiscount { get; set; }
        public Nullable<decimal> geOut { get; set; }
        public Nullable<decimal> reExpense { get; set; }
        public Nullable<decimal> salesmanExpense { get; set; }
        public Nullable<decimal> indirectExpense { get; set; }
        public Nullable<decimal> grossExpenditure { get; set; }
        public Nullable<decimal> netMargin { get; set; }
        public Nullable<decimal> netMarginPercent { get; set; }
        public Nullable<decimal> roiCalculation { get; set; }
        public Nullable<decimal> rdsSubsidyEstimated { get; set; }
    }
}
