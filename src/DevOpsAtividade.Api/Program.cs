var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => new
{
    mensagem = "API DevOps funcionando",
    status = "online"
});

app.Run();

public partial class Program { }