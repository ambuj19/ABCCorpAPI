using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.Application.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<DTO.Task>> GetTasks();
        Task<List<DTO.Task>> CreateTasks(List<DTO.Task> tasks);
    }
}
