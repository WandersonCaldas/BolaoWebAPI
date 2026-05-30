using BolaoWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolaoWebAPI.Infrastructure.Configurations;

public class BolaoParticipanteConfiguration : IEntityTypeConfiguration<BolaoParticipante>
{
    public void Configure(EntityTypeBuilder<BolaoParticipante> builder)
    {
        builder.ToTable("BolaoParticipantes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.QuantidadeCotas)
            .IsRequired();

        builder.Property(x => x.ValorCota)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.ValorTotal)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Pago)
            .IsRequired();

        builder.HasOne<Bolao>()
            .WithMany()
            .HasForeignKey(x => x.BolaoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Participante>()
            .WithMany()
            .HasForeignKey(x => x.ParticipanteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.BolaoId,
            x.ParticipanteId
        }).IsUnique();
    }
}