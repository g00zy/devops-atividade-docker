using DevOpsAtividade.Api.Services;

namespace DevOpsAtividade.Tests;

public class StatusServiceTests
{
    private readonly StatusService _service = new();

    [Fact]
    public void ObterMensagem_DeveRetornarMensagemDaApi()
    {
        var resultado = _service.ObterMensagem();
        Assert.Equal("API DevOps funcionando", resultado);
    }

    [Fact]
    public void ObterStatus_DeveRetornarOnline()
    {
        var resultado = _service.ObterStatus();
        Assert.Equal("online", resultado);
    }

    [Fact]
    public void ObterHealth_DeveRetornarStatusHealthy()
    {
        var horario = new DateTime(2026, 9, 16, 12, 0, 0,DateTimeKind.Utc);
        var resultado = _service.ObterHealth(horario);
        Assert.Equal("healthy", resultado.Status);
        Assert.Equal(horario, resultado.Timestamp);
    }

    [Fact]
    public void CalcularUptime_DeveRetornarTempoDecorrido()
    {
        var inicio = new DateTime(2026, 9, 16, 10, 0, 0, DateTimeKind.Utc);
        var atual = new DateTime(2026, 9, 16, 10, 30, 0,DateTimeKind.Utc);
        var resultado = _service.CalcularUptime(inicio, atual);
        Assert.Equal(TimeSpan.FromMinutes(30), resultado);
    }

    [Fact]
    public void NormalizarAmbiente_QuandoVazio_DeveRetornarProduction()
    {
        var resultado = _service.NormalizarAmbiente("");
        Assert.Equal("Production", resultado);
    }
}