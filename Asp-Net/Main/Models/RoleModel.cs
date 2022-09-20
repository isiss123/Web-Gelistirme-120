using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Main.Identity;
using Microsoft.AspNetCore.Identity;

namespace Main.Models
{
    public class RoleModel
    {
        [Required( ErrorMessage = "Name bölümü boş olmamalıdır")]
        public string Name { get; set; }
    }
    public class RoleDetailsModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
    public class RoleEditModel
    {
        public string RoleId { get; set; } 
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }

    }
}