
namespace SplashTrainer.Models
{
    public class PlanExercise // łączy ćwiczenia z planami treningowymi
    {
        public int Id { get; set; }
        public int SwimmingPlanId { get; set; } // klucz oby 
        public SwimmingPlan SwimmingPlan { get; set; } // dostęp do obiektu
        public int SwimmingExerciseId { get; set; } // klucz obcy
        public SwimmingExercise SwimmingExercise { get; set; } // dostęp do obiektu
        public string ExerciseDate { get; set; }
        public TimeSpan? ExerciseTime { get; set; }
       
        // Dystans dla tego ćwiczenia w ramach planu
        public int Distance { get; set; }

        public bool IsCompleted { get; set; } = false; // Domyślnie trening nie jest ukończony

    }
}
