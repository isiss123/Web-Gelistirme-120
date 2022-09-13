using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;

namespace Main.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Name məcburi bölümdür")]
        [StringLength(15,MinimumLength = 2, ErrorMessage = "Name üçün 2-15 karakter uzunluğu aralığında olmadlıdır")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Url məcburi bölümdür")]
        public string Url { get; set; }
        public List<Product> Products { get; set; }
    }
}