using FrontendPracticeAPI.Models;
using FrontendPracticeAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontendPracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmpRepository _empRepository;

        public EmployeesController(IEmpRepository empRepository)
        {
            _empRepository = empRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>>GetEmployees()
        {
            return await _empRepository.Get();
        }

        [HttpGet("{EmployeeId}")]
        public async Task<ActionResult<Employee>>GetEmployees(int EmployeeId)
        {
            return await _empRepository.Get(EmployeeId);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployees([FromBody] Employee employee)
        {
            var newEmployee = await _empRepository.Create(employee);

            return CreatedAtAction(nameof(GetEmployees), new {EmployeeId = newEmployee.EmployeeId}, newEmployee);
        }

        [HttpPut]
        public async Task<ActionResult> PutEmployees(int EmployeeId, [FromBody] Employee employee)
        {
            if (EmployeeId != employee.EmployeeId)
                return BadRequest();

            await _empRepository.Update(employee);
            return NoContent();
        }

        [HttpDelete("{EmployeeId}")]
        public async Task<ActionResult> Delete(int EmployeeId)
        {
            var employeeToDelete = await _empRepository.Get(EmployeeId);

            if (employeeToDelete == null)
                return NotFound();

            await _empRepository.Delete(employeeToDelete.EmployeeId);

            return NoContent();
        }
    }
}
