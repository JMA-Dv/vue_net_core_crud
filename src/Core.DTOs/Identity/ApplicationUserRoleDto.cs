using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Identity
{
    public class ApplicationUserRoleDto
    {
        public ApplicationUserDto User { get; set; }
        public ApplicationRoleDto Role { get; set; }
    }
}
