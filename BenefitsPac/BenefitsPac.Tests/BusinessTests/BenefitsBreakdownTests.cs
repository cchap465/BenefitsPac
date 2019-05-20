using BenefitsPac.Business;
using BenefitsPac.Business.Abstractions;
using BenefitsPac.Core.Models.DataModels;
using BenefitsPac.Core.Models.DomainModels;
using NUnit.Framework;
using System.Collections.Generic;

namespace BenefitsPac.Tests.BusinessTests
{
    [TestFixture]
    public class BenefitsBreakdownTests
    {
        private IBenefitsBreakdown sut;

        [SetUp]
        public void SetupTests()
        {
            sut = new BenefitsBreakdown();
        }

        #region GetBenefitsBreaksown
        [Test]
        public void GetBenefitsBreaksown_CanHandleNulls()
        {
            BenefitsBreakdownModel expResult = new BenefitsBreakdownModel
            {
                SalaryPerYear = 26,
                SalaryPerPayPeriod = 1,
                PayPeriodFrequency = "Bi-weekly"
            };

            var result = sut.GetBenefitsBreaksown(null, null);

            Assert.IsNull(result);
        }

        [TestCase(1000, .10, 5, 4500)]
        public void GetBenefitsCostBreakdownByEmployeeId_CanHandleNull(decimal baseDeductionCost, decimal discount,
            int numOfDeductionModels, decimal expYearlyCost)
        {
            EmployeeSalaryDataModel employeeSalaryDataModel = new EmployeeSalaryDataModel();
            List<BenefitCostDataModel> benefitDeductionModels = new List<BenefitCostDataModel>();

            for (int i = 0; i < numOfDeductionModels; i++)
            {
                benefitDeductionModels.Add(new BenefitCostDataModel { BaseDeductionCost = baseDeductionCost, DiscountAmount = discount });
            }

            BenefitsBreakdownModel expResult = new BenefitsBreakdownModel
            {
                SalaryPerYear = employeeSalaryDataModel.SalaryByPayPeriod * employeeSalaryDataModel.PaymentFrequency,
                SalaryPerPayPeriod = employeeSalaryDataModel.SalaryByPayPeriod,
                BenefitsCostPerYear = expYearlyCost,
                BenefitsCostPerPayPeriod = expYearlyCost / employeeSalaryDataModel.PaymentFrequency,
                PayPeriodFrequency = "Bi-weekly"
            };

            var result = sut.GetBenefitsBreaksown(employeeSalaryDataModel, benefitDeductionModels);

            Assert.AreEqual(expResult.BenefitsCostPerPayPeriod, result.BenefitsCostPerPayPeriod);
            Assert.AreEqual(expResult.BenefitsCostPerYear, result.BenefitsCostPerYear);
            Assert.AreEqual(expResult.SalaryPerPayPeriod, result.SalaryPerPayPeriod);
            Assert.AreEqual(expResult.SalaryPerYear, result.SalaryPerYear);
            Assert.AreEqual(expResult.PayPeriodFrequency, result.PayPeriodFrequency);
        }
        #endregion
    }
}
