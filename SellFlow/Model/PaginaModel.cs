using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellFlow.Model
{
    public class PaginaModel
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string caminho { get; set; }
        public bool ativo { get; set; }
    }
}
