using System;
using todozulu.Functions.Functions;
using todozulu.Test.Helpers;
using Xunit;

namespace todozulu.Test.Tests
{
    public class ScheduleFunctionTest
    {
        [Fact]
        public void ScheduleFunction_Should_Log_Message()
        {
            //Arrange
            MockCloudTablesTodos mockTodos = new MockCloudTablesTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            ListLogger logger = (ListLogger)TestFactory.CreatedLogger(LoggerTypes.List);

            //Act
            ScheduleFunction.Run(null, mockTodos, logger);
            string message = logger.Logs[0];

            //Asert
            Assert.Contains("Deleting completed", message);
        }
    }
}
