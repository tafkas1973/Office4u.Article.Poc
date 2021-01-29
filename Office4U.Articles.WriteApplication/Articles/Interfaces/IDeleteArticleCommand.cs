using System.Threading.Tasks;

namespace Office4U.Articles.WriteApplication.Article.Interfaces
{
    public interface IDeleteArticleCommand
    {
        Task Execute(int id);
    }
}
