using Cinema.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Dados.Mappings
{
    public class SessaoIngressoConfiguration : IEntityTypeConfiguration<SessaoIngresso>
    {
        public void Configure(EntityTypeBuilder<SessaoIngresso> builder)
        {
            builder
                .ToTable("Sessao_Ingresso");

            builder
                .Property<int>("sessao_id")
                .IsRequired();

            builder
                .Property<int>("ingresso_id")
                .IsRequired();

            builder
                .HasOne(si => si.Sessao)
                .WithMany(s => s.SessoesIngressos)
                .HasForeignKey("sessao_id");

            builder
                .HasOne(si => si.Ingresso)
                .WithMany(i => i.SessoesIngressos)
                .HasForeignKey("ingresso_id");

            builder
                .HasKey("sessao_id", "ingresso_id");
        }
    }
}
