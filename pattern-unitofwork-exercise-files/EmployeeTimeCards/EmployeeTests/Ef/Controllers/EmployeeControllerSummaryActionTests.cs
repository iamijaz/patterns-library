using EmployeeWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTests.Ef.Controllers
{
    [TestClass]
    public class EmployeeControllerSummaryActionTests
        : EmployeeControllerTestBase
    {
        [TestMethod]
        public void ShouldBuildModelWithCorrectEmployeesummary()
        {
            var id = 1;
            var result = _controller.Summary(id);
            var model = result.ViewData.Model as EmployeeSummaryViewModel;

            Assert.IsTrue(model.TotalTimeCards == 3);
        }

        // ...
        [TestMethod]
        public void ShouldRenderDefaultView()
        {
            var result = _controller.Summary(1);

            Assert.IsTrue(result.ViewName == "");
        }
    }
}