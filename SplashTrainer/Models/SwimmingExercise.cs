using System.ComponentModel.DataAnnotations;

namespace SplashTrainer.Models
{
    public class SwimmingExercise //pojedyncze ćwiczenie 
    {
        public int Id { get; set; }
        public bool IsDefault { get; set; } // Flaga wskazująca, czy ćwiczenie jest domyślne

        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Dystans jest wymagany.")]
        [RegularExpression(@"^(25|50|75|[1-9][0][0]*0|[1-9][0-9]*75|[1-9][0-9]*50|[1-9][0-9]*25)$", ErrorMessage = "Dystans musi być większy lub równy 25 i być wielokrotnością 25.")]
        public int Distance { get; set; }

        [Required(ErrorMessage = "Kategoria jest wymagana.")]
        [RegularExpression("^(Nogi|Ręce|Koordynacja|Wytrzymałość|Szybkość)$", ErrorMessage = "Kategoria musi być jedną z : Nogi, Ręce, Koordynacja, Szybkość, Wytrzymałość.")]
        public string Category { get; set; } // np. wytrzymałość, technika, cw nogi

        [Required(ErrorMessage = "Opis jest wymagany.")]
        public string Description { get; set; }

        [Required]
        [RegularExpression("^(Początkujący|Zaawansowany)$", ErrorMessage = "Poziom musi być jednym z : Początkujący, Zaawansowany.")]
        public string Level { get; set; }   // np. poczatkujący

        [Required]
        [RegularExpression("^(Grzbiet|Kraul|Żaba|Delfin)$", ErrorMessage = "Styl musi być jednym z : Grzbiet, Kraul, Żaba, Delfin.")]
        public string Style { get; set; }


    }
}
