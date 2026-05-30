namespace BolaoWebAPI.Domain.Entities;

public class Modalidade
{
    public long Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public int QuantidadeMinimaNumeros { get; set; }

    public int QuantidadeMaximaNumeros { get; set; }

    public int NumeroMinimo { get; set; }

    public int NumeroMaximo { get; set; }

    public bool Ativo { get; set; } = true;
}