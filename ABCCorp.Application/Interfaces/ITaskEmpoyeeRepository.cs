using ABCCorp.Application.DTO;
using ABCCorp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.Application.Interfaces
{
    public interface ITaskEmpoyeeRepository
    {
        Task<List<EmployeeTasks>> AddEmployeeTaskAsync(int employeeId, EmployeeTaskDto employeeTaskDto);
    }
}
