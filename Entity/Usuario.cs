using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        private string _senha { get; set; }
        public string senha { get => _senha; set => _senha = value; }
        public string email { get; set; }
        public bool ativo { get; set; }
        public Permissao permissao { get; set; }
        public ICollection<Produto> produtos { get; set; }
    }
}
