using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    interface IBaseRepository<T> where T : class
    {
        T Get(int id);
        List<T> GetAll();
        T Add(T item);
        bool Delete(T item);
        T Edit(T item);
        T Get(Func<T, bool> lambda);
        List<T> GetAll(Func<T, bool> lambda);
    }
}
