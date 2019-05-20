using BenefitsPac.Core.Models.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Service.Abstractions
{
    public interface IDependentsService
    {
        Task<int> Create(DependentModel dependent);
        Task<IEnumerable<DependentModel>> GetByEmployeeId(int employeeId);
        Task<int> Delete(int id);
    }
}
