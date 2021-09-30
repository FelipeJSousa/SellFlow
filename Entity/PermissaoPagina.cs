using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PermissaoPagina
    {
        public long id { get; set; }
        public long permissao { get; set; }
        public Permissao permissaoObj { get; set; }
        public long pagina { get; set; }
        public Pagina paginaObj { get; set; }
    }
}
