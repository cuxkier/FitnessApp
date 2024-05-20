using System.ComponentModel.DataAnnotations;

namespace Fitness.Models
{
    public class CalorieCalculatorModel
    {
        [Required(ErrorMessage = "Pole wymagane")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Range(1, 120, ErrorMessage = "Wiek musi być liczbą między 1 a 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Range(1, 300, ErrorMessage = "Waga musi być liczbą między 1 a 300")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Range(1, 250, ErrorMessage = "Wzrost musi być liczbą między 1 a 250")]
        public int Height { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public ActivityLevel ActivityLevel { get; set; }
    }

    public enum ActivityLevel
    {
        Sedentary,
        LightlyActive,
        ModeratelyActive,
        VeryActive,
        ExtraActive
    }
}
