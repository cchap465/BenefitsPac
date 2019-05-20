using BenefitsPac.Core.Models.DataModels;
using BenefitsPac.Core.Models.DomainModels;
using System.Collections.Generic;

namespace BenefitsPac.Business.Abstractions
{
    public interface IBenefitsBreakdown
    {
        BenefitsBreakdownModel GetBenefitsBreaksown(EmployeeSalaryDataModel employeeSalaryDataModel, IEnumerable<BenefitCostDataModel> benefitDeductionModels);
    }
}
