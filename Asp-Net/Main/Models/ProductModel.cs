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
        [Display(Prompt ="Enter product name")]
        public string Name { get; set; }
        public string Url { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }

        public List<Category> SelectedCategories { get; set; }
    }
}