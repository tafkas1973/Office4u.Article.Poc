using System.Threading.Tasks;

namespace Office4U.Articles.Data.Ef.SqlServer.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IArticleRepository ArticleRepository { get; }
        Task<bool> Commit();
        bool HasChanges();
    }
}