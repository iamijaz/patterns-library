using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTests.Ef.Controllers
{
    [TestClass]
    public class EmployeeControllerEditActionGetTests : EmployeeControllerTestBase
    {
        [TestMethod]
        public void ShouldRenderDefaultView()
        {
            var id = 1;
            var result = _controller.Edit(id);

            Assert.IsTrue(result.ViewName == "");
        }
    }
}