using System;
using System.Linq;
using System.Linq.Expressions;
using EmployeeDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EmployeeTests.Custom.Controllers
{
    [TestClass]
    public class WorkerControllerEditActionGetTests : EmployeeControllerTestBase
    {
        public WorkerControllerEditActionGetTests()
        {
            _repository.Setup(r => r.Find(It.IsAny<Expression<Func<Employee, bool>>>()))
                .Returns(_employeeData.Where(emp => emp.Id == _editId));
        }

        [TestMethod]
        public void ShouldRenderDefaultView()
        {
            var result = _controller.Edit(_editId);

            Assert.IsTrue(result.ViewName == "");
        }

        private int _editId = 1;
    }
}