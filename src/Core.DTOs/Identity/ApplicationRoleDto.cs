using System.Collections.Generic;

namespace Core.DTOs.Identity
{
    public class ApplicationRoleDto
    {
        public List<ApplicationUserRoleDto> UserRoles { get; set; }
    }
}