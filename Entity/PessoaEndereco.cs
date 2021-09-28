using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PessoaEndereco
    {
        public long pessoa { get; set; }
        public Pessoa pessoaObj { get; set; }
        public long endereco { get; set; }
        public Endereco enderecoObj { get; set; }
    }
}
