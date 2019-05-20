using BenefitsPac.Core.Models.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.DataAccess.Abstractions
{
    public interface IDependentsRepository
    {
        Task<int> Create(DependentDataModel dependent);
        Task<IEnumerable<DependentDataModel>> GetByEmployeeId(int employeeId);
        Task<int> Delete(int id);
    }
}
