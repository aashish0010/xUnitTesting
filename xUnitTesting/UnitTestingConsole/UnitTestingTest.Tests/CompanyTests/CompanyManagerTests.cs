using FluentAssertions;
using UnitTestingConsole;
using UnitTestingConsole.Company;

namespace UnitTestingTest.Tests.CompanyTests
{
    public class CompanyManagerTests
    {
        [Fact]
        public void CompanyManager_AddCompany_ListOfCompany()
        {
            //Arrage
            CompanyProp prop = new CompanyProp();
            prop.Name = "Aashish";
            prop.Description = "Manager";
            prop.Salary = 1000000;
            CompanyManager manager = new CompanyManager();


            //Act

            var results = manager.AddCompany(prop);

            //Assert

            results.Should().NotBeEmpty().And.HaveCount(1).And.
                ContainItemsAssignableTo<CompanyProp>();
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
            CompanyManager manager = new CompanyManager();

            //Act
            var items = manager.AddCompany(companyProp);

            //Assert

            items.Should().NotBeNull();
            items.Count().Should().Be(1);
            items.Should().ContainItemsAssignableTo<CompanyProp>();
        }
    }
}
