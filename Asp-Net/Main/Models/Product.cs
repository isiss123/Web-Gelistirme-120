using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yoxlama.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage="Name məcburi bölümdür")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="Mehsul adı 3-60 karakter uzunlugu arasında olmalıdır")]
        public string Name { get; set; }
        [Required(ErrorMessage="Price məcburi bölümdür")]
        [Range(1.0,1000000.0,ErrorMessage ="Qiymət 1-1000000 arasında olamlıdır")]
        public double? Price { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage="ImageUrl məcburi bölümdür")]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        [Required(ErrorMessage="Category məcburi bölümdür")]
        public int? CategoryId { get; set; }

    }
}