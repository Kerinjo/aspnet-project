using Microsoft.AspNetCore.Mvc;

namespace biblioteka.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(string email, bool consent, int age)
        {
            if (age < 18)
                this.ViewBag.Message = "You need to be older than 18 years to register here! ";
            else if (consent == false)
                this.ViewBag.Message = "Consent not provided!";
            else
                this.ViewBag.Message = $"User {email} registered!";
            return View("Index");
        }
    }

}
