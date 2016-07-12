using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTests.Ef.Controllers
{
    [TestClass]
    public class EmployeeControllerCreateActionGetTests : EmployeeControllerTestBase
    {
        [TestMethod]
        public void ShouldRenderDefaultView()
        {
            var result = _controller.Create();

            Assert.IsTrue(result.ViewName == "");
        }
    }
}