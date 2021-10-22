using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProdutoRepository : BaseRepository<Produto>
    {
        public new Produto Add(Produto pro)
        {
            using (_context = new AppDbContext())
            {
                pro.ativo = true;
                _context.Produto.Add(pro);
                _context.SaveChanges();
            }
            Dispose();
            return pro;
        }

        public new Produto Get(long id)
        {
            var pro = new Produto();
            using (_context = new AppDbContext())
            {
               pro = _context.Produto.Where(x => x.id == id && x.ativo).Include(x => x.categoriaObj).Include(x => x.usuarioObj).FirstOrDefault();
            }
            Dispose();
            return pro;
        }

        public new Produto Get(Expression<Func<Produto, bool>> lambda)
        {
            var pro = new Produto();
            using (_context = new AppDbContext())
            {
               pro = _context.Produto.Where(lambda).Include(x => x.categoriaObj).Include(x => x.usuarioObj).FirstOrDefault();
            }
            Dispose();
            return pro;
        }

        public new List<Produto> GetAll()
        {
            var pro = new List<Produto>();
            using (_context = new AppDbContext())
            {
               pro = _context.Produto.Where(x => x.ativo).Include(x => x.categoriaObj).Include(x => x.usuarioObj).ToList();
            }
            Dispose();
            return pro;
        }
    }
}
