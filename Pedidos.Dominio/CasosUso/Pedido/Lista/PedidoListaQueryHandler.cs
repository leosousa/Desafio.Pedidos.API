using MediatR;
using Pedidos.Dominio.Contratos;

namespace Pedidos.Dominio.CasosUso.Pedido.Lista;

public sealed class PedidoListaQueryHandler : IRequestHandler<PedidoListaQuery, PedidoListaQueryResult>
{
    private readonly IPedidoRepository _repository;

    public PedidoListaQueryHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<PedidoListaQueryResult> Handle(PedidoListaQuery request, CancellationToken cancellationToken)
    {
        PedidoListaQueryResult result = new();

        var pedidos = await _repository.ListarAsync();

        if (pedidos is null) return await Task.FromResult(result);

        var itensResult = new List<PedidoListaItemItemPedido>();

        pedidos!.ToList().ForEach(pedido =>
        {
            pedido.Itens.ForEach(item =>
            {
                itensResult.Add(new PedidoListaItemItemPedido(item.Id,
                    item.IdProduto,
                    item.Produto.Nome,
                    item.Produto.Valor,
                    item.Quantidade)
                );
            });

            result.Add(new PedidoListaItemQueryResult(pedido.Id,
                pedido.NomeCliente,
                pedido.EmailCliente,
                pedido.Pago,
                pedido.Itens.Sum(item => item.Produto.Valor),
                itensResult
            ));
        });

        return await Task.FromResult(result);
    }
}
