namespace BenefitsPac.Core.Models.DomainModels
{
    public class BenefitsBreakdownModel
    {
        public decimal SalaryPerYear { get; set; }
        public decimal SalaryPerPayPeriod { get; set; }
        public decimal BenefitsCostPerYear { get; set; }
        public decimal BenefitsCostPerPayPeriod { get; set; }
        public string PayPeriodFrequency { get; set; }
    }
}
