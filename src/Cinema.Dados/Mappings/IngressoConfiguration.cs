using Cinema.Dominio.Entities.Ingressos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Dados.Mappings
{
    public class IngressoConfiguration : IEntityTypeConfiguration<Ingresso>
    {
        public void Configure(EntityTypeBuilder<Ingresso> builder)
        {
            builder
                .ToTable("Ingresso");

            builder
                .Property(i => i.Id)
                .HasColumnName("id");

            builder
                .Property<int>("cliente_id")
                .IsRequired();

            builder
                .HasOne(i => i.Cliente)
                .WithMany(c => c.Ingressos)
                .HasForeignKey("cliente_id");

            builder
                .Property(i => i.Tipo)
                .HasColumnName("tipo")
                .IsRequired();
        }
    }
}
