using ABCCorp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.Application.Services
{
    public class TaskService : ITaskRepository
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<DTO.Task>> GetTasks()
        {
            return await _taskRepository.GetTasks();
        }

        public async Task<List<DTO.Task>> CreateTasks(List<DTO.Task> tasks)
        {
            return await _taskRepository.CreateTasks(tasks);
        }
    }
}
