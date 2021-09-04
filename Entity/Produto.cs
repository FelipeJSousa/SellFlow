using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imagemDestaque { get; set; }
        public Usuario vendedor { get; set; }
        public bool ativo { get; set; }
        private int _curtidas { get; set; } = 0;
        public int curtidas { get => _curtidas; }

        public void Curtir() => _curtidas++;
    }
}
