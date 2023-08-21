﻿// <auto-generated />
using System;
using Cinema.Dados.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cinema.Dados.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230821142733_CriacaoDeCliente")]
    partial class CriacaoDeCliente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cinema.Dominio.Entities.Cliente.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("datetime")
                        .HasColumnName("data_de_nascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Cinema.Dominio.Entities.Filmes.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassificacaoString")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("classificacao");

                    b.Property<string>("DataDeLancamento")
                        .IsRequired()
                        .HasColumnType("varchar(4)")
                        .HasColumnName("data_de_lancamento");

                    b.Property<int>("Duracao")
                        .HasColumnType("int")
                        .HasColumnName("duracao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<int>("genero_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("genero_id");

                    b.ToTable("Filme", (string)null);
                });

            modelBuilder.Entity("Cinema.Dominio.Entities.Generos.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Genero", (string)null);
                });

            modelBuilder.Entity("Cinema.Dominio.Entities.Salas.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("int")
                        .HasColumnName("capacidade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome");

                    b.Property<bool>("Sala3D")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("sala_3d");

                    b.Property<bool>("SalaVip")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("sala_vip");

                    b.HasKey("Id");

                    b.ToTable("Sala", (string)null);
                });

            modelBuilder.Entity("Cinema.Dominio.Entities.Sessao.FilmeSala", b =>
                {
                    b.Property<int>("filme_id")
                        .HasColumnType("int");

                    b.Property<int>("sala_id")
                        .HasColumnType("int");

                    b.Property<bool>("Encerrada")
                        .HasColumnType("bit")
                        .HasColumnName("encerrada");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime")
                        .HasColumnName("horario");

                    b.Property<int>("Idioma")
                        .HasColumnType("int")
                        .HasColumnName("idioma");

                    b.HasKey("filme_id", "sala_id");

                    b.HasIndex("sala_id");

                    b.ToTable("Sessao", (string)null);
                });

            modelBuilder.Entity("Cinema.Dominio.Entities.Filmes.Filme", b =>
                {
                    b.HasOne("Cinema.Dominio.Entities.Generos.Genero", "Genero")
                        .WithMany("Filmes")
                        .HasForeignKey("genero_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("Cinema.Dominio.Entities.Sessao.FilmeSala", b =>
                {
                    b.HasOne("Cinema.Dominio.Entities.Filmes.Filme", "Filme")
                        .WithMany("Sessoes")
                        .HasForeignKey("filme_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Dominio.Entities.Salas.Sala", "Sala")
                        .WithMany("Sessoes")
                        .HasForeignKey("sala_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filme");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("Cinema.Dominio.Entities.Filmes.Filme", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("Cinema.Dominio.Entities.Generos.Genero", b =>
                {
                    b.Navigation("Filmes");
                });

            modelBuilder.Entity("Cinema.Dominio.Entities.Salas.Sala", b =>
                {
                    b.Navigation("Sessoes");
                });
#pragma warning restore 612, 618
        }
    }
}
