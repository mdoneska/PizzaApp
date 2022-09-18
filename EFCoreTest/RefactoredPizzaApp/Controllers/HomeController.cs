using Microsoft.AspNetCore.Mvc;
using PizzaApp05.Models;
using System.Diagnostics;

namespace PizzaApp05.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() //localhost:[port]/Home
        {
            return View();
        }

        public IActionResult Privacy() //localhost:[port]/Home/Privacy
        {
            return View();
        }
        [Route("AboutUs")]
        public IActionResult About() //localhost:[port]/AboutUs
        {
            return View();
        }
        [Route("ContactUs")]
        public IActionResult Contact() //localhost:[port]/ContactUs
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}