using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Contratos;
using Pedidos.Dominio.Entidades;
using Pedidos.Infraestrutura.Database;

namespace Pedidos.Infraestrutura.Repositorios;

public class PedidoRepository : IPedidoRepository
{
    private PedidoDbContext _database;

    public PedidoRepository(PedidoDbContext database)
    {
        _database = database;
    }

    public async Task<Pedido?> BuscarPorIdAsync(int id)
    {
        return await _database.Pedidos.Include(p => p.Itens).FirstOrDefaultAsync(task => task.Id == id);
    }

    public async Task<Pedido> CadastrarAsync(Pedido pedido)
    {
        _database.Pedidos.Add(pedido);

        await _database.SaveChangesAsync();

        return pedido;
    }

    public async Task<Pedido> EditarAsync(Pedido pedido)
    {
        _database.Pedidos.Update(pedido);

        await _database.SaveChangesAsync();

        return pedido;
    }

    public async Task<IEnumerable<Pedido>> ListarAsync()
    {
        return await _database.Pedidos.ToListAsync();
    }

    public async Task<bool> RemoverAsync(Pedido pedido)
    {
        _database.Pedidos.Remove(pedido);

        var affectedRows = await _database.SaveChangesAsync();

        return (affectedRows >= 1);
    }
}
