using Office4U.Articles.WriteApplication.Article.DTOs;
using System.Threading.Tasks;

namespace Office4U.Articles.WriteApplication.Article.Interfaces
{
    public interface IUpdateArticleCommand
    {
        Task Execute(ArticleForUpdateDto article);
    }
}
