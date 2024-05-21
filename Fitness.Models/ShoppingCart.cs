using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int DietId { get; set; }
        [ForeignKey("DietId")]
        [ValidateNever]
        public Diet Diet { get; set; }
        [Range(1,10, ErrorMessage = "Proszę podać wartość między 1, a 10")]
        public int Count { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        [NotMapped]
        public double Price { get; set; }
    }
}
