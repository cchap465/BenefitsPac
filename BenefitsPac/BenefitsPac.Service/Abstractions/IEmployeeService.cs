using BenefitsPac.Core.Models.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Service.Abstractions
{
    public interface IEmployeeService
    {
        Task<int> Create(EmployeeModel employee);
        Task<int> UpdateEmployeeName(int employeeId, string employeeName);
        Task<EmployeeModel> GetById(int id);
        Task<IEnumerable<EmployeeModel>> GetAll();
        Task<int> Delete(int id);
    }
}
