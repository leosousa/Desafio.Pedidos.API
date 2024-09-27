namespace Pedidos.Dominio.CasosUso.Cliente.Cadastro;

public record ClienteCadastroCommandResult(
    int Id, 
    string Nome, 
    string Email
);