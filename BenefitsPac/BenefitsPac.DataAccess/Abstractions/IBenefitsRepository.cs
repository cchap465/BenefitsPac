using BenefitsPac.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.DataAccess.Abstractions
{
    public interface IBenefitsRepository
    {
        Task<IEnumerable<BenefitCostDataModel>> GetBenefitsCostsByEmployeeId(int employeeId);
    }
}
