using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Code.Core.Models
{
    public class User : IdentityUser<Guid>
    {
        [StringLength(255)]
        public override string UserName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        public User()
        {
            UserRoles = new List<UserRole>(); 
        }
    }
}