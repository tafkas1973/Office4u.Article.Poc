
using Office4U.Articles.Data.Ef.SqlServer.Contexts;

namespace Office4U.Articles.Data.Ef.SqlServer.Repositories
{
    public class ReadOnlyRepositoryBase
    {
        protected readonly ReadOnlyDataContext _readOnlyContext;
        public ReadOnlyRepositoryBase(ReadOnlyDataContext readOnlyContext)
        {
            _readOnlyContext = readOnlyContext;
        }
    }
}