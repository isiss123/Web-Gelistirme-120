using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string UserId { get; set; }


        [Required(ErrorMessage = "Password zəruri bölümdür")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "RePassword zəruri bölümdür")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "'Password' və 'RePassword' uyğun deyil")]
        public string RePassword { get; set; }
    }
}