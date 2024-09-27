using Pedidos.Dominio.Entidades;

namespace Pedidos.Dominio.Contratos;

public interface IClienteRepository
{
    /// <summary>
    /// Cadastra um novo cliente na base de dados
    /// </summary>
    /// <param name="cliente">Cliente a ser cadastrado</param>
    /// <returns>Cliente cadastrado</returns>
    Task<Cliente> CadastrarAsync(Cliente cliente);

    /// <summary>
    /// Atualiza um cliente no banco de dados
    /// </summary>
    /// <param name="cliente">Cliente a ser atualizado</param>
    /// <returns>Cliente atualizado</returns>
    Task<Cliente> EditarAsync(Cliente cliente);

    /// <summary>
    /// Remove um cliente do banco de dados
    /// </summary>
    /// <param name="cliente">Cliente a ser removido</param>
    /// <returns>Retorna se o cliente foi ou não removido</returns>
    Task<bool> RemoverAsync(Cliente cliente);

    /// <summary>
    /// Lista todos os clientes na base de dados
    /// </summary>
    /// <returns>Lista de clientes encontrados</returns>
    Task<IEnumerable<Cliente>> ListarAsync();

    /// <summary>
    /// Busca um cliente armazenado na base de dados pelo seu identificador
    /// </summary>
    /// <param name="id">Identificador do cliente buscada</param>
    /// <returns>Cliente encontrado</returns>
    Task<Cliente?> BuscarPorIdAsync(int id);
}
