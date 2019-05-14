using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Core.DataAccessAbstractions
{
    public interface IEmployeeRepository
    {
        Task<int> Create(object employee);
        Task<object> GetById(int id);
        Task<IEnumerable<object>> GetAll();
    }
}
