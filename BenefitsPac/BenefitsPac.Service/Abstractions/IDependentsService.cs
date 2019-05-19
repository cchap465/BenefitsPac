using BenefitsPac.Core.Models.ApiModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Core.ServiceAbstractions
{
    public interface IDependentsService
    {
        Task<int> Create(DependentModel dependent);
        Task<IEnumerable<DependentModel>> GetByEmployeeId(int employeeId);
        Task<int> Delete(int id);
    }
}
