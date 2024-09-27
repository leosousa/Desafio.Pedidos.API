using MediatR;

namespace Pedidos.Dominio.CasosUso.Produto.Remocao;

public record ProdutoRemocaoCommand : IRequest<bool>
{
    public int Id { get; set; }
}