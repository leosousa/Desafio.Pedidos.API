namespace Pedidos.Dominio.Entidades;

public class Produto : Entidade
{
    public string Nome { get; private set; }

    public decimal Valor { get; private set; }

    public ItemPedido ItemPedido { get; set; }

    protected Produto() { }

    public Produto(string nome, decimal valor)
    {
        Nome = nome;
        Valor = valor;
    }
}