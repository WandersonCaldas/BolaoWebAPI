namespace BolaoWebAPI.Api.Responses
{
    public class ParticipanteResponse
    {
        public long Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string? Telefone { get; set; }

        public string? Email { get; set; }

        public bool Ativo { get; set; }
    }
}
