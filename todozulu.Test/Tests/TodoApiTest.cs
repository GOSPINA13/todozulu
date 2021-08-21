using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using todozulu.Common.Models;
using todozulu.Functions.Functions;
using todozulu.Test.Helpers;
using Xunit;

namespace todozulu.Test.Tests
{
    public class TodoApiTest
    {
        private readonly ILogger logger = TestFactory.CreatedLogger();

        [Fact]
        public async void CreateTodo_Should_Return_200()
        {
            //Arrenge
            MockCloudTablesTodos mockTodos = new MockCloudTablesTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            DefaultHttpRequest request = TestFactory.CreatedHttpRequest(todoRequest);

            //Act
            IActionResult response = await TodoApi.CreateTodo(request, mockTodos, logger);

            //Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async void UpdateTodo_Should_Return_200()
        {
            //Arrenge
            MockCloudTablesTodos mockTodos = new MockCloudTablesTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreatedHttpRequest(todoId, todoRequest);

            //Act
            IActionResult response = await TodoApi.UpdateTodo(request, mockTodos, todoId.ToString(), logger);

            //Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
    }
}
