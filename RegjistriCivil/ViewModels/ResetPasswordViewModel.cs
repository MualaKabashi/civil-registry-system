﻿using System.ComponentModel.DataAnnotations;

namespace RegjistriCivil.ViewModels;

public class ResetPasswordViewModel
{
    [Required]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "Password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
    
    public string UserId { get; set; } 
}