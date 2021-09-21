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
        public DbSet<Pagina> Pagina{ get; set; }
        public DbSet<PermissaoPagina> PermissaoPagina { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<PessoaEndereco> PessoaEndereco { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Anuncio> Anuncio { get; set; }
        public DbSet<Imagens> Imagens { get; set; }
        public DbSet<SituacaoAnuncio> SituacaoAnuncio { get; set; }

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
            modelBuilder.Entity<Pessoa>().Property(x => x.nome).HasMaxLength(50);
            modelBuilder.Entity<Pessoa>().Property(x => x.sobrenome).HasMaxLength(100);
            modelBuilder.Entity<Pessoa>().Property(x => x.cpf).IsRequired();
            modelBuilder.Entity<Pessoa>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Pessoa>().Property(x => x.dataNascimento).IsRequired();
            modelBuilder.Entity<Pessoa>().Property(x => x.nome).IsRequired();
            modelBuilder.Entity<Pessoa>().Property(x => x.sobrenome).IsRequired();
            modelBuilder.Entity<Pessoa>().Property(x => x.ativo).IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.ativo).IsRequired();
            modelBuilder.Entity<Usuario>().Property(x => x.senha).IsRequired();
            modelBuilder.Entity<Usuario>().Property(x => x.id).IsRequired();

            modelBuilder.Entity<Permissao>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Permissao>().Property(x => x.ativo).IsRequired();
            modelBuilder.Entity<Permissao>().Property(x => x.nome).IsRequired();


            modelBuilder.Entity<Pagina>().Property(x => x.ativo).IsRequired();
            modelBuilder.Entity<Pagina>().Property(x => x.caminho).IsRequired();
            modelBuilder.Entity<Pagina>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Pagina>().Property(x => x.nome).IsRequired();

            modelBuilder.Entity<PermissaoPagina>().HasKey(pp => new { pp.permissaoId, pp.paginaId });
            modelBuilder.Entity<PermissaoPagina>()
                        .HasOne(pc => pc.permissao)
                        .WithMany(p => p.PermissaoPagina)
                        .HasForeignKey(pc => pc.permissaoId);
            modelBuilder.Entity<PermissaoPagina>()
                        .HasOne(pc => pc.pagina)
                        .WithMany(p => p.PermissaoPagina)
                        .HasForeignKey(pc => pc.paginaId);

            modelBuilder.Entity<Endereco>().Property(x => x.ativo).IsRequired();
            modelBuilder.Entity<Endereco>().Property(x => x.bairro).IsRequired();
            modelBuilder.Entity<Endereco>().Property(x => x.cidade).IsRequired();
            modelBuilder.Entity<Endereco>().Property(x => x.logradouro).IsRequired();
            modelBuilder.Entity<Endereco>().Property(x => x.id).IsRequired();

            modelBuilder.Entity<PessoaEndereco>().HasKey(pe => new { pe.pessoaId, pe.enderecoId }); ;
            modelBuilder.Entity<PessoaEndereco>()
                        .HasOne(pe => pe.pessoa)
                        .WithMany(p => p.pessoaEnderecos)
                        .HasForeignKey(pc => pc.pessoaId);
            modelBuilder.Entity<PessoaEndereco>()
                        .HasOne(pe => pe.endereco)
                        .WithMany(e => e.pessoaEnderecos)
                        .HasForeignKey(pe => pe.enderecoId);

            modelBuilder.Entity<Categoria>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Categoria>().Property(x => x.ativo).IsRequired();
            modelBuilder.Entity<Categoria>().Property(x => x.nome).IsRequired();
            modelBuilder.Entity<Categoria>().Property(x => x.nome).HasMaxLength(80);
            modelBuilder.Entity<Categoria>().Property(x => x.descricao).HasMaxLength(250);

            modelBuilder.Entity<Anuncio>().Property(x => x.descricao).HasMaxLength(250);
            modelBuilder.Entity<Anuncio>().Property(x => x.nome).HasMaxLength(80);
            modelBuilder.Entity<Anuncio>().Property(x => x.ativo).IsRequired();
            modelBuilder.Entity<Anuncio>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Anuncio>().Property(x => x.nome).IsRequired();
            modelBuilder.Entity<Anuncio>().Property(x => x.qtdeDisponivel).IsRequired();
            modelBuilder.Entity<Anuncio>().Property(x => x.dataCriacao).IsRequired();

            modelBuilder.Entity<Imagens>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<Imagens>().Property(x => x.diretorio).IsRequired();
            modelBuilder.Entity<Imagens>().Property(x => x.ativo).IsRequired();

            modelBuilder.Entity<SituacaoAnuncio>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<SituacaoAnuncio>().Property(x => x.nome).IsRequired();
            modelBuilder.Entity<SituacaoAnuncio>().Property(x => x.nome).HasMaxLength(50);
            modelBuilder.Entity<SituacaoAnuncio>().Property(x => x.descricao).HasMaxLength(250);
            modelBuilder.Entity<SituacaoAnuncio>().Property(x => x.ativo).IsRequired();

        }
    }
}
