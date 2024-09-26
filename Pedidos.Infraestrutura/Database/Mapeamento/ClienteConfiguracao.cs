using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Dominio.Entidades;

namespace Pedidos.Infraestrutura.Database.Mapeamento;

public class ClienteConfiguracao : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable(nameof(Cliente));

        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(255);

        builder
            .Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(255);
    }
}