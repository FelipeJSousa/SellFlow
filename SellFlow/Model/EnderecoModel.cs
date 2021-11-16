using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellFlow.Model
{
    public class EnderecoModel
    {
        public long id { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string cep { get; set; }
        public string estado { get; set; }
        public bool ativo { get; set; }
        public long? pessoa { get; set; }
    }
}
