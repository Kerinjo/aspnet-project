using biblioteka.Models;
using biblioteka.Services;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace biblioteka.Controllers
{
    public class MediaController : Controller
    {
        private IMediaService _service;
        public MediaController(IMediaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_service.FindAll());
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
                // data validated

                _service.Add(media);
                return RedirectToAction("Index");
            }
            else
            {
                return View(); // go back to the form with errors
            }
        }
    }
}