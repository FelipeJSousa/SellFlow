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
        protected readonly String _conn = @"Server=DESKTOP-4QBF915;Database=WebAd;Trusted_Connection=True;MultipleActiveResultSets=true";
        public DbSet<Pessoa> Pessoa { get; set; }

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
        }
    }
}
