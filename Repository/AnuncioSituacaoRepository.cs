using Entity;

namespace Repository
{
    class AnuncioSituacaoRepository : BaseRepository<AnuncioSitucao>
    {
        public new AnuncioSitucao Add(AnuncioSitucao anuncioSituacao)
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
