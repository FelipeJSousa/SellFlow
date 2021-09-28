using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Endereco
    {
        public long id { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public bool ativo { get; set; }

        #region Navigation

        public ICollection<PessoaEndereco> pessoaEnderecoObj { get; set; } 

        #endregion

    }
}
