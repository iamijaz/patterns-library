using System.Collections.Generic;
using System.Linq;
using EmployeeDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTests.Custom.Controllers
{
    [TestClass]
    public class EmployeeControllerIndexActionTests
        : EmployeeControllerTestBase {
        public EmployeeControllerIndexActionTests() {
            
            _repository.Setup(r => r.FindAll())
                .Returns(_employeeData);
        }

        [TestMethod]
        public void ShouldBuildModelWithAllEmployees()
        {
            // testing state
            var result = _controller.Index();
            var model = result.ViewData.Model
                as IEnumerable<Employee>;

            Assert.IsTrue(model.Count() == _employeeData.Count());
        }

        [TestMethod]
        public void ShouldInvokeFindallOnRepository()
        {
            // testing interaction
            var result = _controller.Index();

            _repository.Verify(r => r.FindAll());
        }


        [TestMethod]
        public void ShouldRenderDefaultView() {
            var result = _controller.Index();

            Assert.IsTrue(result.ViewName == "");
        }
        }
}