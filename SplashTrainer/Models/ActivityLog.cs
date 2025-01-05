using SplashTrainer.Models;
using System.ComponentModel.DataAnnotations;

namespace SplashTrainer.Models
{
    public class ActivityLog // dziennik aktywności użytkownika
    {
        public int Id { get; set; }  // Klucz główny

        public int SwimmingPlanId { get; set; }  // Klucz obcy
        public SwimmingPlan SwimmingPlan { get; set; }  // Powiązanie z SwimmingPlan

        public DateTime CreatedDate { get; set; }

        public string Action { get; set; }
    }
}