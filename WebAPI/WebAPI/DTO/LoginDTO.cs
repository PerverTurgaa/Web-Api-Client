﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
