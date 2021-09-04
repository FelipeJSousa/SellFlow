using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PermissaoRepository : BaseRepository<Permissao>
    {
        public new Permissao Add(Permissao per)
        {
            using (_context = new AppDbContext())
            {
                per.ativo = true;
                _context.Permissao.Add(per);
                _context.SaveChanges();
            }
            Dispose();
            return per;
        }
    }
}
