using System.Collections.Generic;

namespace SellFlow.Model.ApiRequest
{
    public class ApiRequestPermissaoPagina
    {
        public List<PermissaoPaginaModel> pagina { get; set; }
        public List<PermissaoPaginaModel> permissao { get; set; }
    }
}
