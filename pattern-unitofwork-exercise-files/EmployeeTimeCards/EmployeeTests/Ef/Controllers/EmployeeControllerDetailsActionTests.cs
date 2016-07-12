using EmployeeDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTests.Ef.Controllers
{
    [TestClass]
    public class EmployeeControllerDetailsActionTests : EmployeeControllerTestBase
    {
        [TestMethod]
        public void ShouldRenderDefaultView()
        {
            var result = _controller.Details(1);

            Assert.IsTrue(result.ViewName == "");
        }

        [TestMethod]
        public void ShouldBuildModelWithCorrectEmployee()
        {
            var id = 1;
            var result = _controller.Details(id);
            var model = result.ViewData.Model as Employee;

            Assert.IsTrue(model.Id == id);
        }
    }
}