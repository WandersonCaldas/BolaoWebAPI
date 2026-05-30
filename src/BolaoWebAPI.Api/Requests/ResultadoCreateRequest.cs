namespace BolaoWebAPI.Api.Requests;

public class ResultadoCreateRequest
{
    public long BolaoId { get; set; }

    public string NumerosSorteados { get; set; } = string.Empty;
}