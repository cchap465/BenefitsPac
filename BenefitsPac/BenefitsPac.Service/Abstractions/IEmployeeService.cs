using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Core.ServiceAbstractions
{
    public interface IEmployeeService
    {
        Task<int> Create(object employee);
        Task<object> GetById(int id);
        Task<IEnumerable<object>> GetAll();
    }
}
