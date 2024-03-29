﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Registration
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^(?=,*[A-Z])(?=.*[a-z])(?=.*?[0-9](?=.*[#$^+=!*()@%&]).{6,}$",
            ErrorMessage ="Minimum lenght 6 and must" +
            " contain 1 Uppercase,1 lowercase,1 special " +
            "character and 1 digit")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        public string ? Role { get; set; }
    }
}
