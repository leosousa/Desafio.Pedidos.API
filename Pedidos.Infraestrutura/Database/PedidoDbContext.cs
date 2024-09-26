using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Entidades;
using Pedidos.Infraestrutura.Database.Mapeamento;
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
        //modelBuilder.ApplyConfiguration(new ClienteConfiguracao());
        //modelBuilder.ApplyConfiguration(new ProdutoConfiguracao());
        //modelBuilder.ApplyConfiguration(new PedidoConfiguracao());
        //modelBuilder.ApplyConfiguration(new ItemPedidoConfiguracao());

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=localhost,1433;Database=PedidosDb;User=sa;Password=MyPass@word;TrustServerCertificate=True");

    //}
}