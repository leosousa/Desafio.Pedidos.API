using MediatR;
using Pedidos.Dominio.Contratos;
using Pedidos.Dominio.Entidades;

namespace Pedidos.Dominio.CasosUso.Pedido.Edicao;

public class PedidoEdicaoCommandHandler : IRequestHandler<PedidoEdicaoCommand, PedidoEdicaoCommandResult?>
{
    private readonly IPedidoRepository _repository;

    public PedidoEdicaoCommandHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<PedidoEdicaoCommandResult?> Handle(PedidoEdicaoCommand request, CancellationToken cancellationToken)
    {
        PedidoEdicaoCommandResult? result = null;

        if (request is null) return await Task.FromResult(result);

        var pedidoCadastrado = await _repository.BuscarPorIdAsync(request.Id);

        if (pedidoCadastrado == null) return await Task.FromResult(result);

        var itensPedido = new List<ItemPedido>();
        foreach (var item in request.Itens)
        {
            itensPedido.Add(new ItemPedido(item.IdProduto, item.Quantidade));
        }

        pedidoCadastrado.AlterarNomeCliente(request.Cliente.Email);
        pedidoCadastrado.AlterarEmailCliente(request.Cliente.Email);
        pedidoCadastrado.AlterarItens(itensPedido);
        if (request.Pago) pedidoCadastrado.RealizarPagamento();

        var pedidoEditado = await _repository.EditarAsync(pedidoCadastrado);

        if (pedidoEditado is null) return await Task.FromResult(result);

        return await Task.FromResult(new PedidoEdicaoCommandResult(pedidoEditado.Id, pedidoEditado.NomeCliente, pedidoEditado.Itens.Count));
    }
}