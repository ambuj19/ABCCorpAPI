using ABCCorp.API.Controllers;
using ABCCorp.Application.Interfaces;
using ABCCorp.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.API.Test
{
    public class TaskEmployeeControllerTest
    {
        [Fact]
        public async Task AddEmployeeTask_ShouldReturnBadRequest_WhenDtoIsNull()
        {
            // Arrange
            var mockRepo = new Mock<ITaskEmpoyeeRepository>();
            var controller = new TaskEmployeeController(mockRepo.Object);

            // Act
            var result = await controller.AddEmployeeTask(1, null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
