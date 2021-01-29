using Office4U.Articles.Common;
using Office4U.Articles.ReadApplication.Interfaces;
using System.Threading.Tasks;

namespace Office4U.Articles.ReadApplication.Article.Interfaces.IOC
{
    public interface IReadOnlyArticleRepository : IReadOnlyRepositoryBase
    {
        Task<PagedList<Domain.Model.Entities.Articles.Article>> GetArticlesAsync(ArticleParams articleParams);
        Task<Domain.Model.Entities.Articles.Article> GetArticleByIdAsync(int id);
    }
}