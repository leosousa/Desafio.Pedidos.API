using MediatR;

namespace Pedidos.Dominio.CasosUso.Cliente.Remocao;

public record ClienteRemocaoCommand : IRequest<bool>
{
    public int Id { get; set; }
}