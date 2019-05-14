using BenefitsPac.Core.DataAccessAbstractions;
using BenefitsPac.Core.ServiceAbstractions;
using System.Collections.Generic;
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

        public async Task<int> Create(object dependent)
        {
            return await _dependentsRepository.Create(dependent);
        }

        public async Task<object> GetById(int id)
        {
            return await _dependentsRepository.GetById(id);
        }

        public async Task<IEnumerable<object>> GetByEmployeeId(int id)
        {
            return await _dependentsRepository.GetByEmployeeId(id);
        }
    }
}
