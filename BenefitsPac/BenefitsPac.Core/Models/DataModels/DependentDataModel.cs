using BenefitsPac.Core.Models.DomainModels;

namespace BenefitsPac.Core.Models.DataModels
{
    public class DependentDataModel
    {
        public int DependentId { get; set; }
        public string DependentName { get; set; }
        public int EmployeeId { get; set; }
        public BenefitCostDataModel BenefitCost { get; set; }

        public DependentDataModel() { }

        public DependentDataModel(DependentModel dependentModel, decimal discountAmount)
        {
            EmployeeId = dependentModel?.EmployeeId ?? 0;
            DependentId = dependentModel?.DependentId ?? 0;
            DependentName = dependentModel?.DependentName ?? string.Empty;
            BenefitCost = new BenefitCostDataModel()
            {
                IsDependent = true,
                DiscountAmount = discountAmount,
                BaseDeductionCost = 500,
            };
        }
    }
}
