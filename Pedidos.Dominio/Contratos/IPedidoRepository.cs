using Pedidos.Dominio.Entidades;

namespace Pedidos.Dominio.Contratos;

public interface IPedidoRepository
{
    /// <summary>
    /// Cadastra um novo pedido na base de dados
    /// </summary>
    /// <param name="pedido">Pedido a ser cadastrado</param>
    /// <returns>Pedido cadastrado</returns>
    Task<Pedido> CadastrarAsync(Pedido pedido);

    /// <summary>
    /// Atualiza um pedido no banco de dados
    /// </summary>
    /// <param name="pedido">Pedido a ser atualizado</param>
    /// <returns>Pedido atualizado</returns>
    Task<Pedido> EditarAsync(Pedido pedido);

    /// <summary>
    /// Remove um pedido do banco de dados
    /// </summary>
    /// <param name="pedido">Pedido a ser removido</param>
    /// <returns>Retorna se o pedido foi ou não removido</returns>
    Task<bool> RemoverAsync(Pedido pedido);

    /// <summary>
    /// Lista todos os pedidos na base de dados
    /// </summary>
    /// <returns>Lista de pedidos encontrados</returns>
    Task<IEnumerable<Pedido>> ListarAsync();

    /// <summary>
    /// Busca um pedido armazenado na base de dados pelo seu identificador
    /// </summary>
    /// <param name="id">Identificador do pedido buscada</param>
    /// <returns>Pedido encontrado</returns>
    Task<Pedido?> BuscarPorIdAsync(int id);
}
