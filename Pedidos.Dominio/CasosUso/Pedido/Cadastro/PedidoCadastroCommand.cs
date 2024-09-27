using MediatR;

namespace Pedidos.Dominio.CasosUso.Pedido.Cadastro;

public record PedidoCadastroCommand : IRequest<PedidoCadastroCommandResult>
{
    public PedidoCadastroClienteCommand Cliente { get; set; }

    public List<PedidoCadastroItemCommand> Itens { get; set; }
}

public record PedidoCadastroClienteCommand
{
    public string Nome { get; set; }

    public string Email { get; set; }
}

public record PedidoCadastroItemCommand
{
    public int IdProduto { get; set; }

    public int Quantidade { get; set; }
}