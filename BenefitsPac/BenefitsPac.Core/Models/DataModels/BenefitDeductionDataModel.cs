namespace BenefitsPac.Core.Models
{
    public class EmployeeSalaryDataModel
    {
        public int PaymentFrequency => 26;
        public decimal SalaryByPayPeriod => 2000;
    }

    public class BenefitCostDataModel
    {
        public bool IsEmployee { get; set; }
        public bool IsDependent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal BaseDeductionCost { get; set; }
    }
}
