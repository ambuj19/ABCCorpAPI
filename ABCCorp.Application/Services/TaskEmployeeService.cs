using ABCCorp.Application.DTO;
using ABCCorp.Application.Interfaces;
using ABCCorp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.Application.Services
{
    public class TaskEmployeeService : ITaskEmpoyeeRepository
    {
        private readonly ITaskEmpoyeeRepository _taskEmpoyeeRepository;
        public TaskEmployeeService(ITaskEmpoyeeRepository taskRepository) {
            _taskEmpoyeeRepository = taskRepository;
        }

        public async Task<List<EmployeeTasks>> AddEmployeeTaskAsync(int employeeId, EmployeeTaskDto employeeTaskDto)
        {
            return await _taskEmpoyeeRepository.AddEmployeeTaskAsync(employeeId, employeeTaskDto);
        }
    }
}
