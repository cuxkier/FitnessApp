using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Fitness.Models
{
    public class Diet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DietName { get; set; }
        [Required(ErrorMessage = "Pole \"Kaloryczność Diety\" jest wymagane.")]
        [DisplayName("Kaloryczność Diety")]
        public int Kcal { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        public int CategoryDietId { get; set; }
        [ForeignKey("CategoryDietId")]
        [ValidateNever]
        public DietsCategory DietsCategory { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }
    }
}
