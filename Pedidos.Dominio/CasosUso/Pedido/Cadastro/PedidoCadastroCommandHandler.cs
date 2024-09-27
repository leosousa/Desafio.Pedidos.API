using MediatR;
using Pedidos.Dominio.Contratos;
using Pedidos.Dominio.Entidades;

namespace Pedidos.Dominio.CasosUso.Pedido.Cadastro;

public class PedidoCadastroCommandHandler : IRequestHandler<PedidoCadastroCommand, PedidoCadastroCommandResult?>
{
    private readonly IPedidoRepository _repository;

    public PedidoCadastroCommandHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<PedidoCadastroCommandResult?> Handle(PedidoCadastroCommand request, CancellationToken cancellationToken)
    {
        PedidoCadastroCommandResult? result = null;

        if (request.Cliente is null) return await Task.FromResult(result);

        var itensPedido = new List<ItemPedido>();
        foreach (var item in request.Itens)
        {
            itensPedido.Add(new ItemPedido(item.IdProduto, item.Quantidade));
        }

        var pedido = new Entidades.Pedido(request.Cliente.Nome, request.Cliente.Email, pago:false, itensPedido);

        var novoPedido = await _repository.CadastrarAsync(pedido);

        if (novoPedido is null) return await Task.FromResult(result);

        return await Task.FromResult(new PedidoCadastroCommandResult(novoPedido.Id, novoPedido.NomeCliente, novoPedido.Itens.Count));
    }
}