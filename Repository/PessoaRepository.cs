using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class PessoaRepository : BaseRepository<Pessoa>
    {
        public new Pessoa Add(Pessoa pes)
        {
            using (_context = new AppDbContext())
            {
                pes.ativo = true;
                _context.Pessoa.Add(pes);
                _context.SaveChanges();
            }
            Dispose();
            return pes;
        }

        public Pessoa GetPorUsuario(long idUsuario)
        {
            using (_context = new AppDbContext())
            {
                return _context.Pessoa.Include(x => x.usuarioObj).Include(x => x.enderecoList).FirstOrDefault(x => x.Usuario.Equals(idUsuario));
            }
        }


        public new Pessoa Get(long id)
        {
            using (_context = new AppDbContext())
            {
                return _context.Pessoa.Include(x => x.usuarioObj).Include(x => x.enderecoList).FirstOrDefault(x=> x.id.Equals(id));
            }
        }

        public new Pessoa Get(Expression<Func<Pessoa, bool>> lambda)
        {
            using (_context = new AppDbContext())
            {
                return _context.Pessoa.Where(lambda).Include(x => x.usuarioObj).Include(x => x.enderecoList).FirstOrDefault();
            }
        }

        public new List<Pessoa> GetAll()
        {
            using (_context = new AppDbContext())
            {
                return _context.Pessoa.Include(x => x.usuarioObj).Include(x => x.enderecoList).ToList();
            }
        }

    }
}
