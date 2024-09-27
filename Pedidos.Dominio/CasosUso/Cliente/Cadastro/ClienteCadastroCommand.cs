using MediatR;

namespace Pedidos.Dominio.CasosUso.Cliente.Cadastro;

public record ClienteCadastroCommand : IRequest<ClienteCadastroCommandResult>
{
    public string Nome { get; set; }

    public string Email { get; set; }
}