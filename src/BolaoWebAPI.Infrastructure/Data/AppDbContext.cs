using BolaoWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoWebAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Bolao> Boloes { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<BolaoParticipante> BolaoParticipantes { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Resultado> Resultados { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("bolao");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
