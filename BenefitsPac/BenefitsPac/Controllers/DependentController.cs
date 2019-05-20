using BenefitsPac.Core.Models.DomainModels;
using BenefitsPac.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Controllers
{
    [Route("/api/Dependent")]
    public class DependentController : ControllerBase
    {
        private readonly IDependentsService dependentsService;

        public DependentController(IDependentsService dependentsService)
        {
            this.dependentsService = dependentsService;
        }

        [HttpGet("GetDependentsByEmployeeId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            IEnumerable<DependentModel> dependent = await dependentsService.GetByEmployeeId(id);

            return Ok(dependent);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DependentModel dependentModel)
        {
            var newId = await dependentsService.Create(dependentModel);

            return Ok(newId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int returnedId = await dependentsService.Delete(id);

            return Ok(returnedId);
        }
    }
}
