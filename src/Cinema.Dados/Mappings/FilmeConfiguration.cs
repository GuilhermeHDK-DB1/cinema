using Cinema.Dominio.Entities.Filmes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Dados.Mappings
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
                .Property(f => f.AnoDeLancamento)
                .HasColumnName("ano_de_lancamento")
                .HasColumnType("varchar(4)")
                .IsRequired();

            builder
                .Property(f => f.Duracao)
                .HasColumnName("duracao")
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(f => f.ClassificacaoString)
                .HasColumnName("classificacao")
                .HasColumnType("varchar(10)");

            builder
                .Ignore(f => f.Classificacao);

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
