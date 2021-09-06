using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PessoaEndereco
    {
        public int pessoaId { get; set; }
        public Pessoa pessoa { get; set; }
        public int enderecoId { get; set; }
        public Endereco endereco { get; set; }
    }
}
