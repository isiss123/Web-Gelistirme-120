using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "FirstName zəruri bölümdür")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName zəruri bölümdür")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UserName zəruri bölümdür")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password zəruri bölümdür")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "RePassword zəruri bölümdür")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "'Password' və 'RePassword' uyğun deyil")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Email zəruri bölümdür")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}