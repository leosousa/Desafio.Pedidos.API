using MediatR;

namespace Pedidos.Dominio.CasosUso.Pedido.Lista;

public record PedidoListaQuery : IRequest<PedidoListaQueryResult>
{
}