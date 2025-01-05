using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SplashTrainer.Data;
using SplashTrainer.Models;
using System.Linq;

namespace SplashTrainer.Controllers
{
    public class SwimmingExerciseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SwimmingExerciseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Widok Index
        [HttpGet]
        public IActionResult Index()
        { 
            var exercises = _context.SwimmingExercises.ToList();
            return View(exercises);
        }


        // Filtrowanie ćwiczeń na podstawie stylu i kategorii
        [HttpGet]
        public IActionResult Filter(string style, string category)
        {
            var exercises = _context.SwimmingExercises
                .Where(e => e.Style == style && e.Category == category)
                .ToList();

            return PartialView("_ExerciseListPartial", exercises);
        }

        // Widok dodawania ćwiczeń
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(SwimmingExercise exercise)
        {
            if (ModelState.IsValid)
            {
                _context.SwimmingExercises.Add(exercise);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            //return Json(new { success = false, errors });

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var exercise = _context.SwimmingExercises.FirstOrDefault(e => e.Id == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return PartialView("Details", exercise);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var exercise = _context.SwimmingExercises.FirstOrDefault(e => e.Id == id);
            if (exercise == null)
            {
                return Json(new { success = false, message = "Ćwiczenie nie istnieje." });
            }

            if (exercise.IsDefault)
            {
                return Json(new { success = false, message = "Nie można usunąć domyślnych ćwiczeń." });
            }

            _context.SwimmingExercises.Remove(exercise);
            _context.SaveChanges();

            return Json(new { success = true });
        }


    }
}


