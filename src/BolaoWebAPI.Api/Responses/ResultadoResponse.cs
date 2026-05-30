namespace BolaoWebAPI.Api.Responses;

public class ResultadoResponse
{
    public long Id { get; set; }

    public long BolaoId { get; set; }

    public string NumerosSorteados { get; set; } = string.Empty;

    public DateTime DataResultado { get; set; }
}