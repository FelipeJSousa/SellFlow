using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellFlow.Model
{
    public class UsuarioModel
    {
        public long id { get; set; }
        private string _senha { get; set; }
        public string senha { get => _senha; set => _senha = value; }
        public string email { get; set; }
        public bool ativo { get; set; }
        public long permissao { get; set; }
    }
}
