public class BolaoDashboardResponse
{
    public long BolaoId { get; set; }

    public string NomeBolao { get; set; } = string.Empty;

    public int QuantidadeParticipantes { get; set; }

    public int QuantidadeJogos { get; set; }

    public int CotasVendidas { get; set; }

    public int CotasDisponiveis { get; set; }

    public decimal ValorArrecadado { get; set; }

    public decimal ValorPendente { get; set; }

    public decimal ValorRecebido { get; set; }
}