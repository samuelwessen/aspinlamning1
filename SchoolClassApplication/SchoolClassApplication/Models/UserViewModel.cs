using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolClassApplication.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Required]        
        [DataType(DataType.Text)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }        

        [Required]
        [EmailAddress]        
        [Display(Name = "Email")]
        public string Email { get; set; }        

        public string Role { get; set; }

        public string GetDisplayName => $"{FirstName} {LastName}";
    }
}
