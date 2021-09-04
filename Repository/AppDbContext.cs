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
        }
    }
}
