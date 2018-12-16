using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Code.Core.Models
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }

        public User()
        {
            UserRoles = new List<UserRole>(); 
        }
    }
}