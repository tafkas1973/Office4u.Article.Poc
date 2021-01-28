using System.Threading.Tasks;
using Office4U.Articles.Common;
using Office4U.Articles.Domain.Model.Entities;

namespace Office4U.Articles.Data.Ef.SqlServer.Interfaces
{
    public interface IArticleRepository: IRepositoryBase
    {
        Task<PagedList<Article>> GetArticlesAsync(ArticleParams articleParams);
        Task<Article> GetArticleByIdAsync(int id);
    }
}