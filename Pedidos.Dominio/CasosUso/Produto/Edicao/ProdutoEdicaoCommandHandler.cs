using MediatR;
using Pedidos.Dominio.Contratos;

namespace Pedidos.Dominio.CasosUso.Produto.Edicao;

public class ProdutoEdicaoCommandHandler : IRequestHandler<ProdutoEdicaoCommand, ProdutoEdicaoCommandResult?>
{
    private readonly IProdutoRepository _repository;

    public ProdutoEdicaoCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProdutoEdicaoCommandResult?> Handle(ProdutoEdicaoCommand request, CancellationToken cancellationToken)
    {
        ProdutoEdicaoCommandResult? result = null;

        if (request is null) return await Task.FromResult(result);

        var produtoCadastrado = await _repository.BuscarPorIdAsync(request.Id);

        if (produtoCadastrado == null) return await Task.FromResult(result);

        produtoCadastrado.EditarNome(request.Nome);
        produtoCadastrado.EditarPreco(request.Valor);

        var produtoEditado = await _repository.EditarAsync(produtoCadastrado);

        if (produtoEditado is null) return await Task.FromResult(result);

        return await Task.FromResult(new ProdutoEdicaoCommandResult(produtoEditado.Id, produtoEditado.Nome, produtoEditado.Valor));
    }
}