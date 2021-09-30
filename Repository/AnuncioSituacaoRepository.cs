using Entity;

namespace Repository
{
    public class AnuncioSituacaoRepository : BaseRepository<AnuncioSituacao>
    {
        public new AnuncioSituacao Add(AnuncioSituacao anuncioSituacao)
        {
            using (_context = new AppDbContext())
            {
                anuncioSituacao.ativo = true;
                _context.AnuncioSitucao.Add(anuncioSituacao);
                _context.SaveChanges();
            }
            Dispose();
            return anuncioSituacao;
        }
    }
}
