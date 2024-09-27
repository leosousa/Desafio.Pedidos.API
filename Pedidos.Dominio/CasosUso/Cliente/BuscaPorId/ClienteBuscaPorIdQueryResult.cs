namespace Pedidos.Dominio.CasosUso.Cliente.BuscaPorId;

public record ClienteBuscaPorIdQueryResult(
    int Id,
    string Nome,
    string Email
);