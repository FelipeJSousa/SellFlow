using Microsoft.EntityFrameworkCore;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class BaseRepository<T>
         : IDisposable, IBaseRepository<T> where T : class
    {
        protected AppDbContext _context;

        public T Get(Func<T, bool> lambda)
        {
            T item = null;
            using (_context = new AppDbContext())
            {
                item = _context.Set<T>().Where(lambda).FirstOrDefault();
            }
            Dispose();
            return item;
        }

        public List<T> GetAll(Func<T, bool> lambda)
        {
            List<T> list = new List<T>();
            using (_context = new AppDbContext())
            {
                list = _context.Set<T>().Where(lambda).ToList();
            }
            Dispose();
            return list;
        }

        public T Get(long id)
        {
            T item = null;
            using (_context = new AppDbContext())
            {
                item = _context.Set<T>().Find(id);
            }
            Dispose();
            return item;
        }

        public List<T> GetAll()
        {
            List<T> list = new List<T>();
            using (_context = new AppDbContext())
            {
                list = _context.Set<T>().ToList();
            }
            Dispose();
            return list;
        }

        public virtual T Add(T item)
        {
            using (_context = new AppDbContext())
            {
                _context.Set<T>().Add(item);
                _context.SaveChanges();
            }
            Dispose();
            return item;
        }

        public bool Delete(T item)
        {
            using (_context = new AppDbContext())
            {
                _context.Entry(item).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            Dispose();
            return true;
        }

        public T Edit(T item)
        {
            using (_context = new AppDbContext())
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
            Dispose();
            return item;
        }

        public void Dispose()
        {
            using (_context = new AppDbContext())
            {
                _context.Dispose();
            }
        }

    }
}
