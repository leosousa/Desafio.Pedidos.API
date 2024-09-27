using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Contratos;
using Pedidos.Dominio.Entidades;
using Pedidos.Infraestrutura.Database;

namespace Pedidos.Infraestrutura.Repositorios;

public class ClienteRepository : IClienteRepository
{
    private PedidoDbContext _database;

    public ClienteRepository(PedidoDbContext database)
    {
        _database = database;
    }

    public async Task<Cliente?> BuscarPorIdAsync(int id)
    {
        return await _database.Clientes.FirstOrDefaultAsync(task => task.Id == id);
    }

    public async Task<Cliente> CadastrarAsync(Cliente cliente)
    {
        _database.Clientes.Add(cliente);

        await _database.SaveChangesAsync();

        return cliente;
    }

    public async Task<Cliente> EditarAsync(Cliente cliente)
    {
        _database.Clientes.Update(cliente);

        await _database.SaveChangesAsync();

        return cliente;
    }

    public async Task<IEnumerable<Cliente>> ListarAsync()
    {
        return await _database.Clientes.ToListAsync();
    }

    public async Task<bool> RemoverAsync(Cliente cliente)
    {
        _database.Clientes.Remove(cliente);

        var affectedRows = await _database.SaveChangesAsync();

        return (affectedRows >= 1);
    }
}
