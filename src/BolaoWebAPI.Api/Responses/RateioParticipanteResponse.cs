namespace BolaoWebAPI.Api.Responses;

public class RateioParticipanteResponse
{
    public long ParticipanteId { get; set; }

    public string NomeParticipante { get; set; } = string.Empty;

    public int QuantidadeCotas { get; set; }

    public decimal PercentualParticipacao { get; set; }

    public decimal ValorPremio { get; set; }
}