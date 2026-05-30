namespace BolaoWebAPI.Api.Responses;

public class BolaoResumoResponse
{
    public long BolaoId { get; set; }

    public int TotalCotas { get; set; }

    public int CotasVendidas { get; set; }

    public int CotasDisponiveis { get; set; }

    public decimal ValorTotalPrevisto { get; set; }

    public decimal ValorPago { get; set; }

    public decimal ValorPendente { get; set; }

    public int QuantidadeParticipantes { get; set; }
}