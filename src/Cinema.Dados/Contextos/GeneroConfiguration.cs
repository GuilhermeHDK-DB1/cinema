using Cinema.Dominio.Entities.Generos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Cinema.Dados.Contextos
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder
                .ToTable("Genero");

            builder
                .Property(g => g.Id)
                .HasColumnName("id");

            builder
                .Property(g => g.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}
