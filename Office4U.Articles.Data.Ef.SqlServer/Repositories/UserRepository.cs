using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Office4U.Articles.Domain.Model.Entities;
using Office4U.Articles.Data.Ef.SqlServer.Interfaces;
using Office4U.Articles.Common;

namespace Office4U.Articles.Data.Ef.SqlServer.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<PagedList<AppUser>> GetUsersAsync(UserParams userParams)
        {
            var users = _context.Users
                .AsQueryable();

            return await PagedList<AppUser>.CreateAsync(
                users,
                userParams.PageNumber,
                userParams.PageSize);
        }
    }
}