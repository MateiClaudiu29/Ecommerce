using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class SpecialTags
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Special Tag")]
        public string SpecialTag { get; set; }
    }
}
