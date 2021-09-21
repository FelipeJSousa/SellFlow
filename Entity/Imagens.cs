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
        [Key]
        public int id { get; set; }
        public string diretorio { get; set; }
        public Produto produto { get; set; }
        public bool ativo { get; set; }
    }
}
