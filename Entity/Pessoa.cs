using System;
using System.Collections.Generic;

namespace Entity
{
    public class Pessoa
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public string cpnj { get; set; }
        public DateTime dataNascimento { get; set; }
        public bool ativo { get; set; }

        #region ForeignKey

        public long? usuario { get; set; }

        #endregion
        #region Navigation

        public Usuario usuarioObj { get; set; }

        public ICollection<Endereco> enderecoList { get; set; }

        #endregion
    }
}
