namespace Pedidos.Dominio.Entidades;

public class Pedido : Entidade
{
    public int IdCliente { get; private set; }
    public Cliente Cliente { get; set; }

    public bool Pago { get; private set; }

    public List<ItemPedido> Itens { get; protected set; }

    public DateTime DataCriacao { get; private set; }

    protected Pedido() { }

    public Pedido(int idCliente, bool pago, List<ItemPedido> itens)
    {
        IdCliente = idCliente;
        Pago = pago;
        Itens = itens;
        DataCriacao = DateTime.Now;
    }
}