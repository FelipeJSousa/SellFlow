using Entity;
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
    }
}
