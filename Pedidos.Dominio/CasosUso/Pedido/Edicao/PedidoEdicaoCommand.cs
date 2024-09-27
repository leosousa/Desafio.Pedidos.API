using MediatR;
using Pedidos.Dominio.CasosUso.Pedido.Cadastro;

namespace Pedidos.Dominio.CasosUso.Pedido.Edicao;

public record PedidoEdicaoCommand : IRequest<PedidoEdicaoCommandResult>
{
    public int Id { get; set; }

    public bool Pago { get; set; }

    public PedidoEdicaoClienteCommand Cliente { get; set; }

    public List<PedidoEdicaoItemCommand> Itens { get; set; }
}

public record PedidoEdicaoClienteCommand
{
    public string Nome { get; set; }

    public string Email { get; set; }
}

public record PedidoEdicaoItemCommand
{
    public int IdProduto { get; set; }

    public int Quantidade { get; set; }
}