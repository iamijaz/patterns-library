using System.Web.Mvc;
using EmployeeDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTests.Custom.Controllers
{
    [TestClass]
    public class WorkerControllerCreateActionPostTests : EmployeeControllerTestBase
    {
        [TestMethod]
        public void ShouldRedirectToIndexViewIfSuccessful()
        {
            var result = _controller.Create(_newEmployee) as RedirectToRouteResult;

            Assert.IsTrue(result.RouteValues["action"].ToString() == "Index");
        }

        [TestMethod]
        public void ShouldRenderDefaultViewIfModelstateInvalid()
        {
            _controller.ModelState.AddModelError("Name", "Ooops!");
            var result = _controller.Create(_newEmployee) as ViewResult;
            Assert.IsTrue(result.ViewName == "");
        }

        [TestMethod]
        public void ShouldUseNewEmployeeAsModelIfModelstateInvalid()
        {
            _controller.ModelState.AddModelError("Name", "Ooops!");
            var result = _controller.Create(_newEmployee) as ViewResult;
            var model = result.ViewData.Model as Employee;

            Assert.IsTrue(object.ReferenceEquals(model, _newEmployee));
        }

        [TestMethod]
        public void ShouldAddNewEmployeeToRepository()
        {
            _controller.Create(_newEmployee);

            _repository.Verify(r => r.Add(_newEmployee));
        }

        [TestMethod]
        public void ShouldCommitUnitOfWork()
        {

            _controller.Create(_newEmployee);

            _unitOfWork.Verify(u => u.Commit());
        }

        Employee _newEmployee = new Employee()
        {
            Name = "NEW EMPLOYEE",
            HireDate = new System.DateTime(2010, 1, 1)
        };
    }
}