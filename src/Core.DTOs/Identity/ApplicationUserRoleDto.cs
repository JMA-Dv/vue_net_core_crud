using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Identity
{
    public class ApplicationUserRoleDto: IdentityUserRole<string>
    {
        public ApplicationUserDto User { get; set; }
        public ApplicationRoleDto Role { get; set; }
    }
}
