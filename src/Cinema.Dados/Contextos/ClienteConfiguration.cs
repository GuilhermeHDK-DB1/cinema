using Cinema.Dominio.Entities.Cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Dados.Contextos
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .ToTable("Cliente");

            builder
                .Property(c => c.Id)
                .HasColumnName("id");

            builder
                .Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(c => c.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(c => c.DataDeNascimento)
                .HasColumnName("data_de_nascimento")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(c => c.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("bit");
        }
    }
}
