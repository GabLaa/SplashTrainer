using Microsoft.AspNetCore.Mvc;
using SplashTrainer.Models;
using SplashTrainer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;

namespace SplashTrainer.Controllers
{
    public class SwimmingPlanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SwimmingPlanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Strona główna - wybór opcji (Generowanie planu / Ręczne tworzenie)
        public IActionResult Index()
        {
            return View();
        }

        // Generowanie planu na podstawie odpowiedzi użytkownika
        public IActionResult GeneratePlan()
        {
            // Tutaj dodasz kod do obsługi formularza z pytaniami
            return View();
        }

        [HttpPost]
        public IActionResult GeneratePlan(GeneratePlanViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var totalDistance = model.PlanDurationWeeks * model.WeeklyTrainingDays * model.MinDistancePerTraining;

                var newPlan = new SwimmingPlan
                {
                    UserId = userId,
                    Name = model.Name,
                    DateCreated = DateTime.Now,
                    Goal = model.Goal,
                    Level = model.Level,
                    Style = model.Style,
                    TotalDistance = totalDistance,
                    TrainingDays = model.TrainingDays
                };

                _context.SwimmingPlans.Add(newPlan);
                _context.SaveChanges();

                var exercises = _context.SwimmingExercises
                    .Where(e => e.Category == model.Goal && e.Level == model.Level && e.Style.Contains(model.Style))
                    .ToList();

                var planExercises = new List<PlanExercise>();
                var remainingDistance = totalDistance;

                var trainingIndex = 1; // Liczba treningu: Trening 1, Trening 2, ...

                // Generowanie ćwiczeń na każdy trening
                for (int week = 1; week <= model.PlanDurationWeeks; week++)
                {
                    for (int day = 1; day <= model.WeeklyTrainingDays; day++)
                    {
                        var dayDistance = 0;

                        while (dayDistance < model.MinDistancePerTraining && remainingDistance > 0)
                        {
                            foreach (var exercise in exercises)
                            {
                                if (exercise.Distance <= remainingDistance && dayDistance + exercise.Distance <= model.MinDistancePerTraining)
                                {
                                    planExercises.Add(new PlanExercise
                                    {
                                        SwimmingPlanId = newPlan.Id,
                                        SwimmingExerciseId = exercise.Id,
                                        ExerciseDate = $"Trening {trainingIndex}",  // Przypisujemy trening
                                        Distance = exercise.Distance
                                    });

                                    dayDistance += exercise.Distance;
                                    remainingDistance -= exercise.Distance;

                                    if (remainingDistance <= 0 || dayDistance >= model.MinDistancePerTraining)
                                    {
                                        break; // Wychodzimy z `foreach`, gdy osiągniemy dzienny dystans lub braknie dystansu.
                                    }
                                }
                            }


                            if (dayDistance == 0) // Jeśli żadne ćwiczenie nie pasuje
                            {
                                var smallestExercise = exercises
                                    .Where(e => e.Distance <= remainingDistance)
                                    .OrderBy(e => e.Distance)
                                    .FirstOrDefault();

                                if (smallestExercise != null)
                                {
                                    planExercises.Add(new PlanExercise
                                    {
                                        SwimmingPlanId = newPlan.Id,
                                        SwimmingExerciseId = smallestExercise.Id,
                                        ExerciseDate = $"Trening {trainingIndex}",
                                        Distance = smallestExercise.Distance
                                    });

                                    dayDistance += smallestExercise.Distance;
                                    remainingDistance -= smallestExercise.Distance;
                                }
                                else
                                {
                                    break; // Jeśli nie ma już ćwiczeń do dodania, kończymy pętlę
                                }
                            }


                        }

                            trainingIndex++;
                        
                    }
                }

                _context.PlanExercises.AddRange(planExercises);
                _context.SaveChanges();

                return RedirectToAction("Details", new { id = newPlan.Id });
            }

            return View(model);
        }

        // Akcja szczegółów planu treningowego
        public IActionResult Details(int id)
        {
            var plan = _context.SwimmingPlans
                .FirstOrDefault(p => p.Id == id);

            if (plan == null)
            {
                return NotFound();
            }

            ViewData["PlanName"] = plan.Name;
            ViewData["DateCreated"] = plan.DateCreated.ToString("dd.MM.yyyy");

            return View("Details");
        }


    }
}



