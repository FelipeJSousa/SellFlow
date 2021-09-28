using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{

    public class AnuncioSitucao
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }

        //public ICollection<Anuncio> anuncios { get; set; }

    }
}
