namespace BolaoWebAPI.Api.Requests;

public class JogoCreateRequest
{
    public long BolaoId { get; set; }

    public string Numeros { get; set; } = string.Empty;
}