using Microsoft.EntityFrameworkCore;
using Office4U.Articles.Data.Ef.SqlServer.Contexts;
using Office4U.Articles.Domain.Model.Entities;
using Office4U.Articles.WriteApplication.Article.Interfaces.IOC;
using System.Threading.Tasks;

namespace Office4U.Articles.Data.Ef.SqlServer.Repositories
{
    public class ArticleRepository : RepositoryBase, IArticleRepository
    {
        public ArticleRepository(DataContext context) : base(context) { }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _context.Articles
                .Include(a => a.Photos)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}