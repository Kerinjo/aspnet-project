using biblioteka.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace biblioteka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromQuery] string name, [FromQuery] int age, [FromQuery] bool hasCard)
        {
            string username = this.Request.Query["Name"].ToString();
            if (string.IsNullOrEmpty(username))
                username = "Stranger";
            ViewData["User"] = username;

            ViewData["IsAdult"] = age >= 18 ? "Over 18" : "Under 18";

            ViewData["HasCard"] = hasCard ? "Do you want to borrow a book?":"Please register for a card";

            if (hasCard)
            {
                return View("After");
            }
            else
            {
                return View("Before");
            }

            return View(); 
        }

        public IActionResult Privacy()
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
