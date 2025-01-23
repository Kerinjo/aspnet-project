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

        // Create
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

        // Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var media = _service.FindById(id);
            if (media == null)
            {
                return NotFound();
            }
            return View(media);
        }

        [HttpPost]
        public IActionResult Edit(MediaViewModel media)
        {
            if (ModelState.IsValid)
            {
                _service.Update(media);
                return RedirectToAction("Index");
            }
            return View(media);
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var media = _service.FindById(id);
            if (media == null)
            {
                return NotFound();
            }
            return View(media);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        // Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var media = _service.FindById(id);
            if (media == null)
            {
                return NotFound();
            }
            return View(media);
        }

    }
}