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
            ViewData["LastVisit"] = Response.HttpContext.Items[Middleware.LastVisitMiddleware.CookieName];
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
