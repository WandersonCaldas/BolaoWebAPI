namespace BolaoWebAPI.Api.Responses;

public class RateioResponse
{
    public long BolaoId { get; set; }

    public string NomeBolao { get; set; } = string.Empty;

    public decimal ValorPremioTotal { get; set; }

    public int TotalCotas { get; set; }

    public List<RateioParticipanteResponse> Participantes { get; set; } = new();
}