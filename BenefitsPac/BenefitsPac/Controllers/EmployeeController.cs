using BenefitsPac.Core.ServiceAbstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPac.Controllers
{
    [Route("/api/Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.GetById(id);

            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<object> employees = await _employeeService.GetAll();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] object employee)
        {
            var id = await _employeeService.Create(employee);

            return Ok(id);
        }
    }
}
