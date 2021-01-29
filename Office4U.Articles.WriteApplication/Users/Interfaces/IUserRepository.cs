using System.Threading.Tasks;
using Office4U.Articles.Common;
using Office4U.Articles.Domain.Model.Entities.Users;
using Office4U.Articles.WriteApplication.Interfaces.IOC;

namespace Office4U.Articles.WriteApplication.User.Interfaces
{
    public interface IUserRepository: IRepositoryBase
    {
        Task<PagedList<AppUser>> GetUsersAsync(UserParams userParams);
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);            
    }
}