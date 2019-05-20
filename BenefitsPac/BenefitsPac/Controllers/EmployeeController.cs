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
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            EmployeeModel employee = await employeeService.GetById(id);

            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<object> employees = await employeeService.GetAll();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeModel employee)
        {
            var returnedId = await employeeService.Create(employee);

            return Ok(returnedId);
        }

        [HttpPut("{id}/{name}")]
        public async Task<IActionResult> Update(int id, string name)
        {
            var returnedId = await employeeService.UpdateEmployeeName(id, name);

            return Ok(returnedId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var returnedId = await employeeService.Delete(id);

            return Ok(returnedId);
        }
    }
}
