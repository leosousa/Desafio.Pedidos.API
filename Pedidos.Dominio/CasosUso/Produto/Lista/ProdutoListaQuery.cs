using MediatR;

namespace Pedidos.Dominio.CasosUso.Produto.Lista;

public record ProdutoListaQuery : IRequest<ProdutoListaQueryResult>
{
}