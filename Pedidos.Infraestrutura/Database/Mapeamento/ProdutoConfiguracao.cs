using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Entidades;

namespace Pedidos.Infraestrutura.Database.Mapeamento;

public class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable(nameof(Produto));

        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(255);

        builder
            .Property(c => c.Valor)
            .HasColumnType("decimal")
            .HasPrecision(10, 2)
            .IsRequired();
    }
}