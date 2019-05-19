using BenefitsPac.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Core.DataAccessAbstractions
{
    public interface IDependentsRepository
    {
        Task<int> Create(DependentDataModel dependent);
        Task<IEnumerable<DependentDataModel>> GetByEmployeeId(int employeeId);
        Task<int> Delete(int id);
    }
}
