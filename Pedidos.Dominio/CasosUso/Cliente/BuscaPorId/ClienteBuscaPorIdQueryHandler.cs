using MediatR;
using Pedidos.Dominio.Contratos;

namespace Pedidos.Dominio.CasosUso.Cliente.BuscaPorId;

public sealed class ClienteBuscaPorIdQueryHandler : IRequestHandler<ClienteBuscaPorIdQuery, ClienteBuscaPorIdQueryResult?>
{
    private readonly IClienteRepository _repository;

    public ClienteBuscaPorIdQueryHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClienteBuscaPorIdQueryResult?> Handle(ClienteBuscaPorIdQuery request, CancellationToken cancellationToken)
    {
        ClienteBuscaPorIdQueryResult? result = null;

        if (request is null) return await Task.FromResult(result);

        var clienteExistente = await _repository.BuscarPorIdAsync(request.Id);

        if (clienteExistente is null) return await Task.FromResult(result);

        result = new ClienteBuscaPorIdQueryResult(clienteExistente.Id, clienteExistente.Nome, clienteExistente.Email);

        return await Task.FromResult(result);
    }
}
