using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTests.Custom.Controllers
{
    [TestClass]
    public class WorkerControllerCreateActionGetTests
        : EmployeeControllerTestBase {
        [TestMethod]
        public void ShouldRenderDefaultView() {
            var result = _controller.Create();

            Assert.IsTrue(result.ViewName == "");
        }
        }
}