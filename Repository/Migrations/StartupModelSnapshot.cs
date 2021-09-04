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

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.HasOne("Entity.Permissao", "permissao")
                        .WithMany()
                        .HasForeignKey("permissaoid");

                    b.Navigation("permissao");
                });

            modelBuilder.Entity("Entity.Pagina", b =>
                {
                    b.Navigation("PermissaoPagina");
                });

            modelBuilder.Entity("Entity.Permissao", b =>
                {
                    b.Navigation("PermissaoPagina");
                });
#pragma warning restore 612, 618
        }
    }
}
