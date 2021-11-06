﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Anuncio", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("anuncioSituacao")
                        .HasColumnType("bigint");

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("dataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataEncerramento")
                        .HasColumnType("datetime2");

                    b.Property<string>("descricao")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<long?>("produto")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<int>("qtdeDisponivel")
                        .HasColumnType("int");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("anuncioSituacao");

                    b.HasIndex("produto");

                    b.ToTable("Anuncio");
                });

            modelBuilder.Entity("Entity.AnuncioSituacao", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("descricao")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("AnuncioSitucao");
                });

            modelBuilder.Entity("Entity.Categoria", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("descricao")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("imagemDiretorio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Entity.Endereco", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("pessoa")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("pessoa");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Entity.Imagens", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("diretorio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("produto")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("produto");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("Entity.Pagina", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("caminho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Pagina");
                });

            modelBuilder.Entity("Entity.Permissao", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Permissao");
                });

            modelBuilder.Entity("Entity.PermissaoPagina", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("pagina")
                        .HasColumnType("bigint");

                    b.Property<long>("permissao")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("pagina");

                    b.HasIndex("permissao");

                    b.ToTable("PermissaoPagina");
                });

            modelBuilder.Entity("Entity.Pessoa", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpnj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("usuario")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("usuario")
                        .IsUnique();

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("Entity.Produto", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<long?>("categoria")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("imagemDestaque")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("usuario")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("categoria");

                    b.HasIndex("usuario");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("permissao")
                        .HasColumnType("bigint");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("permissao");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Entity.Anuncio", b =>
                {
                    b.HasOne("Entity.AnuncioSituacao", "anuncioSituacaoObj")
                        .WithMany()
                        .HasForeignKey("anuncioSituacao");

                    b.HasOne("Entity.Produto", "produtoObj")
                        .WithMany("anuncioList")
                        .HasForeignKey("produto")
                        .IsRequired();

                    b.Navigation("anuncioSituacaoObj");

                    b.Navigation("produtoObj");
                });

            modelBuilder.Entity("Entity.Endereco", b =>
                {
                    b.HasOne("Entity.Pessoa", "pessoaObj")
                        .WithMany("enderecoList")
                        .HasForeignKey("pessoa")
                        .IsRequired();

                    b.Navigation("pessoaObj");
                });

            modelBuilder.Entity("Entity.Imagens", b =>
                {
                    b.HasOne("Entity.Produto", "produtoObj")
                        .WithMany("imagemList")
                        .HasForeignKey("produto");

                    b.Navigation("produtoObj");
                });

            modelBuilder.Entity("Entity.PermissaoPagina", b =>
                {
                    b.HasOne("Entity.Pagina", "paginaObj")
                        .WithMany("PermissaoPaginaObj")
                        .HasForeignKey("pagina");

                    b.HasOne("Entity.Permissao", "permissaoObj")
                        .WithMany("PermissaoPaginaObj")
                        .HasForeignKey("permissao");

                    b.Navigation("paginaObj");

                    b.Navigation("permissaoObj");
                });

            modelBuilder.Entity("Entity.Pessoa", b =>
                {
                    b.HasOne("Entity.Usuario", "usuarioObj")
                        .WithOne()
                        .HasForeignKey("Entity.Pessoa", "usuario")
                        .IsRequired();

                    b.Navigation("usuarioObj");
                });

            modelBuilder.Entity("Entity.Produto", b =>
                {
                    b.HasOne("Entity.Categoria", "categoriaObj")
                        .WithMany()
                        .HasForeignKey("categoria")
                        .IsRequired();

                    b.HasOne("Entity.Usuario", "usuarioObj")
                        .WithMany()
                        .HasForeignKey("usuario")
                        .IsRequired();

                    b.Navigation("categoriaObj");

                    b.Navigation("usuarioObj");
                });

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.HasOne("Entity.Permissao", "permissaoObj")
                        .WithMany()
                        .HasForeignKey("permissao")
                        .IsRequired();

                    b.Navigation("permissaoObj");
                });

            modelBuilder.Entity("Entity.Pagina", b =>
                {
                    b.Navigation("PermissaoPaginaObj");
                });

            modelBuilder.Entity("Entity.Permissao", b =>
                {
                    b.Navigation("PermissaoPaginaObj");
                });

            modelBuilder.Entity("Entity.Pessoa", b =>
                {
                    b.Navigation("enderecoList");
                });

            modelBuilder.Entity("Entity.Produto", b =>
                {
                    b.Navigation("anuncioList");

                    b.Navigation("imagemList");
                });
#pragma warning restore 612, 618
        }
    }
}
