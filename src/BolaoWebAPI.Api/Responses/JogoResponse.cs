namespace BolaoWebAPI.Api.Responses;

public class JogoResponse
{
    public long Id { get; set; }

    public long BolaoId { get; set; }

    public string Numeros { get; set; } = string.Empty;

    public DateTime DataCadastro { get; set; }
}