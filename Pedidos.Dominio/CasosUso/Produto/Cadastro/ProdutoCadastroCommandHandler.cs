using MediatR;
using Pedidos.Dominio.Contratos;

namespace Pedidos.Dominio.CasosUso.Produto.Cadastro;

public class ProdutoCadastroCommandHandler : IRequestHandler<ProdutoCadastroCommand, ProdutoCadastroCommandResult?>
{
    private readonly IProdutoRepository _repository;

    public ProdutoCadastroCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProdutoCadastroCommandResult?> Handle(ProdutoCadastroCommand request, CancellationToken cancellationToken)
    {
        ProdutoCadastroCommandResult? result = null;

        if (request.Nome is null) return await Task.FromResult(result);

        var produto = new Entidades.Produto(request.Nome, request.Valor);

        var novoProduto = await _repository.CadastrarAsync(produto);

        if (novoProduto is null) return await Task.FromResult(result);

        return await Task.FromResult(new ProdutoCadastroCommandResult(novoProduto.Id, novoProduto.Nome, novoProduto.Valor));
    }
}