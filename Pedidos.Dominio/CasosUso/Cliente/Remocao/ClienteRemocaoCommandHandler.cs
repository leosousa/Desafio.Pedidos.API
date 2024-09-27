using MediatR;
using Pedidos.Dominio.Contratos;

namespace Pedidos.Dominio.CasosUso.Cliente.Remocao;

public sealed class ProdutoRemocaoCmomandHandler : IRequestHandler<ClienteRemocaoCommand, bool>
{
    private readonly IClienteRepository _repository;

    public ProdutoRemocaoCmomandHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(ClienteRemocaoCommand request, CancellationToken cancellationToken)
    {
        var clienteRemovido = false;

        if (request is null) return await Task.FromResult(clienteRemovido);

        var clienteExistente = await _repository.BuscarPorIdAsync(request.Id);

        if (clienteExistente is null) return await Task.FromResult(clienteRemovido);

        clienteRemovido = await _repository.RemoverAsync(clienteExistente);

        return await Task.FromResult(clienteRemovido);
    }
}
