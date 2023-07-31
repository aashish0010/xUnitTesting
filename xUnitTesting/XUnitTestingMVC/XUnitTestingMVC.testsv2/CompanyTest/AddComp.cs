using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using XUnitTestingMVC.Controllers;
using XUnitTestingMVC.Models;
using XUnitTestingMVC.Services;

namespace XUnitTestingMVC.testsv2.CompanyTest
{
    public class AddComp
    {
        private HomeController _homeController;
        private Mock<ICompanyServices> _mockobj;
        public AddComp()
        {

            _mockobj = new Mock<ICompanyServices>();
            _homeController = new HomeController(_mockobj.Object);
            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            _homeController.TempData = tempData;
        }
        [Fact]
        public void HomeContoller_RegisterCompany_Success()
        {
            //Arrange
            Company company = new Company();
            Common common = new Common();
            _mockobj.Setup(m => m.RegisterCompany(company)).Returns(common);

            //Act

            var result = _homeController.RegisterCompany(company);

            //Assert
            result.Should().BeOfType<RedirectToActionResult>();

        }
    }
}
