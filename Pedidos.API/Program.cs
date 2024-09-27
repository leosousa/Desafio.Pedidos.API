using Pedidos.Infraestrutura.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraDependencies(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseUpdateDatabase();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
