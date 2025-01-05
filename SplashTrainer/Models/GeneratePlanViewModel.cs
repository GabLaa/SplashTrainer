using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SplashTrainer.Models
{
    public class GeneratePlanViewModel
    {

        [Required(ErrorMessage = "Nazwa planu jest wymagana.")]
        [MaxLength(100, ErrorMessage = "Nazwa planu nie może być dłuższa niż 100 znaków.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Cel treningu jest wymagany.")]
        [RegularExpression("^(Nogi|Ręce|Koordynacja|Wytrzymałość|Szybkość)$", ErrorMessage = "Kategoria musi być jedną z : Nogi, Ręce, Koordynacja, Szybkość, Wytrzymałość.")]
        public string Goal { get; set; }


        [Required(ErrorMessage = "Poziom trudności jest wymagany.")]
        [RegularExpression("^(Początkujący|Zaawansowany)$", ErrorMessage = "Poziom musi być jednym z : Początkujący, Zaawansowany.")]
        public string Level { get; set; }


        [Required(ErrorMessage = "Styl pływania jest wymagany.")]
        [RegularExpression("^(Grzbiet|Kraul|Żaba|Delfin)$", ErrorMessage = "Styl musi być jednym z : Grzbiet, Kraul, Żaba, Delfin.")]
        public string Style { get; set; }


        [Required(ErrorMessage = "Dystans treningu jest wymagany.")]
        [RegularExpression(@"^(1000|1[1-9][0]{2}|[2-9][0]{3}|[1-4][0-9]{3}|5000)$", ErrorMessage = "Minimalny dystans treningu musi wynosić przynajmniej 1000m i być wielokrotnością 100m. Maksymalny dystans na trening to 5000m.")]
        //[Range(1000, 10000, ErrorMessage = "Minimalny dystans na trening musi wynosić przynajmniej 1000m.")]
        public int MinDistancePerTraining { get; set; }


        [Required(ErrorMessage = "Liczba treningów w tygodniu jest wymagana.")]
        [Range(1, 7, ErrorMessage = "Ilość treningów w tygodniu musi być między 1 a 7.")]
        public int WeeklyTrainingDays { get; set; }


        [Required(ErrorMessage = "Długość planu (w tygodniach) jest wymagana.")]
        [Range(1, 12, ErrorMessage = "Plan może trwać maksymalnie 12 tygodni.")]
        public int PlanDurationWeeks { get; set; }


        public List<DayOfWeek> TrainingDays { get; set; } = new List<DayOfWeek>();
    }
}
