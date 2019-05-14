using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Core.DataAccessAbstractions
{
    public interface IDependentsRepository
    {
        Task<int> Create(object dependent);
        Task<object> GetById(int id);
        Task<IEnumerable<object>> GetByEmployeeId(int id);
    }
}
