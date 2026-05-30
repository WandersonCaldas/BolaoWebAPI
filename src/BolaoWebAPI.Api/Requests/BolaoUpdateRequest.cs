namespace BolaoWebAPI.Api.Requests
{
    public class BolaoUpdateRequest
    {
        public long ModalidadeId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal ValorCota { get; set; }
        public int QuantidadeCotas { get; set; }
        public DateTime DataSorteio { get; set; }
    }
}
