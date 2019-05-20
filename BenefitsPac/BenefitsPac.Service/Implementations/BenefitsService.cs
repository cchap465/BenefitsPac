using BenefitsPac.Business.Abstractions;
using BenefitsPac.Core.Models.DataModels;
using BenefitsPac.Core.Models.DomainModels;
using BenefitsPac.DataAccess.Abstractions;
using BenefitsPac.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Service.Implementations
{
    public class BenefitsService : IBenefitsService
    {
        private readonly IBenefitsBreakdown benefitsBreakdown;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IBenefitsRepository benefitsRepository;
        private readonly ILoggerRepository loggerRepository;

        public BenefitsService(IBenefitsBreakdown benefitsBreakdown,
            IEmployeeRepository employeeRepository,
            IBenefitsRepository benefitsRepository,
            ILoggerRepository loggerRepository)
        {
            this.benefitsBreakdown = benefitsBreakdown;
            this.employeeRepository = employeeRepository;
            this.benefitsRepository = benefitsRepository;
            this.loggerRepository = loggerRepository;
        }

        public IBenefitsBreakdown BenefitsBreakdown { get; }

        public async Task<BenefitsBreakdownModel> GetBenefitsCostBreakdownByEmployeeId(int employeeId)
        {
            try
            {
                if (employeeId > 0)
                {
                    IEnumerable<BenefitCostDataModel> benefitCostDataModels = await benefitsRepository.GetBenefitsCostsByEmployeeId(employeeId);
                    EmployeeSalaryDataModel employeeSalaryDataModel = await employeeRepository.GetEmployeeSalaryData(employeeId);

                    return benefitsBreakdown.GetBenefitsBreaksown(employeeSalaryDataModel, benefitCostDataModels);
                }

                return null;
            }
            catch (Exception ex)
            {
                await loggerRepository.Log(ex).ConfigureAwait(false);
                throw;
            }
        }
    }
}
