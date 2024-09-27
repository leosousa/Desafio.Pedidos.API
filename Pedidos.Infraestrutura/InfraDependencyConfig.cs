using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pedidos.Infraestrutura.Database;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfraDependencyConfig
{
    public static void AddInfraDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PedidoDbContext>(db =>
            db.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
            ServiceLifetime.Singleton
        );
    }
}