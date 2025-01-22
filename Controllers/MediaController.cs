using biblioteka.Models;
using Shared.Enums;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace biblioteka.Controllers
{
    public class MediaController : Controller
    {
        static List<MediaViewModel> mediaList = new List<MediaViewModel>();
        private LibraryContext _context;
        public MediaController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Media.ToList());
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MediaViewModel media)
        {
            if (ModelState.IsValid)
            {
                this._context.Add(media);
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
            List<MediaViewModel> list = new List<MediaViewModel>();
            list.Add(new MediaViewModel() { 
                Author = "Emily Bront\u00EB", Title = "Wuthering Heights",
                Status = Status.Planned,      Category = Category.Book 
            });
            list.Add(new MediaViewModel() {
                Author = "Herman Melville", Title = "Moby Dick",
                Status = Status.Planned,    Category = Category.Book
            });
            list.Add(new MediaViewModel() {
                Author = "Johann Wolfgang von Goethe", Title = "Faust",
                Status = Status.InProgress, Category = Category.Book
            });
            return View(list);
        }
    }
}
