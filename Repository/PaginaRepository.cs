using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PaginaRepository : BaseRepository<Pagina>
    {
        public new Pagina Add(Pagina pag)
        {
            using (_context = new AppDbContext())
            {
                pag.ativo = true;
                _context.Pagina.Add(pag);
                _context.SaveChanges();
            }
            Dispose();
            return pag;
        }
    }
}
