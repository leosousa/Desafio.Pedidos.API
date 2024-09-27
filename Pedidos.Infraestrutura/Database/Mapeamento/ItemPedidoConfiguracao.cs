using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Entidades;

namespace Pedidos.Infraestrutura.Database.Mapeamento;

public class ItemPedidoConfiguracao : IEntityTypeConfiguration<ItemPedido>
{
    public void Configure(EntityTypeBuilder<ItemPedido> builder)
    {
        builder.ToTable(nameof(ItemPedido));

        builder.HasKey(propriedade => propriedade.Id);

        builder
            .Property(propriedade => propriedade.Quantidade)
            .IsRequired();

        builder
            .HasOne(item => item.Pedido)
            .WithMany(pedido => pedido.Itens)
            .HasForeignKey(itemPedido => itemPedido.IdPedido)
            .IsRequired();

        builder
            .HasOne(item => item.Produto)
            .WithOne(produto => produto.ItemPedido)
            .HasForeignKey<ItemPedido>(itemPedido => itemPedido.IdProduto)
            .IsRequired();
    }
}