using MediatR;

namespace Pedidos.Dominio.CasosUso.Cliente.Edicao;

public record ClienteEdicaoCommand : IRequest<ClienteEdicaoCommandResult>
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }
}