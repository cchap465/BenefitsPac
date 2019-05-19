using BenefitsPac.Core.Models.ApiModel;

namespace BenefitsPac.Core.Models
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
            EmployeeId = dependentModel.EmployeeId;
            DependentId = dependentModel.DependentId;
            DependentName = dependentModel.DependentName;
            BenefitCost = new BenefitCostDataModel()
            {
                IsDependent = true,
                DiscountAmount = discountAmount,
                BaseDeductionCost = 500,
            };
        }
    }
}
