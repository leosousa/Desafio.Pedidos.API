using Pedidos.Dominio.CasosUso.Pedido.Lista;

namespace Pedidos.Dominio.CasosUso.Pedido.BuscaPorId;

public record PedidoBuscaPorIdQueryResult(
    int Id,
    string NomeCliente,
    string EmailCliente,
    bool Pago,
    decimal ValorTotal,
    IEnumerable<PedidoBuscaPorIdItemItemPedido> ItensPedido
);

public record PedidoBuscaPorIdItemItemPedido(
    int Id,
    int IdProduto,
    string NomeProduto,
    decimal ValorUnitario,
    int Quantidade
);