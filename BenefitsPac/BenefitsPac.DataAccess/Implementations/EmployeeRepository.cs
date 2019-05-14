using BenefitsPac.Core.DataAccessAbstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<int> Create(object employee)
        {
            return await Task.Run(() => 0);
        }

        public async Task<object> GetById(int id)
        {
            return await Task.Run(() => new object());
        }

        public async Task<IEnumerable<object>> GetAll()
        {
            return await Task.Run(() => new List<object>());
        }
    }
}
