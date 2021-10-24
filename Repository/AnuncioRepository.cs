using Entity;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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


        public Anuncio Get(long id, long? idUsuario = null)
        {
            var anuncio = new Anuncio();
            using (_context = new AppDbContext())
            {
                Expression<Func<Anuncio, bool>> predicate = PredicateBuilder.New<Anuncio>(true);
                if (idUsuario.HasValue)
                {
                    predicate = predicate.And(x => x.produtoObj.usuario == idUsuario);
                }
                predicate = predicate.And(x => x.id == id && x.ativo);

                anuncio = _context.Anuncio.Where(predicate).Include(x => x.produtoObj).Include(x => x.anuncioSituacaoObj).FirstOrDefault();
            }
            Dispose();
            return anuncio;
        }

        public List<Anuncio> GetAll(long? idUsuario = null)
        {
            List<Anuncio> list = new List<Anuncio>();
            using (_context = new AppDbContext())
            {
                Expression<Func<Anuncio, bool>> predicate = PredicateBuilder.New<Anuncio>(true);
                if (idUsuario.HasValue)
                {
                    predicate = predicate.And(x => x.produtoObj.usuario == idUsuario);
                }
                predicate = predicate.And(x => x.ativo);

                list = _context.Anuncio.Where(predicate).Include(x => x.produtoObj).Include(x => x.anuncioSituacaoObj).ToList();
            }
            Dispose();
            return list;
        }

        public new Anuncio Get(Expression<Func<Anuncio, bool>> lambda)
        {
            Anuncio item = null;
            using (_context = new AppDbContext())
            {
                item = _context.Anuncio
                               .Include(x => x.anuncioSituacaoObj)
                               .Include(x => x.produtoObj)
                               .Where(lambda.Compile()).FirstOrDefault();
            }
            Dispose();
            return item;
        }

        public new List<Anuncio> GetAll()
        {
            List<Anuncio> list = new List<Anuncio>();
            using (_context = new AppDbContext())
            {
                list = _context.Anuncio.Include(x => x.anuncioSituacaoObj).Include(x => x.produtoObj).ToList();
            }
            Dispose();
            return list;
        }
    }
}
