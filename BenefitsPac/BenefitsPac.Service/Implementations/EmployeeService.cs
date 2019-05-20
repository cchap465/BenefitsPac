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
                if (employee != null)
                {
                    decimal discount = employee.EmployeeName?.StartsWith("a", StringComparison.OrdinalIgnoreCase) == true ? .10m : 0;
                    return await employeeRepository.Create(new EmployeeDataModel(employee, discount));
                }

                return 0;
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
                if (employeeId > 0 && !string.IsNullOrEmpty(employeeName))
                {
                    return await employeeRepository.Update(employeeId, employeeName);
                }

                return 0;
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
                if (id > 0)
                {
                    EmployeeDataModel employeeDataModel = await employeeRepository.GetById(id);
                    return new EmployeeModel(employeeDataModel);
                }

                return null;
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
