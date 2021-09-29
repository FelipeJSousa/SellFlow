using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class AppDbContext : DbContext
    {
        protected readonly String _conn = @"Server=DESKTOP-4QBF915;Database=SellFlow;Trusted_Connection=True;MultipleActiveResultSets=true";
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Pagina> Pagina { get; set; }
        public DbSet<PermissaoPagina> PermissaoPagina { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Anuncio> Anuncio { get; set; }
        public DbSet<AnuncioSitucao> AnuncioSitucao { get; set; }
        public DbSet<Imagens> Imagens { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Anuncio

            modelBuilder.Entity<Anuncio>().HasOne(x => x.anuncioSituacaoObj).WithOne().HasForeignKey<Anuncio>(x => x.anuncioSituacao).IsRequired(false);

            modelBuilder.Entity<Anuncio>().Property(x => x.descricao).HasMaxLength(250);
            modelBuilder.Entity<Anuncio>().Property(x => x.nome).HasMaxLength(80);
            modelBuilder.Entity<Anuncio>().Property(x => x.ativo).IsRequired();
            modelBuilder.Entity<Anuncio>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Anuncio>().Property(x => x.nome).IsRequired();
            modelBuilder.Entity<Anuncio>().Property(x => x.qtdeDisponivel).IsRequired();
            modelBuilder.Entity<Anuncio>().Property(x => x.dataCriacao).IsRequired();

            #endregion

            #region AnuncioSituacao

            modelBuilder.Entity<AnuncioSitucao>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<AnuncioSitucao>().Property(x => x.nome).IsRequired();
            modelBuilder.Entity<AnuncioSitucao>().Property(x => x.nome).HasMaxLength(50);
            modelBuilder.Entity<AnuncioSitucao>().Property(x => x.descricao).HasMaxLength(250);
            modelBuilder.Entity<AnuncioSitucao>().Property(x => x.ativo).IsRequired();

            #endregion

            #region Categoria

            modelBuilder.Entity<Categoria>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Categoria>().Property(x => x.ativo).IsRequired();
            modelBuilder.Entity<Categoria>().Property(x => x.nome).IsRequired();
            modelBuilder.Entity<Categoria>().Property(x => x.nome).HasMaxLength(80);
            modelBuilder.Entity<Categoria>().Property(x => x.descricao).HasMaxLength(250);

            #endregion

            #region Endereco

            modelBuilder.Entity<Endereco>().HasOne(x => x.pessoaObj).WithOne().HasForeignKey<Endereco>(x => x.pessoa).IsRequired(false);

            modelBuilder.Entity<Endereco>().Property(x => x.ativo).IsRequired();
            modelBuilder.Entity<Endereco>().Property(x => x.bairro).IsRequired();
            modelBuilder.Entity<Endereco>().Property(x => x.cidade).IsRequired();
            modelBuilder.Entity<Endereco>().Property(x => x.logradouro).IsRequired();
            modelBuilder.Entity<Endereco>().Property(x => x.id).IsRequired();

            #endregion

            #region Imagens

            modelBuilder.Entity<Imagens>().HasOne(x => x.produtoObj).WithOne().HasForeignKey<Imagens>(x => x.produto).IsRequired();

            modelBuilder.Entity<Imagens>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Imagens>().Property(x => x.diretorio).IsRequired();
            modelBuilder.Entity<Imagens>().Property(x => x.ativo).IsRequired();

            #endregion

            #region Pagina

            modelBuilder.Entity<Pagina>().HasMany(x => x.PermissaoPaginaObj).WithOne(x => x.paginaObj).HasForeignKey(x => x.pagina).IsRequired(false);

            modelBuilder.Entity<Pagina>().Property(x => x.ativo).IsRequired();
            modelBuilder.Entity<Pagina>().Property(x => x.caminho).IsRequired();
            modelBuilder.Entity<Pagina>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Pagina>().Property(x => x.nome).IsRequired();

            #endregion

            #region Pessoa

            modelBuilder.Entity<Pessoa>().HasOne(x => x.usuarioObj).WithOne().HasForeignKey<Pessoa>(x => x.Usuario).IsRequired();

            modelBuilder.Entity<Pessoa>().Property(x => x.nome).HasMaxLength(50);
            modelBuilder.Entity<Pessoa>().Property(x => x.sobrenome).HasMaxLength(100);
            modelBuilder.Entity<Pessoa>().Property(x => x.cpf).IsRequired();
            modelBuilder.Entity<Pessoa>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Pessoa>().Property(x => x.dataNascimento).IsRequired();
            modelBuilder.Entity<Pessoa>().Property(x => x.nome).IsRequired();
            modelBuilder.Entity<Pessoa>().Property(x => x.sobrenome).IsRequired();
            modelBuilder.Entity<Pessoa>().Property(x => x.ativo).IsRequired();

            #endregion

            #region Permissao

            modelBuilder.Entity<Permissao>().HasMany(x => x.PermissaoPaginaObj).WithOne(x => x.permissaoObj).HasForeignKey(x => x.permissao).IsRequired(false);

            modelBuilder.Entity<Permissao>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Permissao>().Property(x => x.ativo).IsRequired();
            modelBuilder.Entity<Permissao>().Property(x => x.nome).IsRequired();
            modelBuilder.Entity<Permissao>().Property(x => x.nome).HasMaxLength(50); 
            #endregion

            #region PermissaoPagina
            modelBuilder.Entity<PermissaoPagina>().HasKey(pp => new { pp.permissao, pp.pagina });
            modelBuilder.Entity<PermissaoPagina>()
                        .HasOne(pc => pc.permissaoObj)
                        .WithMany(p => p.PermissaoPaginaObj)
                        .HasForeignKey(pc => pc.permissao);
            modelBuilder.Entity<PermissaoPagina>()
                        .HasOne(pc => pc.paginaObj)
                        .WithMany(p => p.PermissaoPaginaObj)
                        .HasForeignKey(pc => pc.pagina);
            #endregion

            #region Produto

            modelBuilder.Entity<Produto>().HasOne(x => x.categoriaObj).WithMany().HasForeignKey(x => x.categoria).IsRequired().OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Produto>().HasOne(x => x.usuarioObj).WithMany().HasForeignKey(x => x.usuario).IsRequired().OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Produto>().HasMany(x => x.anuncioList).WithOne(x => x.produtoObj).HasForeignKey(x => x.produto).IsRequired();
            modelBuilder.Entity<Produto>().HasMany(x => x.imagemList).WithOne(x => x.produtoObj).HasForeignKey(x => x.produto).IsRequired(false);

            modelBuilder.Entity<Produto>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Produto>().Property(x => x.nome).IsRequired();
            modelBuilder.Entity<Produto>().Property(x => x.nome).HasMaxLength(50);
            modelBuilder.Entity<Produto>().Property(x => x.descricao).IsRequired();
            modelBuilder.Entity<Produto>().Property(x => x.descricao).HasMaxLength(250);
            modelBuilder.Entity<Produto>().Property(x => x.ativo).IsRequired();

            #endregion

            #region Usuario

            modelBuilder.Entity<Usuario>().HasOne(x => x.permissaoObj).WithOne().HasForeignKey<Usuario>(x => x.permissao).IsRequired().OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Usuario>().Property(x => x.ativo).IsRequired();
            modelBuilder.Entity<Usuario>().Property(x => x.senha).IsRequired();
            modelBuilder.Entity<Usuario>().Property(x => x.id).IsRequired();

            #endregion

        }
    }
}
