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
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }

        public ICollection<PermissaoPagina> PermissaoPagina { get; set; }
    }
}
