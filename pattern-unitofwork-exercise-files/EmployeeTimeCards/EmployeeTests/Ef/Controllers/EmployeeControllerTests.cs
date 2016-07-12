using System.Collections.Generic;
using System.Linq;
using EmployeeDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTests.Ef.Controllers
{
    [TestClass]
    public class EmployeeControllerIndexActionTests : EmployeeControllerTestBase
    {
        [TestMethod]
        public void SearchFindsPoonam()
        {
            var result = _controller.Index("NAM");
            var model = (IEnumerable<Employee>) result.ViewData.Model;
            Assert.IsTrue(model.Any(e => e.Name == "Poonam"));
        }


        [TestMethod]
        public void ShouldRenderDefaultView()
        {
            var result = _controller.Index();

            Assert.IsTrue(result.ViewName == "");
        }

        [TestMethod]
        public void ShouldBuildModelWithAllEmployees()
        {
            var result = _controller.Index();
            var model = result.ViewData.Model
                          as IEnumerable<Employee>;

            Assert.IsTrue(model.Count() == _employeeData.Count);
        }

        [TestMethod]
        public void ShouldOrderModelByHiredateAscending()
        {
            var result = _controller.Index();
            var model = result.ViewData.Model
                         as IEnumerable<Employee>;

            Assert.IsTrue(model.SequenceEqual(
                           _employeeData.OrderBy(e => e.HireDate)));
        }
    }
}