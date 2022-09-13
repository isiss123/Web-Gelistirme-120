using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;

namespace Main.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Name məcburi bölümdür")]
        [StringLength(60,MinimumLength = 3, ErrorMessage = "Name üçün 3-60 karakter uzunluğu aralığında olmadlıdır")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Url məcburi bölümdür")]
        public string Url { get; set; }

        [Required(ErrorMessage ="Price məcburi bölümdür")]
        [Range(0.5,100000,ErrorMessage ="Price üçün 0.5-100000 arasında dəyər girə bilərsiniz")]
        public double? Price { get; set; }

        [Required(ErrorMessage ="Description məcburi bölümdür")]
        [StringLength(250,MinimumLength = 10, ErrorMessage = "Description üçün 15-250 karakter uzunluğu aralığında olmadlıdır")]
        public string Description { get; set; }

        [Required(ErrorMessage ="ImageUrl məcburi bölümdür")]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }

        public List<Category> SelectedCategories { get; set; }
    }
}