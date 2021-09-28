using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pagina
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string caminho { get; set; }
        public bool ativo { get; set; }

        #region ForeignKeys

        public long? PermissaoPagina { get; set; }

        #endregion
        #region Navigation

        public ICollection<PermissaoPagina> PermissaoPaginaObj { get; set; }

        #endregion
    }
}
