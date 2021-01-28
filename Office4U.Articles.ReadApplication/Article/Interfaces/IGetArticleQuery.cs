using Office4U.Articles.ReadApplication.Article.DTOs;
using System.Threading.Tasks;

namespace Office4U.Articles.ReadApplication.Article.Interfaces
{
    public interface IGetArticleQuery
    {
        Task<ArticleDto> Execute(int id);
    }
}
