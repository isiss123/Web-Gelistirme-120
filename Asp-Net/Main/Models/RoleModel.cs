using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class RoleModel
    {
        [Required( ErrorMessage = "Name bölümü boş olmamalıdır")]
        public string Name { get; set; }
    }
}