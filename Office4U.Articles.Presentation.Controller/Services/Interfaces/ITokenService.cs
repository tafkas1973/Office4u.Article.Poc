using System.Threading.Tasks;
using Office4U.Articles.Domain.Model.Entities;

namespace Office4U.Articles.Presentation.Controller.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
