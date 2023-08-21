using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Generos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Dados.Contextos
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder
                .ToTable("Filme");

            builder
                .Property(f => f.Id)
                .HasColumnName("id");

            builder
                .Property(f => f.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(f => f.DataDeLancamento)
                .HasColumnName("data_de_lancamento")
                .HasColumnType("varchar(4)")
                .IsRequired();

            builder
                .Property(f => f.Duracao)
                .HasColumnName("duracao")
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property<int>("genero_id")
                .IsRequired();

            builder
                .HasOne(f => f.Genero)
                .WithMany(g => g.Filmes)
                .HasForeignKey("genero_id");
        }
    }
}
