using Cinema.Dominio.Entities.Sessoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Dados.Mappings
{
    public class SessaoConfiguration : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {
            builder
                .ToTable("Sessao");

            builder
                .Property(s => s.Id)
                .HasColumnName("id");

            builder
                .Property<int>("filme_id")
                .IsRequired();

            builder
                .Property<int>("sala_id")
                .IsRequired();

            builder
                .HasOne(s => s.Filme)
                .WithMany(s => s.Sessoes)
                .HasForeignKey("filme_id");

            builder
                .HasOne(s => s.Sala)
                .WithMany(s => s.Sessoes)
                .HasForeignKey("sala_id");

            builder
                .Property(s => s.Horario)
                .HasColumnName("horario")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(s => s.Idioma)
                .HasColumnName("idioma")
                .IsRequired();

            builder
                 .HasIndex("sala_id", "Horario")
                 .IsUnique();
        }
    }
}
