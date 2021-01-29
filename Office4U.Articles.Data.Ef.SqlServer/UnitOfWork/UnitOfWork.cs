using Office4U.Articles.Data.Ef.SqlServer.Contexts;
using Office4U.Articles.Data.Ef.SqlServer.Repositories;
using Office4U.Articles.WriteApplication.Article.Interfaces.IOC;
using Office4U.Articles.WriteApplication.Interfaces.IOC;
using Office4U.Articles.WriteApplication.User.Interfaces;
using System.Threading.Tasks;

namespace Office4U.Articles.Data.Ef.SqlServer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
            ArticleRepository = new ArticleRepository(_context);
            UserRepository = new UserRepository(_context);
        }

        public IArticleRepository ArticleRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }


        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
