using biblioteka.Models;
using Microsoft.AspNetCore.Mvc;

namespace biblioteka.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(BookViewModel viewModel)
        {
            this.ViewBag.Message = $"{viewModel.Title} by {viewModel.Author} added to favorites!";
            return View("Info", viewModel);
        }
        [HttpGet]
        public IActionResult List()
        {
            List<BookViewModel> list = new List<BookViewModel>();
            list.Add(new BookViewModel() { Author = "Emily Bront\u00EB", Title = "Wuthering Heights", Status = Category.Planned });
            list.Add(new BookViewModel() { Author = "Herman Melville", Title = "Moby Dick", Status = Category.Planned });
            list.Add(new BookViewModel() { Author = "Johann Wolfgang von Goethe", Title = "Faust", Status = Category.Reading });
            return View(list);
        }
    }
}
