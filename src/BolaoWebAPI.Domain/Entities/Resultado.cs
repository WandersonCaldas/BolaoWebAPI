namespace BolaoWebAPI.Domain.Entities;

public class Resultado
{
    public long Id { get; set; }

    public long BolaoId { get; set; }

    public string NumerosSorteados { get; set; } = string.Empty;

    public DateTime DataResultado { get; set; } = DateTime.Now;
}