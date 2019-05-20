using BenefitsPac.Core.Models.DomainModels;
using System.Threading.Tasks;

namespace BenefitsPac.Service.Abstractions
{
    public interface IBenefitsService
    {
        Task<BenefitsBreakdownModel> GetBenefitsCostBreakdownByEmployeeId(int employeeId);
    }
}
