using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.DTOs.Identity
{
    public class ApplicationUserDto
    {
         public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
