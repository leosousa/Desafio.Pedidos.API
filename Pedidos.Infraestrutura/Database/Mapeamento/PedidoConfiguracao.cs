using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Entidades;

namespace Pedidos.Infraestrutura.Database.Mapeamento;

public class PedidoConfiguracao : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable(nameof(Pedido));

        builder.HasKey(propriedade => propriedade.Id);

        builder
            .Property(propriedade => propriedade.Pago)
            .IsRequired();

        builder
            .Property(propriedade => propriedade.DataCriacao)
            .IsRequired();

        builder
            .HasOne(pedido => pedido.Cliente)
            .WithMany(cliente => cliente.Pedidos)
            .HasForeignKey(pedido => pedido.IdCliente)
            .IsRequired();

        builder
            .HasMany(pedido => pedido.Itens)
            .WithOne(item => item.Pedido)
            .HasForeignKey(itemPedido => itemPedido.IdPedido)
            .IsRequired();
    }
}