using Entity;
using LinqKit;
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

        public Produto Get(long id, long? idUsuario = null)
        {
            var pro = new Produto();
            using (_context = new AppDbContext())
            {
                Expression<Func<Produto, bool>> predicate = PredicateBuilder.New<Produto>(true);
                if (idUsuario.HasValue)
                {
                    predicate = predicate.And(x => x.usuario == idUsuario);
                }
                predicate = predicate.And(x => x.id == id && x.ativo);

                pro = _context.Produto.Where(predicate).Include(x => x.categoriaObj).Include(x => x.usuarioObj).FirstOrDefault();
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

        public List<Produto> GetAll(int? idUsuario = null)
        {
            var pro = new List<Produto>();
            using (_context = new AppDbContext())
            {
                Expression<Func<Produto, bool>> predicate = PredicateBuilder.New<Produto>(true);
                if (idUsuario.HasValue)
                {
                    predicate = predicate.And(x => x.usuario == idUsuario);
                }
                predicate = predicate.And(x => x.ativo);

                pro = _context.Produto.Where(predicate).Include(x => x.categoriaObj).Include(x => x.usuarioObj).ToList();
            }
            Dispose();
            return pro;
        }

    }
}
