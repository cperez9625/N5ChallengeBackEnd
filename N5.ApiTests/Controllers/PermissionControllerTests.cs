using N5.Api.Controllers;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using N5.ApiTests.Config;
using N5.Shared;
using System;
using N5.Api.Models;

namespace N5.Api.Controllers.Tests
{
    [TestClass()]
    public class PermissionControllerTests
    {
        [TestMethod()]
        public void GetPermissionTest()
        {
            var controller = CreateControllerInstance();
            var response = controller.GetPermission();
            Assert.IsTrue(response.Result != null);
        }

        [TestMethod()]
        public void GetPermissionByIdTest()
        {
            var controller = CreateControllerInstance();
            var response = controller.GetPermissionById(1);
            Assert.IsTrue(response.Result != null);
        }

        [TestMethod()]
        public void RequestPermissionTest()
        {
            var controller = CreateControllerInstance();
            PermissionRequest permission = new()
            {
                EmployeeFirstName = "N5",
                EmployeeLastName = "Company",
                PermissionType = 1,
            };

            var response = controller.RequestPermission(permission);
            Assert.IsTrue(response.Result != null);
        }

        [TestMethod()]
        public void UpdatePermissionTest()
        {
            var controller = CreateControllerInstance();
            PermissionRequest permission = new()
            {
                EmployeeFirstName = "N5 Now",
                EmployeeLastName = "Best Company",
                PermissionType = 2,
            };

            var response = controller.UpdatePermission(permission);
            Assert.IsTrue(response.Result != null);
        }

        private PermissionController CreateControllerInstance()
        {
            var context = N5ChallengeContextInMemory.Get();
            var mediator = new Mock<IMediator>();
            return new PermissionController(context, mediator.Object);
        }
    }
}