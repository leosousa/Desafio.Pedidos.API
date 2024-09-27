using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Dominio.CasosUso.Cliente.BuscaPorId;
using Pedidos.Dominio.CasosUso.Cliente.Cadastro;
using Pedidos.Dominio.CasosUso.Cliente.Edicao;
using Pedidos.Dominio.CasosUso.Cliente.Lista;
using Pedidos.Dominio.CasosUso.Cliente.Remocao;

namespace Pedidos.API.Controllers;

[Route("api/clientes")]
public class ClienteController : ApiControllerBase
{
    /// <summary>
    /// Cadastra um novo cliente
    /// </summary>
    /// <param name="cliente">Cliente a ser cadastrado</param>
    /// <returns>Id do novo cliente cadastrado</returns>
    [HttpPost]
    public async Task<IActionResult> Create(ClienteCadastroCommand cliente)
    {
        var clienteCadastrado = await Mediator.Send(cliente);

        if (clienteCadastrado is null) return BadRequest();

        return CreatedAtAction(nameof(GetById),
           new
           {
               id = clienteCadastrado.Id
           },
           clienteCadastrado
        );
    }

    /// <summary>
    /// Busca um cliente já cadastrado pelo seu identificador
    /// </summary>
    /// <param name="id">Identificador do cliente</param>
    /// <returns>Cliente encontrado</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await Mediator.Send(new ClienteBuscaPorIdQuery { Id = id });

        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Lista os clientes cadastradas no banco de dados
    /// </summary>
    /// <returns>Lista de clientes encontrados</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await Mediator.Send(new ClienteListaQuery());

        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Atualiza um cliente já existente
    /// </summary>
    /// <param name="id">Identificador do cliente a ser atualizado</param>
    /// <param name="cliente">Cliente a ser atualizado</param>
    /// <returns>Cliente atualizado</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ClienteEdicaoCommand task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        var result = await Mediator.Send(task);

        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Remove um cliente já existente
    /// </summary>
    /// <param name="id">Identificador do cliente a ser removido</param>
    /// <returns>Retorna se o cliente foi ou não removido</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var clienteRemovido = await Mediator.Send(new ClienteRemocaoCommand { Id = id });

        if (!clienteRemovido) return NotFound();

        return NoContent();
    }
}
