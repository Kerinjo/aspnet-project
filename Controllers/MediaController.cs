using biblioteka.Models;
using Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace biblioteka.Controllers
{
    public class MediaController : Controller
    {
        static List<MediaViewModel> mediaList = new List<MediaViewModel>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(mediaList);
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
                media.Id = mediaList.Max(x => x.Id) + 1;
                mediaList.Add(media);
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
