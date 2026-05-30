namespace BolaoWebAPI.Api.Requests
{
    public class ParticipanteCreateRequest
    {
        public string Nome { get; set; } = string.Empty;

        public string? Telefone { get; set; }

        public string? Email { get; set; }
    }
}
