namespace Pedidos.Dominio.CasosUso.Produto.Lista;

public record ProdutoListaItemQueryResult(
    int Id,
    string Nome,
    decimal Valor
);