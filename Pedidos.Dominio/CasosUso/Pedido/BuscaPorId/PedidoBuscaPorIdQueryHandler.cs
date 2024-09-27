using MediatR;
using Pedidos.Dominio.CasosUso.Pedido.Lista;
using Pedidos.Dominio.Contratos;
using Pedidos.Dominio.Entidades;

namespace Pedidos.Dominio.CasosUso.Pedido.BuscaPorId;

public sealed class PedidoBuscaPorIdQueryHandler : IRequestHandler<PedidoBuscaPorIdQuery, PedidoBuscaPorIdQueryResult?>
{
    private readonly IPedidoRepository _repository;

    public PedidoBuscaPorIdQueryHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<PedidoBuscaPorIdQueryResult?> Handle(PedidoBuscaPorIdQuery request, CancellationToken cancellationToken)
    {
        PedidoBuscaPorIdQueryResult? result = null;

        if (request is null) return await Task.FromResult(result);

        var pedidoExistente = await _repository.BuscarPorIdAsync(request.Id);

        if (pedidoExistente is null) return await Task.FromResult(result);

        var itensResult = new List<PedidoBuscaPorIdItemItemPedido>();

        pedidoExistente.Itens.ForEach(item =>
        {
            itensResult.Add(new PedidoBuscaPorIdItemItemPedido(item.Id,
                item.IdProduto,
                item.Produto.Nome,
                item.Produto.Valor,
                item.Quantidade)
            );
        });

        result = new PedidoBuscaPorIdQueryResult(pedidoExistente.Id, 
            pedidoExistente.NomeCliente,
            pedidoExistente.EmailCliente,
            pedidoExistente.Pago,
            pedidoExistente.Itens.Sum(item => item.Produto.Valor),
            itensResult
        );

        return await Task.FromResult(result);
    }
}
