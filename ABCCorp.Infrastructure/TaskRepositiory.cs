using ABCCorp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.Infrastructure
{
    public class TaskRepositiory : ITaskRepository
    {
        private readonly ABCCorpDbContext _dbContext;

        public TaskRepositiory(ABCCorpDbContext dbConext)
        {
            _dbContext = dbConext;
        }
        public async Task<List<Application.DTO.Task>> GetTasks()
        {
            var tasks = new List<Application.DTO.Task>();
            try
            {
                tasks = await _dbContext.Task
                .AsNoTracking()
                .Select(task => new Application.DTO.Task
                {
                    Name = task.Name,
                    Description = task.Description
                }).ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return tasks;
        }
        public async Task<List<Application.DTO.Task>> CreateTasks(List<Application.DTO.Task> tasks)
        {
            var taskEntities = tasks.Select(t => new Domain.Models.Task
            {
                
                Name = t.Name,
                Description = t.Description
            }).ToList();

            _dbContext.Task.AddRange(taskEntities);
            await _dbContext.SaveChangesAsync();

            return tasks;
        }
    }
}
