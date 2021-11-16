using System;

namespace SellFlow.Model.ApiRequest
{
    public class PessoaPostApiRequest
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public long usuario { get; set; }
        public DateTime dataNascimento { get; set; }

    }
}
