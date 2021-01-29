﻿using System.Threading.Tasks;

namespace Office4U.Articles.WriteApplication.Interfaces.IOC
{
    public interface IRepositoryBase
    {        
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity);
        void Delete<T>(T entity) where T : class;
    }
}
