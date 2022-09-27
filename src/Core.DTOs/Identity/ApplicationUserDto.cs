using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Identity
{
    public class ApplicationUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public List<ApplicationRoleDto> UserRoles { get; set; }
    }
}
