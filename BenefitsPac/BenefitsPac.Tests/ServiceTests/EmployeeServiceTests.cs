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
    public class EmployeeServiceTests
    {
        private IEmployeeService sut;
        private Mock<IEmployeeRepository> employeeRepository;
        private Mock<ILoggerRepository> loggerRepository;

        [SetUp]
        public void SetupTests()
        {
            employeeRepository = new Mock<IEmployeeRepository>();
            loggerRepository = new Mock<ILoggerRepository>();
            sut = new EmployeeService(employeeRepository.Object, loggerRepository.Object);
        }

        #region Create
        [Test]
        public void Create_CallsLoggerWhenExceptionThrown()
        {
            try
            {
                employeeRepository.Setup(x => x.Create(It.IsAny<EmployeeDataModel>())).Throws(new Exception());
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
            EmployeeModel employeeModel = isNull ? null : new EmployeeModel();

            sut.Create(employeeModel);

            employeeRepository.Verify(x => x.Create(It.IsAny<EmployeeDataModel>()), Times.Exactly(timesRepoCalled));
            loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Never);
        }
        #endregion

        #region Update
        [Test]
        public void Update_CallsLoggerWhenExceptionThrown()
        {
            try
            {
                employeeRepository.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<string>())).Throws(new Exception());
            }
            catch (Exception)
            {
                loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Once);
            }
        }

        [TestCase(0, "", 0)]
        [TestCase(1, null, 0)]
        [TestCase(1, "", 0)]
        [TestCase(0, "test", 0)]
        [TestCase(1, "test", 1)]
        public void Update_CanHandleNull(int id, string name, int timesRepoCalled)
        {
            sut.UpdateEmployeeName(id, name);

            employeeRepository.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<string>()), Times.Exactly(timesRepoCalled));
            loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Never);
        }
        #endregion

        #region GetByEmployeeId
        [Test]
        public void GetByEmployeeId_CallsLoggerWhenExceptionThrown()
        {
            try
            {
                employeeRepository.Setup(x => x.GetById(It.IsAny<int>())).Throws(new Exception());
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
            sut.GetById(employeeId);

            employeeRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Exactly(timesRepoCalled));
            loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Never);
        }
        #endregion

        #region Delete
        [Test]
        public void Delete_CallsLoggerWhenExceptionThrown()
        {
            try
            {
                employeeRepository.Setup(x => x.Delete(It.IsAny<int>())).Throws(new Exception());
            }
            catch (Exception)
            {
                loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Once);
            }
        }
        #endregion

        #region GetAll
        [Test]
        public void GetAll_CallsLoggerWhenExceptionThrown()
        {
            try
            {
                employeeRepository.Setup(x => x.GetAll()).Throws(new Exception());
            }
            catch (Exception)
            {
                loggerRepository.Verify(x => x.Log(It.IsAny<Exception>()), Times.Once);
            }
        }
        #endregion
    }
}
