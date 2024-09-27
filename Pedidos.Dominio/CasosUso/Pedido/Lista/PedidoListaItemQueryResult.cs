namespace Pedidos.Dominio.CasosUso.Pedido.Lista;

public record PedidoListaItemQueryResult(
    int Id,
    string NomeCliente,
    string EmailCliente,
    bool Pago,
    decimal ValorTotal,
    IEnumerable<PedidoListaItemItemPedido> ItensPedido
);

public record PedidoListaItemItemPedido(
    int Id,
    int IdProduto,
    string NomeProduto,
    decimal ValorUnitario,
    int Quantidade
);