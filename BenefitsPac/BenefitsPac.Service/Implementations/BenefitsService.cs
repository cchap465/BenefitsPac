using BenefitsPac.Business.Abstractions;
using BenefitsPac.Core.DataAccessAbstractions;
using BenefitsPac.Core.Models;
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

        public BenefitsService(IBenefitsBreakdown benefitsBreakdown,
            IEmployeeRepository employeeRepository,
            IBenefitsRepository benefitsRepository)
        {
            this.benefitsBreakdown = benefitsBreakdown;
            this.employeeRepository = employeeRepository;
            this.benefitsRepository = benefitsRepository;
        }

        public IBenefitsBreakdown BenefitsBreakdown { get; }

        public async Task<BenefitsBreakdownModel> GetBenefitsCostBreakdownByEmployeeId(int employeeId)
        {
            try
            {
                IEnumerable<BenefitCostDataModel> benefitCostDataModels = await benefitsRepository.GetBenefitsCostsByEmployeeId(employeeId);
                EmployeeSalaryDataModel employeeSalaryDataModel = await employeeRepository.GetEmployeeSalaryData(employeeId);

                return benefitsBreakdown.GetBenefitsBreaksown(employeeSalaryDataModel, benefitCostDataModels);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
