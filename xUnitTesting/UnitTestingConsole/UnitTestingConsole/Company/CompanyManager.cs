using UnitTestingConsole.Employee;

namespace UnitTestingConsole.Company
{
    public class CompanyManager
    {
        private readonly IEmployeeServices _services;
        public CompanyManager(IEmployeeServices services)
        {
            _services= services;
        }
        List<CompanyProp> companylist = new List<CompanyProp>();
        public List<CompanyProp> AddCompany(CompanyProp company)
        {
            companylist.Add(new CompanyProp()
            {
                Name = company.Name,
                Description = company.Description,
                Salary = company.Salary,
                CreateDate= company.CreateDate
            });
            return companylist;
        }
        public CompanyProp GetCompanyList(CompanyProp company)
        {
            return company;
        }
        public string GetEmployee(string name)
        {
            return _services.GetEmployeeDetail(name);
        }
    }

}
