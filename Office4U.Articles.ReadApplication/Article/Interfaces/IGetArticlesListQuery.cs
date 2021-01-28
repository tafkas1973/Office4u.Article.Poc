using Office4U.Articles.Common;
using Office4U.Articles.ReadApplication.Article.DTO;
using System.Threading.Tasks;

namespace Office4U.Articles.ReadApplication.Article.Interfaces
{
    public interface IGetArticlesListQuery
    {
        Task<PagedList<ArticleDto>> Execute(ArticleParams articleParams);
    }
}
