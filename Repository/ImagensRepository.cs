using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ImagensRepository : BaseRepository<Imagens>
    {
        public new Imagens Add(Imagens img)
        {
            using (_context = new AppDbContext())
            {
                img.ativo = true;
                _context.Imagens.Add(img);
                _context.SaveChanges();
            }
            Dispose();
            return img;
        }
    }
}
