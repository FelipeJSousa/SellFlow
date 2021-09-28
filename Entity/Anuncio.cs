using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Anuncio
    {
        public long id       { get; set; }
        public string nome { get; set; }
        public int qtdeDisponivel { get; set; } = 0;
        public string descricao { get; set; }
        public DateTime dataCriacao { get; set; } = DateTime.Now;
        public DateTime dataEncerramento { get; set; }
        public bool ativo { get; set; }

        #region Foreign

        public long? produto { get; set; }
        public long? anuncioSituacao { get; set; }

        #endregion
        #region Navigation

        public Produto produtoObj { get; set; }
        public AnuncioSitucao anuncioSituacaoObj { get; set; }

        #endregion
        #region Regra De Negócio

        public void NovoAnuncio()
        {
            anuncioSituacao = 1;
        }

        #endregion

    }
}
