namespace BolaoWebAPI.Api.Requests
{
    public class ParticipanteUpdateRequest
    {
        public string Nome { get; set; } = string.Empty;

        public string? Telefone { get; set; }

        public string? Email { get; set; }

    }
}
