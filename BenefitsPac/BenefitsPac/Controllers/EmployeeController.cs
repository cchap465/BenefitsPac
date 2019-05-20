using BenefitsPac.Core.Models.DomainModels;
using BenefitsPac.Service.Abstractions;
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
            EmployeeModel employee = await _employeeService.GetById(id);

            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<object> employees = await _employeeService.GetAll();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeModel employee)
        {
            var returnedId = await _employeeService.Create(employee);

            return Ok(returnedId);
        }

        [HttpPut("{id}/{name}")]
        public async Task<IActionResult> Update(int id, string name)
        {
            var returnedId = await _employeeService.UpdateEmployeeName(id, name);

            return Ok(returnedId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var returnedId = await _employeeService.Delete(id);

            return Ok(returnedId);
        }
    }
}
