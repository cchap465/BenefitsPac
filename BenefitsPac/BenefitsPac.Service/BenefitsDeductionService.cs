using BenefitsPac.Core.Models;

namespace BenefitsPac.Service
{
    public class BenefitsDeductionService
    {
        public decimal GetTotalYearlyCost(EmployeeModel employeeModel, BenefitDeductionModel benefitDeductionModel)
        {
            return GetYearlyTotal(employeeModel, benefitDeductionModel);
        }

        public decimal GetCostByPayPeriod(EmployeeModel employeeModel, BenefitDeductionModel benefitDeductionModel)
        {
            return GetYearlyTotal(employeeModel, benefitDeductionModel) / 26;
        }

        private decimal GetYearlyTotal(EmployeeModel employeeModel, BenefitDeductionModel benefitDeductionModel)
        {
            decimal totalYearlyCost = benefitDeductionModel.CostPerEmployee;

            if (employeeModel.HasDiscount)
                totalYearlyCost -= (employeeModel.Discount * benefitDeductionModel.CostPerEmployee);

            foreach (var dependent in employeeModel.Dependents)
            {
                decimal dependentCost = (benefitDeductionModel.CostPerDependent - (employeeModel.Discount * benefitDeductionModel.CostPerDependent));
                totalYearlyCost += dependentCost;
            }

            return totalYearlyCost;

        }
    }
}
