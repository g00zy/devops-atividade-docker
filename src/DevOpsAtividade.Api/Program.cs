using DevOpsAtividade.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var statusService = new StatusService();
var horarioInicial = DateTime.UtcNow;

app.MapGet("/", () => new
{
    mensagem = statusService.ObterMensagem(),
    status = statusService.ObterStatus()
});

app.MapGet("/health", () =>
{
    var health = statusService.ObterHealth(DateTime.UtcNow);

    return new
    {
        status = health.Status,
        timestamp = health.Timestamp
    };
});

app.MapGet("/info", () => new
{
    ambiente = statusService.NormalizarAmbiente(
        app.Environment.EnvironmentName
    ),
    uptimeSegundos = statusService
        .CalcularUptime(horarioInicial, DateTime.UtcNow)
        .TotalSeconds
});

app.Run();

public partial class Program { }