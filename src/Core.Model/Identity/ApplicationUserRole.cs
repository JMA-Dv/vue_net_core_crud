using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Identity
{
    public class ApplicationUserRole:IdentityUserRole<string>
    {
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
    }
}
