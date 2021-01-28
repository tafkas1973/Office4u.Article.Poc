using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Office4U.Articles.Domain.Model.Entities
{
    public class AppRole: IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}