using System.Collections.Generic;

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
