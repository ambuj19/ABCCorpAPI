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
            if (employeeTaskDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _taskEmpoyeeRepository.AddEmployeeTaskAsync(employeeId, employeeTaskDto);

            return Ok(result);
        }


    }
}
