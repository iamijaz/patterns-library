using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTests.Custom.Controllers {
    [TestClass]
    public class EmployeeControllerDetailsActionTests
               : EmployeeControllerTestBase {
        

        [TestMethod]
        public void ShouldRenderDefaultView() {
            var result = _controller.Details(_detailsId);

            Assert.IsTrue(result.ViewName == "");
        }

        [TestMethod]
        public void ShouldInvokeRepositoryToFindEmployee() {
            var result = _controller.Details(_detailsId);

            _repository.Verify(r => r.FindById(_detailsId));
        }

        int _detailsId = 1;
    }
}