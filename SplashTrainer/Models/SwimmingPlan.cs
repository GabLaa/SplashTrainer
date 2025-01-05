using SplashTrainer.Models;
using System.ComponentModel.DataAnnotations;

namespace SplashTrainer.Models
{
    public class SwimmingPlan // plan treningowy użytkownika 
    {
        public int Id { get; set; }
        public string Name { get; set; } // nazwa planu, podana przez użytkownika
        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }
        public int TotalDistance { get; set; }
        public ICollection<PlanExercise> Exercises { get; set; } = new List<PlanExercise>(); // Relacja: Jeden plan ma wiele ćwiczeń

        public ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

        [Required(ErrorMessage = "Cel treningu jest wymagany.")]
        [RegularExpression("^(Nogi|Ręce|Koordynacja|Wytrzymałość|Szybkość)$", ErrorMessage = "Kategoria musi być jedną z : Nogi, Ręce, Koordynacja, Szybkość, Wytrzymałość.")]
        public string Goal { get; set; }

        [Required(ErrorMessage = "Poziom trudności jest wymagany.")]
        [RegularExpression("^(Początkujący|Zaawansowany)$", ErrorMessage = "Poziom musi być jednym z : Początkujący, Zaawansowany.")]
        public string Level { get; set; }

        [Required(ErrorMessage = "Styl pływania jest wymagany.")]
        [RegularExpression("^(Grzbiet|Kraul|Żaba|Delfin)$", ErrorMessage = "Styl musi być jednym z : Grzbiet, Kraul, Żaba, Delfin.")]
        public string Style { get; set; }


        [Required(ErrorMessage = "Proszę wybrać dni treningowe.")]
        public ICollection<DayOfWeek>? TrainingDays { get; set; }
    }
}

