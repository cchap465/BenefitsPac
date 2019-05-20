using BenefitsPac.Core.Models.DataModels;
using NUnit.Framework;

namespace BenefitsPac.Tests.CoreTests
{
    [TestFixture]
    public class DependentDataModelTests
    {
        [Test]
        public void Constructor_CanHandleNulls()
        {
            int discountAmount = 0;
            decimal expBaseCost = 500;
            DependentDataModel expDependentDataModel = new DependentDataModel()
            {
                DependentName = string.Empty
            };

            DependentDataModel sut = new DependentDataModel(null, 0);

            Assert.AreEqual(expDependentDataModel.EmployeeId, sut.EmployeeId);
            Assert.AreEqual(expDependentDataModel.DependentId, sut.DependentId);
            Assert.AreEqual(expDependentDataModel.DependentName, sut.DependentName);
            Assert.IsTrue(sut.BenefitCost.IsDependent);
            Assert.IsFalse(sut.BenefitCost.IsEmployee);
            Assert.AreEqual(discountAmount, sut.BenefitCost.DiscountAmount);
            Assert.AreEqual(expBaseCost, sut.BenefitCost.BaseDeductionCost);
        }
    }
}
