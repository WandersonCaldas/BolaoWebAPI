namespace BolaoWebAPI.Domain.Entities;

public class Jogo
{
    public long Id { get; set; }

    public long BolaoId { get; set; }

    public string Numeros { get; set; } = string.Empty;

    public DateTime DataCadastro { get; set; } = DateTime.Now;
}