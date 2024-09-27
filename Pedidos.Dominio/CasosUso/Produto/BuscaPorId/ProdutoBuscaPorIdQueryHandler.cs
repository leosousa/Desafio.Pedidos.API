using MediatR;
using Pedidos.Dominio.Contratos;

namespace Pedidos.Dominio.CasosUso.Produto.BuscaPorId;

public sealed class ProdutoBuscaPorIdQueryHandler : IRequestHandler<ProdutoBuscaPorIdQuery, ProdutoBuscaPorIdQueryResult?>
{
    private readonly IProdutoRepository _repository;

    public ProdutoBuscaPorIdQueryHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProdutoBuscaPorIdQueryResult?> Handle(ProdutoBuscaPorIdQuery request, CancellationToken cancellationToken)
    {
        ProdutoBuscaPorIdQueryResult? result = null;

        if (request is null) return await Task.FromResult(result);

        var produtoExistente = await _repository.BuscarPorIdAsync(request.Id);

        if (produtoExistente is null) return await Task.FromResult(result);

        result = new ProdutoBuscaPorIdQueryResult(produtoExistente.Id, produtoExistente.Nome, produtoExistente.Valor);

        return await Task.FromResult(result);
    }
}
