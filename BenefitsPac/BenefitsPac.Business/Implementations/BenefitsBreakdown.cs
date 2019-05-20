using BenefitsPac.Business.Abstractions;
using BenefitsPac.Core.Models.DataModels;
using BenefitsPac.Core.Models.DomainModels;
using System.Collections.Generic;

namespace BenefitsPac.Business
{
    public class BenefitsBreakdown : IBenefitsBreakdown
    {
        public BenefitsBreakdownModel GetBenefitsBreaksown(EmployeeSalaryDataModel employeeSalaryDataModel, 
            IEnumerable<BenefitCostDataModel> benefitDeductionModels)
        {
            if (employeeSalaryDataModel == null || benefitDeductionModels == null) return null;

            decimal yearlyBenefitsCost = GetYearlyTotal(benefitDeductionModels);

            return new BenefitsBreakdownModel()
            {
                BenefitsCostPerYear = yearlyBenefitsCost,
                BenefitsCostPerPayPeriod = yearlyBenefitsCost / employeeSalaryDataModel.PaymentFrequency,
                SalaryPerYear = employeeSalaryDataModel.SalaryByPayPeriod * employeeSalaryDataModel.PaymentFrequency,
                PayPeriodFrequency = GetPaymentFrequencyVerbiage(employeeSalaryDataModel.PaymentFrequency),
                SalaryPerPayPeriod = employeeSalaryDataModel.SalaryByPayPeriod,
            };
        }

        private decimal GetYearlyTotal(IEnumerable<BenefitCostDataModel> benefitDeductionModels)
        {
            decimal totalYearlyCost = 0.00m;

            foreach (var b in benefitDeductionModels)
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
