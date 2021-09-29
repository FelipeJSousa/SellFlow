using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Imagens
    {
        public long id { get; set; }
        public string diretorio { get; set; }
        public bool ativo { get; set; }

        #region ForeignKey

        public long produto { get; set; }

        #endregion
        #region Navigation

        public Produto produtoObj { get; set; } 

        #endregion
    }
}
