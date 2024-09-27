namespace Pedidos.Dominio.CasosUso.Produto.BuscaPorId;

public record ProdutoBuscaPorIdQueryResult(
    int Id,
    string Nome,
    decimal Valor
);