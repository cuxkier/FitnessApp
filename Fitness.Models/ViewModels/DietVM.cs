using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Models.ViewModels
{
    public class DietVM
    {
        public Diet Diet { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DietsCategoryList { get; set; }

        public string? ImageUrl { get; set; }
    }
}
