namespace UnitTestingConsole.Company
{
    public class CompanyManager
    {
        List<CompanyProp> companylist = new List<CompanyProp>();
        public List<CompanyProp> AddCompany(CompanyProp company)
        {
            companylist.Add(new CompanyProp()
            {
                Name = company.Name,
                Description = company.Description,
                Salary = company.Salary,
            });
            return companylist;
        }
    }

}
