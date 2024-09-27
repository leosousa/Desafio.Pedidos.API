using MediatR;
using Pedidos.Dominio.CasosUso.Produto.Cadastro;
using Pedidos.Dominio.Contratos;

namespace Pedidos.Dominio.CasosUso.Cliente.Cadastro;

public class ClienteCadastroCommandHandler : IRequestHandler<ClienteCadastroCommand, ClienteCadastroCommandResult?>
{
    private readonly IClienteRepository _repository;

    public ClienteCadastroCommandHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClienteCadastroCommandResult?> Handle(ClienteCadastroCommand request, CancellationToken cancellationToken)
    {
        ClienteCadastroCommandResult? result = null;

        if (request.Nome is null) return await Task.FromResult(result);

        var cliente = new Entidades.Cliente(request.Nome, request.Email);

        var novoCliente = await _repository.CadastrarAsync(cliente);

        if (novoCliente is null) return await Task.FromResult(result);

        return await Task.FromResult(new ClienteCadastroCommandResult(novoCliente.Id, novoCliente.Nome, novoCliente.Email));
    }
}