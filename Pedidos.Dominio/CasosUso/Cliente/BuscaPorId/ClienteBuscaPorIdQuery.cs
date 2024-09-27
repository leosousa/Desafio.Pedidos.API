using MediatR;

namespace Pedidos.Dominio.CasosUso.Cliente.BuscaPorId;

public record ClienteBuscaPorIdQuery : IRequest<ClienteBuscaPorIdQueryResult>
{
    public int Id { get; set; }
}
