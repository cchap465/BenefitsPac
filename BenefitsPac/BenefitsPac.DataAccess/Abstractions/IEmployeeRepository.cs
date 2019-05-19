using BenefitsPac.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Core.DataAccessAbstractions
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
