using BenefitsPac.Core.ServiceAbstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Controllers
{
    public class DependentController : ControllerBase
    {
        private readonly IDependentsService _dependentsService;

        public DependentController(IDependentsService dependentsService)
        {
            _dependentsService = dependentsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dependent = await _dependentsService.GetById(id);

            return Ok(dependent);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] object dependent)
        {
            var id = await _dependentsService.Create(dependent);

            return Ok(id);
        }
    }
}
