﻿using System.ComponentModel.DataAnnotations;

namespace RegjistriCivil.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        //[EmailAddress]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
