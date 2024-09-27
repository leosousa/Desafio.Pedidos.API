namespace Pedidos.Dominio.CasosUso.Produto.Edicao;

public record ProdutoEdicaoCommandResult
(
    int Id,
    string Nome,
    decimal Valor
);