using BolaoWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoWebAPI.Infrastructure.Configurations
{
    public class BolaoConfiguration : IEntityTypeConfiguration<Bolao>
    {
        public void Configure(EntityTypeBuilder<Bolao> builder)
        {
            builder.ToTable("Boloes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasMaxLength(500);

            builder.Property(x => x.ValorCota)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.QuantidadeCotas)
                .IsRequired();

            builder.Property(x => x.DataSorteio)
                .IsRequired();

            builder.Property(x => x.Ativo)
                .IsRequired();
        }
    }
}
