namespace DevOpsAtividade.Tests;

public class UnitTest1
{
    [Fact]
    public void Soma_DeveRetornarResultadoCorreto()
    {
        int numero1 = 2;
        int numero2 = 3;

        int resultado = numero1 + numero2;

        Assert.Equal(5, resultado);
    }
}