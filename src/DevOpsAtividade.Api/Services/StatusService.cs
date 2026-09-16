namespace DevOpsAtividade.Api.Services;

public class StatusService
{
    public string ObterMensagem()
    {
        return "API DevOps funcionando";
    }

    public string ObterStatus()
    {
        return "online";
    }

    public HealthResult ObterHealth(DateTime horarioAtualUtc)
    {
        return new HealthResult("healthy",horarioAtualUtc);
    }

    public TimeSpan CalcularUptime(DateTime horarioInicial, DateTime horarioAtual)
    {
        if (horarioAtual < horarioInicial)
        {
            throw new ArgumentException("O horário atual não pode ser anterior ao horário inicial.");
        }

        return horarioAtual - horarioInicial;
    }

    public string NormalizarAmbiente(string? ambiente)
    {
        if (string.IsNullOrWhiteSpace(ambiente))
        {
            return "Production";
        }

        return ambiente.Trim();
    }
}

public record HealthResult(string Status, DateTime Timestamp);