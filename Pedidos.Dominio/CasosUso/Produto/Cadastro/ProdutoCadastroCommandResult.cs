namespace Pedidos.Dominio.CasosUso.Produto.Cadastro;

public record ProdutoCadastroCommandResult(
    int Id, 
    string Nome, 
    decimal Valor
);