using BenefitsPac.Core.Models.DataModels;
using NUnit.Framework;

namespace BenefitsPac.Tests.CoreTests
{
    [TestFixture]
    public class EmployeeDataModelTests
    {
        [Test]
        public void Constructor_CanHandleNulls()
        {
            int discountAmount = 0;
            decimal expBaseCost = 1000;
            int expPaymentFreq = 26;
            decimal salaryByPayPeriod = 2000;

            EmployeeDataModel expDependentDataModel = new EmployeeDataModel()
            {
                EmployeeName = string.Empty
            };

            EmployeeDataModel sut = new EmployeeDataModel(null, 0);

            Assert.AreEqual(expDependentDataModel.EmployeeId, sut.EmployeeId);
            Assert.AreEqual(expDependentDataModel.EmployeeName, sut.EmployeeName);
            Assert.IsTrue(sut.BenefitCost.IsEmployee);
            Assert.IsFalse(sut.BenefitCost.IsDependent);
            Assert.AreEqual(discountAmount, sut.BenefitCost.DiscountAmount);
            Assert.AreEqual(expBaseCost, sut.BenefitCost.BaseDeductionCost);
            Assert.AreEqual(expPaymentFreq, sut.EmployeeSalaryData.PaymentFrequency);
            Assert.AreEqual(salaryByPayPeriod, sut.EmployeeSalaryData.SalaryByPayPeriod);
        }
    }
}
