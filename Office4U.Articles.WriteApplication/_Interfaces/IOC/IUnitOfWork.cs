using Office4U.Articles.WriteApplication.Article.Interfaces.IOC;
using Office4U.Articles.WriteApplication.User.Interfaces;
using System.Threading.Tasks;

namespace Office4U.Articles.WriteApplication.Interfaces.IOC
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IArticleRepository ArticleRepository { get; }
        Task<bool> Commit();
        bool HasChanges();
    }
}