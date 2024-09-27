using Microsoft.AspNetCore.Mvc;
using Pedidos.Dominio.CasosUso.Pedido.BuscaPorId;
using Pedidos.Dominio.CasosUso.Pedido.Cadastro;
using Pedidos.Dominio.CasosUso.Pedido.Edicao;
using Pedidos.Dominio.CasosUso.Pedido.Lista;
using Pedidos.Dominio.CasosUso.Pedido.Remocao;

namespace Pedidos.API.Controllers;

[Route("api/pedidos")]
public class PedidoController : ApiControllerBase
{
    /// <summary>
    /// Cadastra um novo pedido
    /// </summary>
    /// <param name="pedido">Pedido a ser cadastrado</param>
    /// <returns>Id do novo pedido cadastrado</returns>
    [HttpPost]
    public async Task<IActionResult> Create(PedidoCadastroCommand pedido)
    {
        var pedidoCadastrado = await Mediator.Send(pedido);

        if (pedidoCadastrado is null) return BadRequest();

        return CreatedAtAction(nameof(GetById),
           new
           {
               id = pedidoCadastrado.Id
           },
           pedidoCadastrado
        );
    }

    /// <summary>
    /// Busca um pedido já cadastrado pelo seu identificador
    /// </summary>
    /// <param name="id">Identificador do pedido</param>
    /// <returns>Pedido encontrado</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await Mediator.Send(new PedidoBuscaPorIdQuery { Id = id });

        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Lista os pedidos cadastradas no banco de dados
    /// </summary>
    /// <returns>Lista de pedidos encontrados</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await Mediator.Send(new PedidoListaQuery());

        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Atualiza um pedido já existente
    /// </summary>
    /// <param name="id">Identificador do pedido a ser atualizado</param>
    /// <param name="pedido">Pedido a ser atualizado</param>
    /// <returns>Pedido atualizado</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PedidoEdicaoCommand task)
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
    /// Remove um pedido já existente
    /// </summary>
    /// <param name="id">Identificador do pedido a ser removido</param>
    /// <returns>Retorna se o pedido foi ou não removido</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pedidoRemovido = await Mediator.Send(new PedidoRemocaoCommand { Id = id });

        if (!pedidoRemovido) return NotFound();

        return NoContent();
    }
}
