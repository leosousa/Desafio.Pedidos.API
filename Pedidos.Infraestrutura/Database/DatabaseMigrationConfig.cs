using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Pedidos.Infraestrutura.Database;

public static class DatabaseMigrationConfig
{
    public static void UseUpdateDatabase(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            serviceScope.ServiceProvider.GetService<PedidoDbContext>()?.Database.Migrate();
        }
    }
}
