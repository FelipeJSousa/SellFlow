using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository
{
    interface IBaseRepository<T> where T : class
    {
        T Get(long id);
        List<T> GetAll();
        T Add(T item);
        bool Delete(T item);
        T Edit(T item);
        T Get(Expression<Func<T, bool>> lambda);
        List<T> GetAll(Expression<Func<T, bool>> lambda);
    }
}
