using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
