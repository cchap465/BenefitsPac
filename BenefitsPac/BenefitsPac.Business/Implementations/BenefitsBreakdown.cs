using BenefitsPac.Business.Abstractions;
using BenefitsPac.Core.Models.DataModels;
using BenefitsPac.Core.Models.DomainModels;
using System.Collections.Generic;

namespace BenefitsPac.Business
{
    public class BenefitsBreakdown : IBenefitsBreakdown
    {
        public BenefitsBreakdownModel GetBenefitsBreaksown(EmployeeSalaryDataModel employeeModel, IEnumerable<BenefitCostDataModel> benefitDeductionModel)
        {
            decimal yearlyBenefitsCost = GetYearlyTotal(employeeModel, benefitDeductionModel);

            return new BenefitsBreakdownModel()
            {
                BenefitsCostPerYear = yearlyBenefitsCost,
                BenefitsCostPerPayPeriod = yearlyBenefitsCost / employeeModel.PaymentFrequency,
                SalaryPerYear = employeeModel.SalaryByPayPeriod * employeeModel.PaymentFrequency,
                PayPeriodFrequency = GetPaymentFrequencyVerbiage(employeeModel.PaymentFrequency),
                SalaryPerPayPeriod = employeeModel.SalaryByPayPeriod,
            };
        }

        private decimal GetYearlyTotal(EmployeeSalaryDataModel employeeModel, IEnumerable<BenefitCostDataModel> benefitDeductionModel)
        {
            decimal totalYearlyCost = 0.00m;

            foreach (var b in benefitDeductionModel)
            {
                totalYearlyCost += (b.BaseDeductionCost - (b.DiscountAmount * b.BaseDeductionCost));
            }

            return totalYearlyCost;
        }

        private string GetPaymentFrequencyVerbiage(int paymentFrequency)
        {
            return (paymentFrequency.Equals(26)) ? "Bi-weekly" : "Annual";
        }
    }
}
