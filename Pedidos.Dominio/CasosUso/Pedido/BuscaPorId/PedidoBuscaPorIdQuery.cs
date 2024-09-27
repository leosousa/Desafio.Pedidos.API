using MediatR;

namespace Pedidos.Dominio.CasosUso.Pedido.BuscaPorId;

public record PedidoBuscaPorIdQuery : IRequest<PedidoBuscaPorIdQueryResult>
{
    public int Id { get; set; }
}
