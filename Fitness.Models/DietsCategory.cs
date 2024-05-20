using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fitness.Models
{
    public class DietsCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Kategoria Diety")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Range(1, 100, ErrorMessage = "Wartość tego pola musi wynosić 1-100")]
        [DisplayName("Display Order")]
        public int? DisplayOrder { get; set; }
    }
}
