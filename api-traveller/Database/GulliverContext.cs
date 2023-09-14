using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using static api_traveller.Controllers.HoteisController;
using static api_traveller.Controllers.ViagensController;

namespace api_traveller.Controllers;

public partial class HoteisController
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
    }
}

public partial class ViagensController
{
    public class GulliverContext : DbContext
    {

        public GulliverContext(DbContextOptions<GulliverContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

        public DbSet<Viagem> Viagens { get; set; }
    }
}
