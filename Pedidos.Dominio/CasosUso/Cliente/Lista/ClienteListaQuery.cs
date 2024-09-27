using MediatR;

namespace Pedidos.Dominio.CasosUso.Cliente.Lista;

public record ClienteListaQuery : IRequest<ClienteListaQueryResult>
{
}