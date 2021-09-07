using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Categoria
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imagemDiretorio { get; set; }
        public bool ativo { get; set; }

    }
}
