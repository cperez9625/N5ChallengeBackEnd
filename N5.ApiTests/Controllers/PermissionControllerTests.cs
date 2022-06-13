using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using N5.ApiTests.Config;

namespace N5.Api.Controllers.Tests
{
    [TestClass()]
    public class PermissionControllerTests
    {
        [TestMethod()]
        public void GetPermissionTest()
        {
            var context = N5ChallengeContextInMemory.Get();
            var mediator = new Mock<IMediator>();
            var controller = new PermissionController(context, mediator.Object);
            var testie = controller.GetPermission();
            Assert.IsTrue(testie!=null);
        }
    }
}