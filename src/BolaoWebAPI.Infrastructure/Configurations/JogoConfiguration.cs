using BolaoWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolaoWebAPI.Infrastructure.Configurations;

public class JogoConfiguration : IEntityTypeConfiguration<Jogo>
{
    public void Configure(EntityTypeBuilder<Jogo> builder)
    {
        builder.ToTable("Jogos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Numeros)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.DataCadastro)
            .IsRequired();

        builder.HasOne<Bolao>()
            .WithMany()
            .HasForeignKey(x => x.BolaoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}