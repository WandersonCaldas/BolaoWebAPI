namespace BolaoWebAPI.Api.Requests;

public class BolaoParticipanteCreateRequest
{
    public long BolaoId { get; set; }

    public long ParticipanteId { get; set; }

    public int QuantidadeCotas { get; set; }
}