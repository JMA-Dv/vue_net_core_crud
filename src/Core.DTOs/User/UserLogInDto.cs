﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTOs.User
{
    public class UserLogInDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
