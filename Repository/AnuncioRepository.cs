using Entity;
using System;
using System.Linq.Expressions;
using Entity;
using Microsoft.EntityFrameworkCore;

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
