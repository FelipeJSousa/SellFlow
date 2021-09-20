﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace SellFlow.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class StartupModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Anuncio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Produtoid")
                        .HasColumnType("int");

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

                    b.Property<int>("qtdeDisponivel")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Produtoid");

                    b.ToTable("Anuncio");
                });

            modelBuilder.Entity("Entity.Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Entity.Imagens", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("diretorio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("produtoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("produtoid");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("Entity.Pagina", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Permissao");
                });

            modelBuilder.Entity("Entity.PermissaoPagina", b =>
                {
                    b.Property<int>("permissaoId")
                        .HasColumnType("int");

                    b.Property<int>("paginaId")
                        .HasColumnType("int");

                    b.HasKey("permissaoId", "paginaId");

                    b.HasIndex("paginaId");

                    b.ToTable("PermissaoPagina");
                });

            modelBuilder.Entity("Entity.Pessoa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
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

                    b.Property<int?>("usuarioid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("usuarioid");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("Entity.PessoaEndereco", b =>
                {
                    b.Property<int>("pessoaId")
                        .HasColumnType("int");

                    b.Property<int>("enderecoId")
                        .HasColumnType("int");

                    b.HasKey("pessoaId", "enderecoId");

                    b.HasIndex("enderecoId");

                    b.ToTable("PessoaEndereco");
                });

            modelBuilder.Entity("Entity.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<int?>("categoriaid")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagemDestaque")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("vendedorid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("categoriaid");

                    b.HasIndex("vendedorid");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("permissaoid")
                        .HasColumnType("int");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("permissaoid");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Entity.Anuncio", b =>
                {
                    b.HasOne("Entity.Produto", null)
                        .WithMany("anuncios")
                        .HasForeignKey("Produtoid");
                });

            modelBuilder.Entity("Entity.Imagens", b =>
                {
                    b.HasOne("Entity.Produto", "produto")
                        .WithMany("imagens")
                        .HasForeignKey("produtoid");

                    b.Navigation("produto");
                });

            modelBuilder.Entity("Entity.PermissaoPagina", b =>
                {
                    b.HasOne("Entity.Pagina", "pagina")
                        .WithMany("PermissaoPagina")
                        .HasForeignKey("paginaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Permissao", "permissao")
                        .WithMany("PermissaoPagina")
                        .HasForeignKey("permissaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pagina");

                    b.Navigation("permissao");
                });

            modelBuilder.Entity("Entity.Pessoa", b =>
                {
                    b.HasOne("Entity.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioid");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Entity.PessoaEndereco", b =>
                {
                    b.HasOne("Entity.Endereco", "endereco")
                        .WithMany("pessoaEnderecos")
                        .HasForeignKey("enderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Pessoa", "pessoa")
                        .WithMany("pessoaEnderecos")
                        .HasForeignKey("pessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("endereco");

                    b.Navigation("pessoa");
                });

            modelBuilder.Entity("Entity.Produto", b =>
                {
                    b.HasOne("Entity.Categoria", "categoria")
                        .WithMany()
                        .HasForeignKey("categoriaid");

                    b.HasOne("Entity.Usuario", "vendedor")
                        .WithMany("produtos")
                        .HasForeignKey("vendedorid");

                    b.Navigation("categoria");

                    b.Navigation("vendedor");
                });

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.HasOne("Entity.Permissao", "permissao")
                        .WithMany()
                        .HasForeignKey("permissaoid");

                    b.Navigation("permissao");
                });

            modelBuilder.Entity("Entity.Endereco", b =>
                {
                    b.Navigation("pessoaEnderecos");
                });

            modelBuilder.Entity("Entity.Pagina", b =>
                {
                    b.Navigation("PermissaoPagina");
                });

            modelBuilder.Entity("Entity.Permissao", b =>
                {
                    b.Navigation("PermissaoPagina");
                });

            modelBuilder.Entity("Entity.Pessoa", b =>
                {
                    b.Navigation("pessoaEnderecos");
                });

            modelBuilder.Entity("Entity.Produto", b =>
                {
                    b.Navigation("anuncios");

                    b.Navigation("imagens");
                });

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.Navigation("produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
