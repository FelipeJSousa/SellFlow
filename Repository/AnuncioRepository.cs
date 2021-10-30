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

        public List<Anuncio> GetPorSituacao(long idSituacao)
        {
            var anuncio = new List<Anuncio>();
            using (_context = new AppDbContext())
            {
                Expression<Func<Anuncio, bool>> predicate = PredicateBuilder.New<Anuncio>(true);
                predicate = predicate.And(x => x.anuncioSituacao == idSituacao && x.ativo);

                anuncio = _context.Anuncio.Where(predicate).Include(x => x.produtoObj).ToList();
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

        public new Anuncio Edit(Anuncio obj)
        {
            using (_context = new AppDbContext())
            {
                var original = _context.Anuncio.AsNoTracking().FirstOrDefault(x => x.id == obj.id);
                Anuncio edit = new Anuncio()
                {
                    nome = string.IsNullOrWhiteSpace(obj.nome) ? original.nome : obj.nome,
                    descricao = string.IsNullOrWhiteSpace(obj.descricao) ? original.descricao : obj.descricao,
                    anuncioSituacao = obj.anuncioSituacao is null ? original.anuncioSituacao : obj.anuncioSituacao,
                    dataCriacao = obj.dataCriacao == DateTime.MinValue ? original.dataCriacao : obj.dataCriacao,
                    dataEncerramento = obj.dataEncerramento == DateTime.MinValue ? original.dataEncerramento : obj.dataEncerramento,
                    produto = obj.produto is null ? original.produto : obj.produto,
                    ativo = true,
                    id = obj.id,
                    qtdeDisponivel = obj.qtdeDisponivel,
                    valor = obj.valor
                };
                _context.Entry(edit).State = EntityState.Modified;
                _context.SaveChanges();
                Dispose();
                return edit;
            }
        }
    }
}
