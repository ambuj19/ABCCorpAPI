using ABCCorp.Application.DTO;
using ABCCorp.Application.Interfaces;
using ABCCorp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.Infrastructure
{
    public class TaskEmployeeRepository : ITaskEmpoyeeRepository
    {
        private readonly ABCCorpDbContext _dbContext;

        public TaskEmployeeRepository(ABCCorpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EmployeeTasks>> AddEmployeeTaskAsync(int employeeId, EmployeeTaskDto employeeTaskDto)
        {
            var newEmployeeTask = new EmployeeTasks
            {
                EmployeeId = employeeId,
                Name = employeeTaskDto.Name,
                Description = employeeTaskDto.Description,
                TaskId = employeeTaskDto.TaskId
            };
            await _dbContext.EmployeeTasks.AddAsync(newEmployeeTask);

            await _dbContext.SaveChangesAsync();
            var employeeTasks = await _dbContext.EmployeeTasks
                                                 .Where(et => et.EmployeeId == employeeId)
                                                 .ToListAsync();

            return employeeTasks;
        }

    }

}
