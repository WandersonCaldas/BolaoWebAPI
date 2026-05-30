namespace BolaoWebAPI.Api.Responses;

public class ConferenciaJogoResponse
{
    public long JogoId { get; set; }

    public string NumerosJogo { get; set; } = string.Empty;

    public string NumerosSorteados { get; set; } = string.Empty;

    public List<string> NumerosAcertados { get; set; } = new();

    public int QuantidadeAcertos { get; set; }
}