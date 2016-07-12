using System;
using System.Linq;
using System.Web.Mvc;
using EmployeeDomain;
using EmployeeTests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTests.Ef.Controllers
{
    [TestClass]
    public class EmployeeControllerEditActionPostTests : EmployeeControllerTestBase
    {
        public EmployeeControllerEditActionPostTests()
        {
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

            Assert.IsTrue(object.ReferenceEquals(model,
                _repository.Single(e => e.Id == _editId)));
        }

        [TestMethod]
        public void ShouldModifyEmployeeWithPostedValues()
        {

            var result = _controller.Edit(_editId, null) as ViewResult;
            var employee = _repository.Single(e => e.Id == _editId);

            Assert.IsTrue(employee.Name == _updatedEmployee.Name);
        }

        [TestMethod]
        public void ShouldCommitUnitOfWork()
        {

            _controller.Edit(_editId, null);

            Assert.IsTrue(_unitOfWork.Committed);
        }

        int _editId = 2;
        Employee _updatedEmployee = new Employee()
        {
            Name = "UPDATED EMPLOYEE",
            HireDate = new DateTime(1969, 1, 1)

        };
    }
}