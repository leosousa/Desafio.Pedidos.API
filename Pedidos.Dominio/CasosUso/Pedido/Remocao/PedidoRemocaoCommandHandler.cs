using MediatR;
using Pedidos.Dominio.Contratos;

namespace Pedidos.Dominio.CasosUso.Pedido.Remocao;

public sealed class PedidoRemocaoCmomandHandler : IRequestHandler<PedidoRemocaoCommand, bool>
{
    private readonly IPedidoRepository _repository;

    public PedidoRemocaoCmomandHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(PedidoRemocaoCommand request, CancellationToken cancellationToken)
    {
        var pedidoRemovido = false;

        if (request is null) return await Task.FromResult(pedidoRemovido);

        var pedidoExistente = await _repository.BuscarPorIdAsync(request.Id);

        if (pedidoExistente is null) return await Task.FromResult(pedidoRemovido);

        pedidoRemovido = await _repository.RemoverAsync(pedidoExistente);

        return await Task.FromResult(pedidoRemovido);
    }
}
