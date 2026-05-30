using BolaoWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolaoWebAPI.Infrastructure.Configurations;

public class ModalidadeConfiguration : IEntityTypeConfiguration<Modalidade>
{
    public void Configure(EntityTypeBuilder<Modalidade> builder)
    {
        builder.ToTable("Modalidades");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.QuantidadeMinimaNumeros)
            .IsRequired();

        builder.Property(x => x.QuantidadeMaximaNumeros)
            .IsRequired();

        builder.Property(x => x.NumeroMinimo)
            .IsRequired();

        builder.Property(x => x.NumeroMaximo)
            .IsRequired();

        builder.Property(x => x.Ativo)
            .IsRequired();
    }
}