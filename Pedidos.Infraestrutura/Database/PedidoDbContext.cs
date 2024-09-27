using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Entidades;
using System.Reflection;

namespace Pedidos.Infraestrutura.Database;

public class PedidoDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Produto> Produtos { get; set; }

    public DbSet<Pedido> Pedidos { get; set; }

    public DbSet<ItemPedido> ItensPedido { get; set; }

    public PedidoDbContext()
    {
    }

    public PedidoDbContext(DbContextOptions<PedidoDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}