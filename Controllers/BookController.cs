using biblioteka.Models;
using Microsoft.AspNetCore.Mvc;

namespace biblioteka.Controllers
{
    public class BookController : Controller
    {
        static List<BookViewModel> books = new List<BookViewModel>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(books);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                book.Id = books.Max(x => x.Id) + 1;
                books.Add(book);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
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
