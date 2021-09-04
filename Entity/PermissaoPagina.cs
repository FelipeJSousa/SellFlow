using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PermissaoPagina
    {
        public int permissaoId { get; set; }
        public Permissao permissao { get; set; }
        public int paginaId { get; set; }
        public Pagina pagina { get; set; }
    }
}
