using MediatR;
using Pedidos.Dominio.CasosUso.Produto.Edicao;
using Pedidos.Dominio.Contratos;

namespace Pedidos.Dominio.CasosUso.Cliente.Edicao;

public class ClienteEdicaoCommandHandler : IRequestHandler<ClienteEdicaoCommand, ClienteEdicaoCommandResult?>
{
    private readonly IClienteRepository _repository;

    public ClienteEdicaoCommandHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClienteEdicaoCommandResult?> Handle(ClienteEdicaoCommand request, CancellationToken cancellationToken)
    {
        ClienteEdicaoCommandResult? result = null;

        if (request is null) return await Task.FromResult(result);

        var clienteCadastrado = await _repository.BuscarPorIdAsync(request.Id);

        if (clienteCadastrado == null) return await Task.FromResult(result);

        clienteCadastrado.AlterarNome(request.Nome);
        clienteCadastrado.AlterarEmail(request.Email);

        var clienteEditado = await _repository.EditarAsync(clienteCadastrado);

        if (clienteEditado is null) return await Task.FromResult(result);

        return await Task.FromResult(new ClienteEdicaoCommandResult(clienteEditado.Id, clienteEditado.Nome, clienteEditado.Email));
    }
}