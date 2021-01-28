using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Office4U.Articles.Common;

namespace Office4U.Articles.Domain.Model.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public ICollection<AppUserRole> UserRoles { get; set; }
        public int GetAge() {
            return DateOfBirth.CalculateAge();
        }
    }
}
