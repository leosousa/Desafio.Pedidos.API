namespace Pedidos.Dominio.CasosUso.Pedido.Cadastro;

public record PedidoCadastroCommandResult(
    int Id, 
    string NomeCliente, 
    int Quantidade
);