using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>
    {
        public new Endereco Add(Endereco end)
        {
            using (_context = new AppDbContext())
            {
                end.ativo = true;
                _context.Endereco.Add(end);
                _context.SaveChanges();
            }
            Dispose();
            return end;
        }
    }
}
