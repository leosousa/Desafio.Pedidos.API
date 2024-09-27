using MediatR;

namespace Pedidos.Dominio.CasosUso.Produto.Cadastro;

public record ProdutoCadastroCommand : IRequest<ProdutoCadastroCommandResult>
{
    public string Nome { get; set; }

    public decimal Valor { get; set; }
}