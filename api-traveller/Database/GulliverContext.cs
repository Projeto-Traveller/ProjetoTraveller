using api_traveller.Entidades;
using Microsoft.EntityFrameworkCore;

namespace api_traveller.Database
{
    public class GulliverContext : DbContext
    {
        public GulliverContext(DbContextOptions<GulliverContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

        public DbSet<Hotel> Hoteis { get; set; }
        public DbSet<Disponibilidade> Disponibilidades { get; set; }
        public DbSet<Viagem> Viagens { get; set; }
    }
}