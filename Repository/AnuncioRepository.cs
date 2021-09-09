using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AnuncioRepository : BaseRepository<Anuncio>
    {
        public new Anuncio Add(Anuncio anuncio)
        {
            using (_context = new AppDbContext())
            {
                anuncio.ativo = true;
                _context.Anuncio.Add(anuncio);
                _context.SaveChanges();
            }
            Dispose();
            return anuncio;
        }
    }
}
