using MediatR;
using Pedidos.Dominio.Contratos;

namespace Pedidos.Dominio.CasosUso.Cliente.Lista;

public sealed class ClienteListaQueryHandler : IRequestHandler<ClienteListaQuery, ClienteListaQueryResult>
{
    private readonly IClienteRepository _repository;

    public ClienteListaQueryHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClienteListaQueryResult> Handle(ClienteListaQuery request, CancellationToken cancellationToken)
    {
        ClienteListaQueryResult result = new();

        var clientes = await _repository.ListarAsync();

        if (clientes is null) return await Task.FromResult(result);

        clientes!.ToList().ForEach(task => {
            result.Add(new ClienteListaItemQueryResult(task.Id, task.Nome, task.Email));
        });

        return await Task.FromResult(result);
    }
}
