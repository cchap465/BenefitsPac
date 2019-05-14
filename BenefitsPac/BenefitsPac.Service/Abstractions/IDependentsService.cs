using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Core.ServiceAbstractions
{
    public interface IDependentsService
    {
        Task<int> Create(object dependent);
        Task<object> GetById(int id);
        Task<IEnumerable<object>> GetByEmployeeId(int id);
    }
}
