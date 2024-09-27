namespace Pedidos.Dominio.Entidades;

public class Pedido : Entidade
{
    public string NomeCliente { get; set; }

    public string EmailCliente { get; set; }

    public bool Pago { get; private set; }

    public List<ItemPedido> Itens { get; protected set; }

    public DateTime DataCriacao { get; private set; }

    protected Pedido() { }

    public Pedido(string nomeCliente, string emailCliente, bool pago, List<ItemPedido> itens)
    {
        NomeCliente = nomeCliente;
        EmailCliente = emailCliente;
        Pago = pago;
        Itens = itens;
        DataCriacao = DateTime.Now;
    }

    public void AlterarItens(List<ItemPedido> itens)
    {
        Itens.Clear();
        Itens = itens;
    }

    public void AlterarEmailCliente(string email)
    {
        EmailCliente = email;
    }

    public void AlterarNomeCliente(string nome)
    {
        NomeCliente = nome;
    }

    public void RealizarPagamento()
    {
        Pago = true;
    }
}