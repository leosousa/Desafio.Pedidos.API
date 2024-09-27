using MediatR;

namespace Pedidos.Dominio.CasosUso.Produto.Edicao;

public record ProdutoEdicaoCommand : IRequest<ProdutoEdicaoCommandResult>
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public decimal Valor { get; set; }
}