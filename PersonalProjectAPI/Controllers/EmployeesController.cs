using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalProjectClassLibrary.DataServices;
using PersonalProjectClassLibrary.Dto;
using System;
using System.Threading.Tasks;

namespace PersonalProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeData _data;

        public EmployeesController(IEmployeeData data)
        {
            _data = data;
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee(InsertEmployeeDto employeeDto)
        {
            await _data.InsertEmployee(employeeDto);
            return CreatedAtAction(nameof(InsertEmployee), employeeDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await _data.GetEmployees();
            return Ok(result);
        }

        [HttpGet("with-info")]
        public async Task<IActionResult> GetEmployeesWithInfo()
        {
            var result = await _data.GetEmployeesWithInfo();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            var result = await _data.GetEmployee(id);

            if (result is null)
            {
                return NotFound($"An employee with the Id: {id} can't be found");
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, UpdateEmployeeDto empoloyeeDto)
        {
            var result = await _data.GetEmployee(id);
            if (result is null)
            {
                return NotFound($"An employee with the Id: {id} can't be found");
            }

            await _data.UpdateEmployee(id, empoloyeeDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpoloyee(Guid id)
        {

            var result = await _data.GetEmployee(id);
            if (result is null)
            {
                return NotFound($"An employee with the Id: {id} can't be found");
            }

            await _data.DeleteEmployee(id);
            return Ok();

        }

    }
}
