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
                .Property<int>("sessao_id")
                .IsRequired();

            builder
                .HasOne(i => i.Cliente)
                .WithMany(c => c.Ingressos)
                .HasForeignKey("cliente_id");

            builder
                .HasOne(i => i.Sessao)
                .WithMany(s => s.Ingressos)
                .HasForeignKey("sessao_id");

            builder
                .Property(i => i.Tipo)
                .HasColumnName("tipo")
                .IsRequired();
        }
    }
}
