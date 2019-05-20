using BenefitsPac.Core.Models.DomainModels;
using BenefitsPac.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BenefitsPac.Controllers
{
    [Route("/api/Benefits")]
    public class BenefitsController : ControllerBase
    {
        private readonly IBenefitsService benefitsService;

        public BenefitsController(IBenefitsService benefitsService)
        {
            this.benefitsService = benefitsService;
        }

        [HttpGet("GetBenefitsCostBreakdownByEmployeeId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            BenefitsBreakdownModel benefitsBreakdownModel = await benefitsService.GetBenefitsCostBreakdownByEmployeeId(id);

            return Ok(benefitsBreakdownModel);
        }
    }
}
