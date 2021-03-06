using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SellFlow.Model
{
    public class PessoaModel
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public long? usuario { get; set; }
        public UsuarioModel usuarioObj { get; set; }
        public DateTime? dataNascimento { get; set; }
        public bool? ativo { get; set; }
        public List<EnderecoModel> enderecoList { get; set; }
        //REFATORAR ISSO AQUI
        public string token { get; set; }

    }
}
