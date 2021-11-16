using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Usuario
    {
        [Key]
        public long id { get; set; }
        private string _senha { get; set; }
        public string senha { get => _senha; set => _senha = value; }
        public string email { get; set; }
        public bool ativo { get; set; }

        #region ForeignKeys

        public long permissao { get; set; }

        #endregion

        #region Navigation

        public Permissao permissaoObj { get; set; }

        #endregion
    }
}
