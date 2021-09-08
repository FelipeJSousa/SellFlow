using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoriaRepository : BaseRepository<Categoria>
    {
        public new Categoria Add(Categoria cat)
        {
            using (_context = new AppDbContext())
            {
                cat.ativo = true;
                _context.Categoria.Add(cat);
                _context.SaveChanges();
            }
            Dispose();
            return cat;
        }
    }
}
