using Office4U.Articles.WriteApplication.Interfaces.IOC;
using System.Threading.Tasks;

namespace Office4U.Articles.WriteApplication.Article.Interfaces.IOC
{
    public interface IArticleRepository : IRepositoryBase
    {
        Task<Domain.Model.Entities.Article> GetArticleByIdAsync(int id);
    }
}