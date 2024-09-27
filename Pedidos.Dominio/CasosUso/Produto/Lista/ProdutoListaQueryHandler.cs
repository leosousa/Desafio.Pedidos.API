using MediatR;
using Pedidos.Dominio.Contratos;

namespace Pedidos.Dominio.CasosUso.Produto.Lista;

public sealed class ProdutoListaQueryHandler : IRequestHandler<ProdutoListaQuery, ProdutoListaQueryResult>
{
    private readonly IProdutoRepository _repository;

    public ProdutoListaQueryHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProdutoListaQueryResult> Handle(ProdutoListaQuery request, CancellationToken cancellationToken)
    {
        ProdutoListaQueryResult result = new();

        var produtos = await _repository.ListarAsync();

        if (produtos is null) return await Task.FromResult(result);

        produtos!.ToList().ForEach(task => {
            result.Add(new ProdutoListaItemQueryResult(task.Id, task.Nome, task.Valor));
        });

        return await Task.FromResult(result);
    }
}
