using System.Linq;
using EmployeeDomain;
using EmployeeDomain.Custom;
using EmployeeTests.Fakes;
using EmployeeWeb.Controllers;
using Moq;

namespace EmployeeTests.Custom.Controllers
{
    public class EmployeeControllerTestBase
    {
        
        public EmployeeControllerTestBase()
        {
            _employeeData = EmployeeObjectMother.CreateEmployees()
                .AsQueryable();
            _repository = new Mock<IRepository<Employee>>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(u => u.Employees)
                .Returns(_repository.Object);

            _controller = new WorkerController(_unitOfWork.Object);
        }

        protected IQueryable<Employee> _employeeData;
        protected Mock<IUnitOfWork> _unitOfWork;
        protected WorkerController _controller;
        protected Mock<IRepository<Employee>> _repository;
    }
}