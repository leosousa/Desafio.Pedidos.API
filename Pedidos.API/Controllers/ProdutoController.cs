using Microsoft.AspNetCore.Mvc;
using Pedidos.Dominio.CasosUso.Produto.BuscaPorId;
using Pedidos.Dominio.CasosUso.Produto.Cadastro;
using Pedidos.Dominio.CasosUso.Produto.Edicao;
using Pedidos.Dominio.CasosUso.Produto.Lista;
using Pedidos.Dominio.CasosUso.Produto.Remocao;

namespace Pedidos.API.Controllers;


[Route("api/produtos")]
public class ProdutoController : ApiControllerBase
{
    /// <summary>
    /// Cadastra um novo produto
    /// </summary>
    /// <param name="produto">Produto a ser cadastrado</param>
    /// <returns>Id do novo produto cadastrado</returns>
    [HttpPost]
    public async Task<IActionResult> Create(ProdutoCadastroCommand produto)
    {
        var produtoCadastrado = await Mediator.Send(produto);

        if (produtoCadastrado is null) return BadRequest();

        return CreatedAtAction(nameof(GetById),
           new
           {
               id = produtoCadastrado.Id
           },
           produtoCadastrado
        );
    }

    /// <summary>
    /// Busca um produto já cadastrado pelo seu identificador
    /// </summary>
    /// <param name="id">Identificador do produto</param>
    /// <returns>Produto encontrado</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await Mediator.Send(new ProdutoBuscaPorIdQuery { Id = id });

        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Lista os produtos cadastradas no banco de dados
    /// </summary>
    /// <returns>Lista de produtos encontrados</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await Mediator.Send(new ProdutoListaQuery());

        if (result is null) return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Atualiza um produto já existente
    /// </summary>
    /// <param name="id">Identificador do produto a ser atualizado</param>
    /// <param name="produto">Produto a ser atualizado</param>
    /// <returns>Produto atualizado</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProdutoEdicaoCommand task)
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
    /// Remove um produto já existente
    /// </summary>
    /// <param name="id">Identificador do produto a ser removido</param>
    /// <returns>Retorna se o produto foi ou não removido</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var produtoRemovido = await Mediator.Send(new ProdutoRemocaoCommand { Id = id });

        if (!produtoRemovido) return NotFound();

        return NoContent();
    }
}