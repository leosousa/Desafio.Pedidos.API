namespace Pedidos.Dominio.Entidades;

public class ItemPedido : Entidade
{
    public int IdPedido { get; private set; }
    public Pedido Pedido { get; set; }

    public int IdProduto { get; private set; }
    public Produto Produto { get; set; }

    public int Quantidade { get; private set; }

    protected ItemPedido() { }

    public ItemPedido(int idProduto, int quantidade)
    {
        IdProduto = idProduto;
        Quantidade = quantidade;
    }
}
