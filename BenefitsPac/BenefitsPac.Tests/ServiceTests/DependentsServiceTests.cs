using BenefitsPac.Core.Models.DataModels;
using BenefitsPac.Core.Models.DomainModels;
using BenefitsPac.DataAccess.Abstractions;
using BenefitsPac.Service.Abstractions;
using BenefitsPac.Service.Implementations;
using Moq;
using NUnit.Framework;
using System;

namespace BenefitsPac.Tests.ServiceTests
{
    [TestFixture]
    public class DependentsServiceTests
    {
        private IDependentsService sut;
        private Mock<IDependentsRepository> dependentsRepository;
        private Mock<ILoggerRepository> loggerRepository;

        [SetUp]
        public void SetupTests()
        {
            dependentsRepository = new Mock<IDependentsRepository>();
            loggerRepository = new Mock<ILoggerRepository>();
            sut = new DependentsService(dependentsRepository.Object, loggerRepository.Object);
        }

        #region Create
        [Test]
        public void Create_CallsLoggerWhenExceptionThrown()
        {
            try
            {
                dependentsRepository.Setup(x => x.Create(It.IsAny<DependentDataModel>())).Throws(new Exception());
            }
            catch (Exception)
            {
                loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Once);
            }
        }

        [TestCase(true, 0)]
        [TestCase(false, 1)]
        public void Create_CanHandleNull(bool isNull, int timesRepoCalled)
        {
            DependentModel dependentModel = isNull ? null : new DependentModel();

            var result = sut.Create(dependentModel);

            dependentsRepository.Verify(x => x.Create(It.IsAny<DependentDataModel>()), Times.Exactly(timesRepoCalled));
            loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Never);
        }
        #endregion

        #region GetByEmployeeId
        [Test]
        public void GetByEmployeeId_CallsLoggerWhenExceptionThrown()
        {
            try
            {
                dependentsRepository.Setup(x => x.GetByEmployeeId(It.IsAny<int>())).Throws(new Exception());
            }
            catch (Exception)
            {
                loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Once);
            }
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        public void GetByEmployeeId_CanHandleZeroParams(int employeeId, int timesRepoCalled)
        {
            var result = sut.GetByEmployeeId(employeeId);

            dependentsRepository.Verify(x => x.GetByEmployeeId(It.IsAny<int>()), Times.Exactly(timesRepoCalled));
            loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Never);
        }
        #endregion

        #region Delete
        [Test]
        public void Delete_CallsLoggerWhenExceptionThrown()
        {
            try
            {
                dependentsRepository.Setup(x => x.Delete(It.IsAny<int>())).Throws(new Exception());
            }
            catch (Exception)
            {
                loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Once);
            }
        }
        #endregion
    }
}
