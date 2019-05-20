using BenefitsPac.Core.Models.DataModels;
using BenefitsPac.Core.Models.DomainModels;
using BenefitsPac.DataAccess.Abstractions;
using BenefitsPac.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPac.Service.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ILoggerRepository loggerRepository;

        public EmployeeService(IEmployeeRepository employeeRepository,
            ILoggerRepository loggerRepository)
        {
            this.employeeRepository = employeeRepository;
            this.loggerRepository = loggerRepository;
        }

        public async Task<int> Create(EmployeeModel employee)
        {
            try
            {
                decimal discount = employee.EmployeeName.StartsWith("a", StringComparison.OrdinalIgnoreCase) ? .10m : 0;
                return await employeeRepository.Create(new EmployeeDataModel(employee, discount));
            }
            catch (Exception ex)
            {
                await loggerRepository.Log(ex).ConfigureAwait(false);
                throw;
            }
        }

        public async Task<int> UpdateEmployeeName(int employeeId, string employeeName)
        {
            try
            {
                return await employeeRepository.Update(employeeId, employeeName);
            }
            catch (Exception ex)
            {
                await loggerRepository.Log(ex).ConfigureAwait(false);
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                return await employeeRepository.Delete(id);
            }
            catch (Exception ex)
            {
                await loggerRepository.Log(ex).ConfigureAwait(false);
                throw;
            }
        }

        public async Task<EmployeeModel> GetById(int id)
        {
            try
            {
                EmployeeDataModel employeeDataModel = await employeeRepository.GetById(id);
                return new EmployeeModel(employeeDataModel);
            }
            catch (Exception ex)
            {
                await loggerRepository.Log(ex).ConfigureAwait(false);
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            try
            {
                IEnumerable<EmployeeDataModel> employeeDataModels = await employeeRepository.GetAll();
                return employeeDataModels.Select(x => new EmployeeModel(x)).OrderByDescending(x => x.EmployeeId);
            }
            catch (Exception ex)
            {
                await loggerRepository.Log(ex).ConfigureAwait(false);
                throw;
            }
        }
    }
}
