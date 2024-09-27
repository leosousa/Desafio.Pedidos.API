using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pedidos.Dominio.Contratos;
using Pedidos.Infraestrutura.Database;
using Pedidos.Infraestrutura.Repositorios;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfraDependencyConfig
{
    public static void AddInfraDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PedidoDbContext>(db =>
            db.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
            ServiceLifetime.Singleton
        );

        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();

    }
}