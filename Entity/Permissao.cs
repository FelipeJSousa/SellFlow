using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Permissao
    {
        public long id { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }

        #region Navigation

        public ICollection<PermissaoPagina> PermissaoPaginaObj { get; set; }

        #endregion
    }
}
