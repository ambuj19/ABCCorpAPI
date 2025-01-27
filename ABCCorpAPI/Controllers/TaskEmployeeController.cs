using ABCCorp.Application.DTO;
using ABCCorp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ABCCorp.API.Controllers
{
    public class TaskEmployeeController: ControllerBase
    {
        private readonly ITaskEmpoyeeRepository _taskEmpoyeeRepository;

        public TaskEmployeeController(ITaskEmpoyeeRepository taskEmpoyeeRepository)
        {
            _taskEmpoyeeRepository = taskEmpoyeeRepository;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> AddEmployeeTask(int employeeId, [FromBody] EmployeeTaskDto employeeTaskDto)
        {
            // Check if the input data is valid
            if (employeeTaskDto == null)
            {
                return BadRequest("Invalid data.");
            }

            // Call the service method to add the employee task and fetch updated tasks
            var result = await _taskEmpoyeeRepository.AddEmployeeTaskAsync(employeeId, employeeTaskDto);

            // Return the updated list of employee tasks for the employee
            return Ok(result);
        }


    }
}
