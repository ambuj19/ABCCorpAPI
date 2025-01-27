using ABCCorp.Application.Interfaces;
using ABCCorp.Application.Services;
using ABCCorp.Infrastructure;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABCCorp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class TaskController: ControllerBase
    {
        //private readonly ITaskRepository _taskService;


        //public TaskController(ITaskRepository taskService)
        //{
        //    _taskService = taskService;
        //}
        private readonly ABCCorpDbContext _context;

        public TaskController(ABCCorpDbContext taskService)
        {
            _context = taskService;
        }

        [HttpGet("/api/tasks")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Task.ToListAsync());
        }

        [HttpPost("/api/tasks")]
        public async Task<IActionResult> Create([FromBody] Application.DTO.Task task)
        {
            if (task == null)
            {
                return BadRequest("Task is null");
            }

            // Map DTO.Task to Entity.Task
            var taskEntity = new Domain.Models.Task
            {
                Name = task.Name,
                Description = task.Description
            };

            // Add the task to the context
            _context.Task.Add(taskEntity);
            await _context.SaveChangesAsync();

            // Return a response with the created task
            return CreatedAtAction(nameof(Get), new { id = taskEntity.TaskId }, taskEntity);
        }

    }
}
