using Cinema.Dominio.Entities.Salas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Dados.Contextos
{
    public class SalaConfiguration : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder
                .ToTable("Sala");

            builder
                .Property(s => s.Id)
                .HasColumnName("id");

            builder
                .Property(g => g.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(g => g.SalaVip)
                .HasColumnName("sala_vip")
                .HasColumnType("bit")
                .HasDefaultValue(0);

            builder
                .Property(g => g.Sala3D)
                .HasColumnName("sala_3d")
                .HasColumnType("bit")
                .HasDefaultValue(0);

            builder
                .Property(g => g.Capacidade)
                .HasColumnName("capacidade")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
