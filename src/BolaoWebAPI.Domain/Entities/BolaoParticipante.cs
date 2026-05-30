namespace BolaoWebAPI.Domain.Entities;

public class BolaoParticipante
{
    public long Id { get; set; }

    public long BolaoId { get; set; }

    public long ParticipanteId { get; set; }

    public int QuantidadeCotas { get; set; }

    public decimal ValorCota { get; set; }

    public decimal ValorTotal { get; set; }

    public bool Pago { get; set; } = false;
}