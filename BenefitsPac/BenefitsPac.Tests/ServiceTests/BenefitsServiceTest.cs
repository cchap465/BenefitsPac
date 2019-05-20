using BenefitsPac.Business.Abstractions;
using BenefitsPac.Core.Models.DataModels;
using BenefitsPac.DataAccess.Abstractions;
using BenefitsPac.Service.Abstractions;
using BenefitsPac.Service.Implementations;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BenefitsPac.Tests.ServiceTests
{
    [TestFixture]
    public class BenefitsServiceTest
    {
        private IBenefitsService sut;
        private Mock<IBenefitsBreakdown> benefitsBreakdown;
        private Mock<IEmployeeRepository> employeeRepository;
        private Mock<IBenefitsRepository> benefitsRepository;
        private Mock<ILoggerRepository> loggerRepository;

        [SetUp]
        public void SetupTests()
        {
            benefitsBreakdown = new Mock<IBenefitsBreakdown>();
            employeeRepository = new Mock<IEmployeeRepository>();
            benefitsRepository = new Mock<IBenefitsRepository>();
            loggerRepository = new Mock<ILoggerRepository>();
            sut = new BenefitsService(benefitsBreakdown.Object, employeeRepository.Object,
                benefitsRepository.Object, loggerRepository.Object);
        }

        #region GetBenefitsCostBreakdownByEmployeeId
        [Test]
        public void GetBenefitsCostBreakdownByEmployeeId_CallsLoggerWhenExceptionThrown()
        {
            try
            {
                employeeRepository.Setup(x => x.GetEmployeeSalaryData(It.IsAny<int>())).Throws(new Exception());
            }
            catch (Exception)
            {
                loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Once);
            }
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        public void GetBenefitsCostBreakdownByEmployeeId_CanHandleNull(int employeeId, int timesRepoCalled)
        {
            var result = sut.GetBenefitsCostBreakdownByEmployeeId(employeeId);

            benefitsBreakdown.Verify(x => x.GetBenefitsBreaksown(
                It.IsAny<EmployeeSalaryDataModel>(), It.IsAny<IEnumerable<BenefitCostDataModel>>()), Times.Exactly(timesRepoCalled));
            employeeRepository.Verify(x => x.GetEmployeeSalaryData(It.IsAny<int>()), Times.Exactly(timesRepoCalled));
            benefitsRepository.Verify(x => x.GetBenefitsCostsByEmployeeId(It.IsAny<int>()), Times.Exactly(timesRepoCalled));
            loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Never);
        }
        #endregion
    }
}
