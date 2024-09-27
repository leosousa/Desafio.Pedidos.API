using Pedidos.Dominio.Entidades;

namespace Pedidos.Dominio.Contratos;

public interface IProdutoRepository
{
    /// <summary>
    /// Cadastra um novo produto na base de dados
    /// </summary>
    /// <param name="produto">Produto a ser cadastrado</param>
    /// <returns>Produto cadastrado</returns>
    Task<Produto> CadastrarAsync(Produto produto);

    /// <summary>
    /// Atualiza um produto no banco de dados
    /// </summary>
    /// <param name="produto">Produto a ser atualizado</param>
    /// <returns>Produto atualizado</returns>
    Task<Produto> EditarAsync(Produto produto);

    /// <summary>
    /// Remove um produto do banco de dados
    /// </summary>
    /// <param name="produto">Produto a ser removido</param>
    /// <returns>Retorna se o produto foi ou não removido</returns>
    Task<bool> RemoverAsync(Produto produto);

    /// <summary>
    /// Lista todos os produtos na base de dados
    /// </summary>
    /// <returns>Lista de produtos encontrados</returns>
    Task<IEnumerable<Produto>> ListarAsync();

    /// <summary>
    /// Busca um produto armazenado na base de dados pelo seu identificador
    /// </summary>
    /// <param name="id">Identificador do produto buscada</param>
    /// <returns>Produto encontrado</returns>
    Task<Produto?> BuscarPorIdAsync(int id);
}