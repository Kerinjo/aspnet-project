using biblioteka.Models;
using Microsoft.AspNetCore.Mvc;

namespace biblioteka.Controllers;

public class StudentController : Controller
{
    static List<StudentViewModel> students = new List<StudentViewModel>();

    [HttpGet]
    public IActionResult Index()
    {
        return View(students);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(StudentViewModel student)
    {
        if (ModelState.IsValid)
        {
            // data validated
            student.Id = students.Max(x => x.Id) + 1;
            students.Add(student);
            return RedirectToAction("Index");
        }
        else
        {
            return View(); // go back to the form with errors
        }
    }
}