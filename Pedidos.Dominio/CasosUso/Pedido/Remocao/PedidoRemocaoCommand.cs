using MediatR;

namespace Pedidos.Dominio.CasosUso.Pedido.Remocao;

public record PedidoRemocaoCommand : IRequest<bool>
{
    public int Id { get; set; }
}