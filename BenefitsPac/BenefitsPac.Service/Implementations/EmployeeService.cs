using BenefitsPac.Core.DataAccessAbstractions;
using BenefitsPac.Core.ServiceAbstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<object>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<int> Create(object employee)
        {
            return await _employeeRepository.Create(employee);
        }

        public async Task<object> GetById(int id)
        {
            return await _employeeRepository.GetById(id);
        }
    }
}
