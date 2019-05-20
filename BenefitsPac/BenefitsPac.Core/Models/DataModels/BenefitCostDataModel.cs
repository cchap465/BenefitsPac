namespace BenefitsPac.Core.Models.DataModels
{
    public class BenefitCostDataModel
    {
        public bool IsDependent { get; set; }
        public bool IsEmployee { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal BaseDeductionCost { get; set; }
    }
}
