using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Produto
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imagemDestaque { get; set; }
        public bool ativo { get; set; }
        private int _curtidas { get; set; } = 0;
        public int curtidas { get => _curtidas; }
        public double valor { get; set; }

        #region ForeignKeys

        public long? usuario { get; set; }
        public long? categoria { get; set; }

        #endregion

        #region Navigation

        public Usuario usuarioObj { get; set; }
        public Categoria categoriaObj { get; set; }
        public ICollection<Anuncio> anuncioList { get; set; }
        public ICollection<Imagens> imagemList { get; set; }

        #endregion

        public void Curtir() => _curtidas++;
    }
}
