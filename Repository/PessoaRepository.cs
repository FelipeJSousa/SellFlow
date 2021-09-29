using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        public new Pessoa Get(int id)
        {
            using (_context = new AppDbContext())
            {
                return _context.Pessoa.Include("usuario").FirstOrDefault(x=> x.id.Equals(id));
            }
        }
        public new List<Pessoa> GetAll()
        {
            using (_context = new AppDbContext())
            {
                return _context.Pessoa.Include("usuario").ToList();
            }
        }
    }
}
