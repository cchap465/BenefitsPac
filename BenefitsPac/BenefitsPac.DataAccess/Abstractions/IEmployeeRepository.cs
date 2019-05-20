using BenefitsPac.Core.Models.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.DataAccess.Abstractions
{
    public interface IEmployeeRepository
    {
        Task<int> Create(EmployeeDataModel employee);
        Task<int> Update(int employeeId, string employeeName);
        Task<EmployeeDataModel> GetById(int id);
        Task<IEnumerable<EmployeeDataModel>> GetAll();
        Task<int> Delete(int id);
        Task<EmployeeSalaryDataModel> GetEmployeeSalaryData(int id);
    }
}
