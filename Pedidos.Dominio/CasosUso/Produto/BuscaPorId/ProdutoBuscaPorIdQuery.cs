using MediatR;

namespace Pedidos.Dominio.CasosUso.Produto.BuscaPorId;

public record ProdutoBuscaPorIdQuery : IRequest<ProdutoBuscaPorIdQueryResult>
{
    public int Id { get; set; }
}
