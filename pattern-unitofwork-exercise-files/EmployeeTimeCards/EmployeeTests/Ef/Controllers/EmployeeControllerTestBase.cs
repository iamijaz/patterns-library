using System.Collections.Generic;
using System.Linq;
using EmployeeDomain;
using EmployeeTests.Fakes;
using EmployeeTests.Fakes.EF;
using EmployeeWeb.Controllers;

namespace EmployeeTests.Ef.Controllers
{
    public class EmployeeControllerTestBase
    {
        protected EmployeeControllerTestBase()
        {
            _employeeData = EmployeeObjectMother.CreateEmployees().ToList();
            _repository = new InMemoryObjectSet<Employee>(_employeeData);
            _unitOfWork = new InMemoryUnitOfWork {Employees = _repository};
            _controller = new EmployeeController(_unitOfWork);
        }

        protected readonly IList<Employee> _employeeData;
        protected readonly EmployeeController _controller;
        protected readonly InMemoryObjectSet<Employee> _repository;
        protected readonly InMemoryUnitOfWork _unitOfWork;
    }
}