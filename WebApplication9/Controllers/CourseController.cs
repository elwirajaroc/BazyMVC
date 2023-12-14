using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        // GET: Course
        public CourseController()
        {
            _context = new ApplicationDbContext(); // Inicjalizacja ApplicationDbContext
        }
        public ActionResult Courses()
        {
            // Logika pobierania danych dotyczących kursów

            return View(); // Zwrócenie widoku z kursami
        }
        public ActionResult Index()
        {
            var courses = _context.Courses.ToList(); // Pobranie kursów z bazy danych
            return View(courses); // Przekazanie kursów do widoku
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course); // Dodanie nowego kursu do bazy danych
                _context.SaveChanges(); // Zapisanie zmian w bazie danych
                return RedirectToAction("Index");
            }
            return View(course);
        }
    }
}