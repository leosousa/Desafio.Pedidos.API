using MediatR;
using Pedidos.Dominio.Contratos;

namespace Pedidos.Dominio.CasosUso.Produto.Remocao;

public sealed class ProdutoRemocaoCmomandHandler : IRequestHandler<ProdutoRemocaoCommand, bool>
{
    private readonly IProdutoRepository _repository;

    public ProdutoRemocaoCmomandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(ProdutoRemocaoCommand request, CancellationToken cancellationToken)
    {
        var produtoRemovido = false;

        if (request is null) return await Task.FromResult(produtoRemovido);

        var produtoExistente = await _repository.BuscarPorIdAsync(request.Id);

        if (produtoExistente is null) return await Task.FromResult(produtoRemovido);

        produtoRemovido = await _repository.RemoverAsync(produtoExistente);

        return await Task.FromResult(produtoRemovido);
    }
}
