using BenefitsPac.Core.DataAccessAbstractions;
using BenefitsPac.Core.Models;
using BenefitsPac.Core.Models.ApiModel;
using BenefitsPac.Core.ServiceAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPac.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
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
                throw;
            }
        }

        public async Task<int> UpdateEmployeeName(int employeeId, string employeeName)
        {
            try
            {
                return await employeeRepository.Update(employeeId, employeeName);
            }
            catch (Exception)
            {

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

                throw;
            }
        }
    }
}
