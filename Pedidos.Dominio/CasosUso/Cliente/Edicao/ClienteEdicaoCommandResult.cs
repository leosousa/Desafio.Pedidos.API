namespace Pedidos.Dominio.CasosUso.Cliente.Edicao;

public record ClienteEdicaoCommandResult
(
    int Id,
    string Nome,
    string Email
);