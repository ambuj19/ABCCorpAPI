using Microsoft.AspNetCore.Mvc;
using ABCCorp.API.Controllers;
using ABCCorp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ABCCorp.API.Test
{
    public class TaskControllerTest
    {
        private ABCCorpDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ABCCorpDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            var dbContext = new ABCCorpDbContext(options);

            dbContext.Task.AddRange(new List<ABCCorp.Domain.Models.Task>
            {
               new ABCCorp.Domain.Models.Task { TaskId = 1, Name = "Task 1", Description="abc1" },
               new ABCCorp.Domain.Models.Task { TaskId = 2, Name = "Task 2",  Description="abc2" }
            });
            dbContext.SaveChanges();

            return dbContext;
        }
        [Fact]
        public async Task Get_ShouldReturnAllTasks()
        {
            // Arrange
            var dbContext = GetDbContext();
            var controller = new TaskController(dbContext);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var tasks = Assert.IsAssignableFrom<IEnumerable<ABCCorp.Domain.Models.Task>>(okResult.Value);
            Assert.Equal(2, tasks.Count()); 

        }
    }
}