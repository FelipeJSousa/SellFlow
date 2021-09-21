using System;
using System.Runtime.Serialization;

namespace SellFlow.Model
{
    public class PessoaModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public UsuarioModel usuario { get; set; }
        public DateTime dataNascimento { get; set; }
        public bool ativo { get; set; }
        
    }
}
