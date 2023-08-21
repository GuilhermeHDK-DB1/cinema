using Cinema.Dominio.Entities.Ingressos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Dados.Contextos
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
                .Property<int>("filme_id")
                .IsRequired();

            builder
                .HasOne(i => i.Filme)
                .WithMany(f => f.Ingressos)
                .HasForeignKey("filme_id");

            builder
                .Property<int>("sala_id")
                .IsRequired();

            builder
                .HasOne(i => i.Sala)
                .WithMany(s => s.Ingressos)
                .HasForeignKey("sala_id");

            builder
                .Property(i => i.Tipo)
                .HasColumnName("tipo")
                .IsRequired();
        }
    }
}
