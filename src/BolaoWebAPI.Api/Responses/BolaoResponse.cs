namespace BolaoWebAPI.Api.Responses
{
    public class BolaoResponse
    {
        public long Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string? Descricao { get; set; }

        public decimal ValorCota { get; set; }

        public int QuantidadeCotas { get; set; }

        public DateTime DataSorteio { get; set; }

        public bool Ativo { get; set; }
    }
}
