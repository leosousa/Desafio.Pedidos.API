namespace Pedidos.Dominio.CasosUso.Pedido.Edicao;

public record PedidoEdicaoCommandResult
(
    int Id,
    string NomeCliente,
    int Quantidade
);