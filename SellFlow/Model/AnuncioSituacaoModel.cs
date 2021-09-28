using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellFlow.Model
{
    public class AnuncioSituacaoModel
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }

    }
}
