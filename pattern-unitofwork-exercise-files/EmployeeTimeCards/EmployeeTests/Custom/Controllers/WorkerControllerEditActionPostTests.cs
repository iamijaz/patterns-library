using System;
using System.Web.Mvc;
using EmployeeDomain;
using EmployeeTests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTests.Custom.Controllers
{
    [TestClass]
    public class WorkerControllerEditActionPostTests : EmployeeControllerTestBase
    {
        public WorkerControllerEditActionPostTests()
        {
            _repository.Setup(r => r.FindById(_editId))
                .Returns(_originalEmployee);
            _controller.ControllerContext = new ControllerContext();
            _controller.ValueProvider = _updatedEmployee.ToFormCollection().ToValueProvider();
        }

        [TestMethod]
        public void ShouldRedirectToIndexViewIfSuccessful()
        {
            var result = _controller.Edit(_editId, null) as RedirectToRouteResult;
            Assert.IsTrue(result.RouteValues["action"].ToString() == "Index");
        }

        [TestMethod]
        public void ShouldRenderDefaultViewIfModelstateInvalid()
        {
            _controller.ModelState.AddModelError("Name", "Ooops!");
            var result = _controller.Edit(_editId, null) as ViewResult;
            Assert.IsTrue(result.ViewName == "");
        }

        [TestMethod]
        public void ShouldUseEditemployeeAsModelIfModelstateInvalid()
        {
            _controller.ModelState.AddModelError("Name", "Ooops!");
            var result = _controller.Edit(_editId, null) as ViewResult;
            var model = result.ViewData.Model as Employee;

            Assert.IsTrue(object.ReferenceEquals(model, _originalEmployee));
        }

        [TestMethod]
        public void ShouldModifyEmployeeWithPostedValues()
        {
            var result = _controller.Edit(_editId, null) as ViewResult;

            Assert.IsTrue(_originalEmployee.Name == _updatedEmployee.Name);
            Assert.IsTrue(_originalEmployee.HireDate == _updatedEmployee.HireDate);
        }

        [TestMethod]
        public void ShouldCommitUnitOfWork()
        {
            _controller.Edit(_editId, null);

            _unitOfWork.Verify(u => u.Commit());
        }

        int _editId = 2;

        private Employee _originalEmployee = new Employee()
        {
            Name = "Old value",
            HireDate = new DateTime(1959, 1, 1)
        };
        Employee _updatedEmployee = new Employee()
        {
            Name = "UPDATED EMPLOYEE",
            HireDate = new DateTime(1969, 1, 1)
        };
    }
}