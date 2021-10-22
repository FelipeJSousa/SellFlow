namespace SellFlow.Model
{
    public class ProdutoModel
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imagemDestaque { get; set; }
        public bool? ativo { get; set; }
        private int _curtidas { get; set; } = 0;
        public int? curtidas { get => _curtidas; }

        public long categoria { get; set; }
        public long usuario { get; set; }
        public UsuarioModel usuarioObj { get; set; }
        public CategoriaModel categoriaObj { get; set; }
        public void Curtir() => _curtidas++;
    }
}
