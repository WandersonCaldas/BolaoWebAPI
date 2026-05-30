namespace BolaoWebAPI.Api.Requests;

public class ModalidadeUpdateRequest
{
    public string Nome { get; set; } = string.Empty;

    public int QuantidadeMinimaNumeros { get; set; }

    public int QuantidadeMaximaNumeros { get; set; }

    public int NumeroMinimo { get; set; }

    public int NumeroMaximo { get; set; }
}