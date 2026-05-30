using BolaoWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolaoWebAPI.Infrastructure.Configurations;

public class ResultadoConfiguration : IEntityTypeConfiguration<Resultado>
{
    public void Configure(EntityTypeBuilder<Resultado> builder)
    {
        builder.ToTable("Resultados");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NumerosSorteados)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.DataResultado)
            .IsRequired();

        builder.HasOne<Bolao>()
            .WithMany()
            .HasForeignKey(x => x.BolaoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}