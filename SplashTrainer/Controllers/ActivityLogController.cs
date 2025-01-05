using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SplashTrainer.Data;
using SplashTrainer.Models;
using System.Security.Claims;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;

namespace SplashTrainer.Controllers
{
    public class ActivityLogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityLogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Akcja wyświetlająca listę planów treningowych użytkownika
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Uzyskanie UserId z tożsamości użytkownika

            var plans = _context.SwimmingPlans
                //
             .Include(p => p.Exercises)
             //
             .ThenInclude(pe => pe.SwimmingExercise)
             .Where(p => p.UserId == userId)  // Filtrujemy plany po ID użytkownika
             .ToList();


            return View(plans);
        }

        // Akcja edytująca nazwę
        [HttpPost]
        public IActionResult EditPlanName(int id, string planName)
        {
            var plan = _context.SwimmingPlans.FirstOrDefault(p => p.Id == id);
            if (plan == null)
            {
                return Json(new { success = false, message = "Plan nie istnieje." });
            }

            plan.Name = planName;  // Zaktualizuj nazwę planu
            _context.SaveChanges(); // Zapisz zmiany w bazie danych

            return Json(new { success = true, message = "Nazwa planu została zaktualizowana." });
        }


        // Akcja usuwająca plan
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var plan = _context.SwimmingPlans.FirstOrDefault(p => p.Id == id);
            if (plan == null)
            {
                return Json(new { success = false, message = "Plan treningowy nie istnieje." });
            }

            // Usuwanie planu
            _context.SwimmingPlans.Remove(plan);
            _context.SaveChanges();

            return Json(new { success = true });
        }


        public IActionResult Details(int id)
        {
            var plan = _context.SwimmingPlans
                .Include(p => p.Exercises)
                .ThenInclude(pe => pe.SwimmingExercise)
                .FirstOrDefault(p => p.Id == id);

            if (plan == null)
            {
                return NotFound();
            }


            // Oblicz liczbę ukończonych i całkowitych treningów
            int totalTrainings = plan.Exercises.GroupBy(e => e.ExerciseDate).Count();
            int completedTrainings = plan.Exercises
                .Where(e => e.IsCompleted)
                .GroupBy(e => e.ExerciseDate)
                .Count();

            // Oblicz procent ukończenia planu
            double progressPercentage = totalTrainings > 0
            ? Math.Round((double)completedTrainings / totalTrainings * 100, 0) : 0; // Jedno miejsce po przecinku


            ViewData["Progress"] = progressPercentage;
            ViewData["CurrentProgress"] = progressPercentage; // Dla animacji
            ViewData["TotalTrainings"] = totalTrainings;
            ViewData["CompletedTrainings"] = completedTrainings;


            // Posortowanie ćwiczeń według "Treningu" 
            var exercisesGroupedByTraining = plan.Exercises
                .Where(pe => pe.SwimmingPlanId == id)
               .AsEnumerable() // Używamy LINQ-to-Objects, aby móc sortować po kluczach
               .GroupBy(pe => pe.ExerciseDate)
               .OrderBy(g => int.Parse(g.Key.Replace("Trening ", ""))) // Sortujemy numerycznie po numerze treningu
               .ToList();

               plan.TotalDistance = plan.Exercises.Sum(pe => pe.Distance);

            // Przypisujemy posortowane ćwiczenia do modelu
            ViewData["ExercisesGroupedByTraining"] = exercisesGroupedByTraining;

            return View(plan);
        }


        // oznaczenei ak zrobion 

        [HttpPost]
        public IActionResult MarkTrainingAsCompleted(int trainingId)
        {
            var training = _context.PlanExercises.FirstOrDefault(pe => pe.Id == trainingId);

            if (training != null)
            {
                training.IsCompleted = true; // Oznaczamy trening jako ukończony
                _context.SaveChanges();
            }

            // Przekierowanie do szczegółów planu, aby odświeżyć widok
            return RedirectToAction("Details", new { id = training.SwimmingPlanId });
        }




        [HttpGet]
        public IActionResult GeneratePdf(int planId)
        {
            // Pobranie danych z bazy danych
            var plan = _context.SwimmingPlans
                .Where(p => p.Id == planId)
                .Include(p => p.Exercises) // Pobranie powiązanych ćwiczeń
                .ThenInclude(e => e.SwimmingExercise) // Pobranie szczegółów ćwiczeń
                .AsEnumerable() // Przetwarzanie w pamięci
                .Select(p => new
                {
                    p.Name,
                    p.DateCreated,
                    Exercises = p.Exercises
                        .GroupBy(e => e.ExerciseDate) // Grupowanie po dacie treningu
                        .Select(g => new
                        {
                            Training = g.Key,
                            Exercises = g.Select(e => new
                            {
                                e.SwimmingExercise.Name,
                                e.SwimmingExercise.Distance,
                                e.SwimmingExercise.Level,
                                e.SwimmingExercise.Style
                            })
                        })
                })
                .FirstOrDefault();

            if (plan == null)
                return NotFound("Plan nie istnieje.");

            // Tworzenie dokumentu PDF
            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Deklaracja czcionek i kolorów
            var fontTitle = new XFont("Arial", 16);
            var fontHeader = new XFont("Arial", 12);
            var fontBody = new XFont("Arial", 10);
            var headerBrush = XBrushes.White;
            var headerBackgroundBrush = new XSolidBrush(XColors.ForestGreen);
            var rowBackgroundBrush = new XSolidBrush(XColors.LightGray);
            var textBrush = XBrushes.Black;

            // Marginesy
            double marginLeft = 40;
            double marginTop = 40;
            double yPoint = marginTop;
            double marginBottom = 40;
            double pageHeightLimit = page.Height - marginBottom;

            // Tytuł planu
            gfx.DrawString($"Plan treningowy: {plan.Name}", fontTitle, textBrush,
                new XRect(0, yPoint, page.Width, page.Height), XStringFormats.TopCenter);
            yPoint += 40;

            gfx.DrawString($"Data utworzenia: {plan.DateCreated:dd/MM/yyyy}", fontBody, textBrush,
                new XRect(marginLeft, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
            yPoint += 30;

            // Iteracja przez treningi
            foreach (var training in plan.Exercises)
            {
                // Sprawdzenie, czy trzeba utworzyć nową stronę
                if (yPoint + 40 > pageHeightLimit)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    yPoint = marginTop;
                }

                // Nagłówek treningu
                gfx.DrawString(training.Training, fontHeader, textBrush,
                    new XRect(marginLeft, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
                yPoint += 20;

                // Sprawdzenie, czy trzeba utworzyć nową stronę przed nagłówkami tabeli
                if (yPoint + 40 > pageHeightLimit)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    yPoint = marginTop;
                }

                // Rysowanie nagłówków tabeli
                gfx.DrawRectangle(headerBackgroundBrush, marginLeft, yPoint, page.Width - marginLeft * 2, 20);
                gfx.DrawString("Ćwiczenie", fontBody, headerBrush, new XRect(marginLeft, yPoint, 200, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Dystans", fontBody, headerBrush, new XRect(marginLeft + 200, yPoint, 100, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Poziom", fontBody, headerBrush, new XRect(marginLeft + 300, yPoint, 100, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Styl", fontBody, headerBrush, new XRect(marginLeft + 400, yPoint, 100, page.Height), XStringFormats.TopLeft);
                yPoint += 20;

                // Ćwiczenia w treningu
                bool isAlternateRow = false; // Flaga dla kolorowania wierszy
                foreach (var exercise in training.Exercises)
                {
                    // Sprawdzenie, czy trzeba utworzyć nową stronę przed każdym wierszem
                    if (yPoint + 20 > pageHeightLimit)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        yPoint = marginTop;
                    }

                    // Kolorowanie co drugiego wiersza
                    if (isAlternateRow)
                    {
                        gfx.DrawRectangle(rowBackgroundBrush, marginLeft, yPoint, page.Width - 2 * marginLeft, 20);
                    }

                    // Rysowanie tekstu w kolumnach
                    gfx.DrawString(exercise.Name, fontBody, textBrush,
                        new XRect(marginLeft, yPoint, 200, page.Height), XStringFormats.TopLeft);
                    gfx.DrawString($"{exercise.Distance}m", fontBody, textBrush,
                        new XRect(marginLeft + 200, yPoint, 100, page.Height), XStringFormats.TopLeft);
                    gfx.DrawString(exercise.Level, fontBody, textBrush,
                        new XRect(marginLeft + 300, yPoint, 100, page.Height), XStringFormats.TopLeft);
                    gfx.DrawString(exercise.Style, fontBody, textBrush,
                        new XRect(marginLeft + 400, yPoint, 100, page.Height), XStringFormats.TopLeft);

                    yPoint += 20;
                    isAlternateRow = !isAlternateRow; // Przełączanie wierszy
                }
                yPoint += 20; // Odstęp po każdym treningu
            }

            // Zapisanie dokumentu do strumienia
            using (var stream = new MemoryStream())
            {
                document.Save(stream, false);
                stream.Seek(0, SeekOrigin.Begin); // Reset pozycji strumienia
                return File(stream.ToArray(), "application/pdf", $"{plan.Name}.pdf");
            }
        }


    }
}
