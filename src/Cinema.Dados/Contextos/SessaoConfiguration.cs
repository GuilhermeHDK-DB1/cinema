using Cinema.Dominio.Entities.Sessao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Dados.Contextos
{
    public class SessaoConfiguration : IEntityTypeConfiguration<FilmeSala>
    {
        public void Configure(EntityTypeBuilder<FilmeSala> builder)
        {
            builder
                .ToTable("Sessao");

            builder
                .Property<int>("filme_id")
                .IsRequired();

            builder
                .Property<int>("sala_id")
                .IsRequired();

            builder.HasKey("filme_id", "sala_id");

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
                .Property(s => s.Encerrada)
                .HasColumnName("encerrada")
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
