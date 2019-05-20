using BenefitsPac.Core.Models.DataModels;
using BenefitsPac.Core.Models.DomainModels;
using BenefitsPac.DataAccess.Abstractions;
using BenefitsPac.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPac.Service.Implementations
{
    public class DependentsService : IDependentsService
    {
        private readonly IDependentsRepository dependentsRepository;
        private readonly ILoggerRepository loggerRepository;

        public DependentsService(IDependentsRepository dependentsRepository,
            ILoggerRepository loggerRepository)
        {
            this.dependentsRepository = dependentsRepository;
            this.loggerRepository = loggerRepository;
        }

        public async Task<int> Create(DependentModel dependent)
        {
            try
            {
                decimal discount = dependent.DependentName.StartsWith("a", StringComparison.OrdinalIgnoreCase) ? .10m : 0;
                return await dependentsRepository.Create(new DependentDataModel(dependent, discount));
            }
            catch (Exception ex)
            {
                await loggerRepository.Log(ex).ConfigureAwait(false);
                throw;
            }
        }

        public async Task<IEnumerable<DependentModel>> GetByEmployeeId(int id)
        {
            try
            {
                IEnumerable<DependentDataModel> dependentDataModels = await dependentsRepository.GetByEmployeeId(id);
                return dependentDataModels.Select(x => new DependentModel(x)).OrderByDescending(x => x.DependentId);
            }
            catch (Exception ex)
            {
                await loggerRepository.Log(ex).ConfigureAwait(false);
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                return await dependentsRepository.Delete(id);
            }
            catch (Exception ex)
            {
                await loggerRepository.Log(ex).ConfigureAwait(false);
                throw;
            }
        }
    }
}
