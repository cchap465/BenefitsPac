using BenefitsPac.Core.Models;
using BenefitsPac.Core.Models.DomainModels;
using System.Collections.Generic;

namespace BenefitsPac.Business.Abstractions
{
    public interface IBenefitsBreakdown
    {
        BenefitsBreakdownModel GetBenefitsBreaksown(EmployeeSalaryDataModel employeeModel, IEnumerable<BenefitCostDataModel> benefitDeductionModel);
    }
}
