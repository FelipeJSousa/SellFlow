using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public new Anuncio Get(Func<Anuncio, bool> lambda)
        {
            Anuncio item = null;
            using (_context = new AppDbContext())
            {
                item = _context.Anuncio
                               .Include(x => x.anuncioSituacaoObj)
                               .Where(lambda).FirstOrDefault();
            }
            Dispose();
            return item;
        }

        public new List<Anuncio> GetAll()
        {
            List<Anuncio> list = new List<Anuncio>();
            using (_context = new AppDbContext())
            {
                list = _context.Anuncio.Include(x => x.anuncioSituacaoObj).ToList();
            }
            Dispose();
            return list;
        }
    }
}
