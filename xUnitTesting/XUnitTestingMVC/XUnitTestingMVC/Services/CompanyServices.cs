using XUnitTestingMVC.Context;
using XUnitTestingMVC.Models;

namespace XUnitTestingMVC.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ApplicationDbContext _context;
        public CompanyServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public Common RegisterCompany(Company company)
        {
            _context.Add(company);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return new Common()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success"

                };
            }
            else
            {
                return new Common()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Failed"
                };
            }
        }
    }
}
