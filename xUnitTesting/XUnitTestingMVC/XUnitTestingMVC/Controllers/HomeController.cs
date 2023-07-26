using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XUnitTestingMVC.Models;
using XUnitTestingMVC.Services;

namespace XUnitTestingMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyServices _company;

        private readonly ILogger<HomeController> _logger;
        public HomeController(ICompanyServices company, ILogger<HomeController> logger)
        {
            _company = company;
            _logger = logger;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult RegisterCompany()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterCompany(Company company)
        {
            Common data = _company.RegisterCompany(company);
            TempData["Message"] = data.Message;

            return RedirectToAction("RegisterCompany");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}