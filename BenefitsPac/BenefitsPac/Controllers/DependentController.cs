using BenefitsPac.Core.Models.ApiModel;
using BenefitsPac.Core.ServiceAbstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Controllers
{
    [Route("/api/Dependent")]
    public class DependentController : ControllerBase
    {
        private readonly IDependentsService _dependentsService;

        public DependentController(IDependentsService dependentsService)
        {
            _dependentsService = dependentsService;
        }

        [HttpGet("GetDependentsByEmployeeId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            IEnumerable<DependentModel> dependent = await _dependentsService.GetByEmployeeId(id);

            return Ok(dependent);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DependentModel dependentModel)
        {
            var newId = await _dependentsService.Create(dependentModel);

            return Ok(newId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int returnedId = await _dependentsService.Delete(id);

            return Ok(returnedId);
        }
    }
}
