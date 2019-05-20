using BenefitsPac.Core.DataAccessAbstractions;
using BenefitsPac.Core.Models;
using BenefitsPac.Core.Models.ApiModel;
using BenefitsPac.Core.ServiceAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPac.Service
{
    public class DependentsService : IDependentsService
    {
        private readonly IDependentsRepository _dependentsRepository;

        public DependentsService(IDependentsRepository dependentsRepository)
        {
            _dependentsRepository = dependentsRepository;
        }

        public async Task<int> Create(DependentModel dependent)
        {
            try
            {
                decimal discount = dependent.DependentName.StartsWith("a", StringComparison.OrdinalIgnoreCase) ? .10m : 0;
                return await _dependentsRepository.Create(new DependentDataModel(dependent, discount));
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<DependentModel>> GetByEmployeeId(int id)
        {
            try
            {
                IEnumerable<DependentDataModel> dependentDataModels = await _dependentsRepository.GetByEmployeeId(id);
                return dependentDataModels.Select(x => new DependentModel(x)).OrderByDescending(x => x.DependentId);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                return await _dependentsRepository.Delete(id);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
