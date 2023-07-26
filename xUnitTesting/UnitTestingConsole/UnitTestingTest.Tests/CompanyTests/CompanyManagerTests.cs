using FluentAssertions;
using FluentAssertions.Equivalency.Tracing;
using FluentAssertions.Extensions;
using UnitTestingConsole;
using UnitTestingConsole.Company;
using UnitTestingConsole.Employee;
using FakeItEasy;

namespace UnitTestingTest.Tests.CompanyTests
{
    public class CompanyManagerTests
    {
        public CompanyManager _companyManager;
        public IEmployeeServices _services;
        public CompanyManagerTests()
        {
            //Dependency
            _services = A.Fake<IEmployeeServices>();

            //SUT
            _companyManager = new CompanyManager(_services);
        }
        [Fact]
        public void CompanyManager_AddCompany_ListOfCompany()
        {
            //Arrage
            CompanyProp prop = new CompanyProp();
            prop.Name = "Aashish";
            prop.Description = "Manager";
            prop.Salary = 1000000;
            prop.CreateDate = DateTime.Now;


            //Act
            IEnumerable<CompanyProp> results = _companyManager.AddCompany(prop);

            //Assert
            results.Should().NotBeEmpty().And.HaveCount(1).And.
                ContainEquivalentOf(prop);
            results.Should().Contain(x => x.Name == "Aashish");

            foreach(var items in results)
            {
                items.CreateDate.Should().BeAfter(1.January(2010)).And.
                    BeBefore(1.January(2030));
            }
        }


        [Theory]
        [InlineData("Aashish", "Manager", 8000000)]
        [InlineData("Mahesh", "Teacher", 7000000)]
        public void CompanyManager_AddCompany_ListOfCompanyV2(string nameOfImp, string post, decimal salary)
        {
            //Arrage
            CompanyProp companyProp = new CompanyProp();
            companyProp.Name = nameOfImp;
            companyProp.Salary = salary;
            companyProp.Description = post;
            companyProp.CreateDate = DateTime.Now;

            //Act
            var items = _companyManager.AddCompany(companyProp);

            //Assert

            items.Should().NotBeNull();
            items.Count().Should().Be(1);
            items.Should().ContainItemsAssignableTo<CompanyProp>();
        }
        [Fact]
        public void CompanyManager_GetCompanyList_CompanyModel()
        {
            //Arrange
            CompanyProp companyProp = new CompanyProp();
            companyProp.Name = "Aashish";
            companyProp.Salary = 20000;
            companyProp.Description = "Manager";
            companyProp.CreateDate = new DateTime(2010,02,01);

            //Act
            var items= _companyManager.GetCompanyList(companyProp);

            //Assert
            items.Should().BeOfType<CompanyProp>();
            items.CreateDate.Should().BeBefore(1.January(2030)).
                And.BeAfter(1.January(2010));
            items.CreateDate.Should<DateTime>();
            items.Name.Should().BeEquivalentTo(companyProp.Name);
            items.Salary.Should().Be(companyProp.Salary);
            items.Description.Should().Contain(companyProp.Description);
        }
        [Fact]

        public void Employee_EmployeeServices_ReturnString()
        {
            //Arrange
            string username = "Aashish";
            A.CallTo(() => _services.GetEmployeeDetail(username)).Returns("Aashish");

            //Act
            var items= _companyManager.GetEmployee(username);

            //Assert
            items.Should().NotBeNullOrEmpty();

        }



    }
}
