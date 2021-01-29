using Microsoft.AspNetCore.Identity;

namespace Office4U.Articles.Domain.Model.Entities.Users
{
    public class AppUserRole: IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}    
