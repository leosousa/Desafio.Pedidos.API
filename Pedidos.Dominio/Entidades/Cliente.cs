namespace Pedidos.Dominio.Entidades;

public class Cliente : Entidade
{
    public string Nome { get; private set; }

    public string Email { get; private set; }

    public List<Pedido> Pedidos { get; set; }

    protected Cliente() { }

    public Cliente(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}