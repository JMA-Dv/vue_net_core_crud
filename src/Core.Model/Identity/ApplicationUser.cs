using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public DateTime? BirthDay { get; set; }
        public List<ApplicationUserRole> UserRoles { get; set; }

    }
}
