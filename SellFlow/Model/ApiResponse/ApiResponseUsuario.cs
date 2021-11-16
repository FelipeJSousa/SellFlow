
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellFlow.Model.ApiResponse
{
    public class ApiResponseUsuario
    {
        public long? id { get; set; }
        public string email { get; set; }
        public bool? ativo { get; set; }
        public long? permissao { get; set; }
    }
}
