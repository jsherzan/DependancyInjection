using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Validation.Controllers;
using Validation.Models;
using Validation.Repository;
using Xunit;

namespace ValidationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var mockRepo = new Mock<IRegistrationRepository>();
            mockRepo.Setup(repo => repo.SaveRegistration(It.IsAny<RegistraionModel>()))
                .Verifiable();
            var mockLogger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mockLogger.Object, mockRepo.Object);
            var model = new RegistraionModel();

            var result = controller.Registration(model);
            mockRepo.Verify();
        }
    }
}
