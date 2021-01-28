namespace Office4U.Articles.Data.Ef.SqlServer.Interfaces
{
    public interface IRepositoryBase
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity);
        void Delete<T>(T entity) where T : class;
    }
}
