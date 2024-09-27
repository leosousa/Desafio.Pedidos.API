using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Contratos;
using Pedidos.Dominio.Entidades;
using Pedidos.Infraestrutura.Database;

namespace Pedidos.Infraestrutura.Repositorios;

public sealed class ProdutoRepository : IProdutoRepository
{
    private PedidoDbContext _database;

    public ProdutoRepository(PedidoDbContext database)
    {
        _database = database;
    }

    public async Task<Produto?> BuscarPorIdAsync(int id)
    {
        return await _database.Produtos.FirstOrDefaultAsync(task => task.Id == id);
    }

    public async Task<Produto> CadastrarAsync(Produto produto)
    {
        _database.Produtos.Add(produto);

        await _database.SaveChangesAsync();

        return produto;
    }

    public async Task<Produto> EditarAsync(Produto produto)
    {
        _database.Produtos.Update(produto);

        await _database.SaveChangesAsync();

        return produto;
    }

    public async Task<IEnumerable<Produto>> ListarAsync()
    {
        return await _database.Produtos.ToListAsync();
    }

    public async Task<bool> RemoverAsync(Produto produto)
    {
        _database.Produtos.Remove(produto);

        var affectedRows = await _database.SaveChangesAsync();

        return (affectedRows >= 1);
    }
}