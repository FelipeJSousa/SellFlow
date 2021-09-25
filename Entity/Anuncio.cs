using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Anuncio
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int qtdeDisponivel { get; set; } = 0;
        public string descricao { get; set; }
        public DateTime dataCriacao { get; set; } = DateTime.Now;
        public DateTime dataEncerramento { get; set; }
        public AnuncioSitucao situacao { get; set; }
        public bool ativo { get; set; }
    }
}
