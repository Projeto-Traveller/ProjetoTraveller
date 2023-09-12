using Microsoft.EntityFrameworkCore;

namespace api_traveller.Controllers
{
    public partial class HoteisController
    {
        public static class SeedData
        {
            public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new GulliverContext(serviceProvider.GetRequiredService<DbContextOptions<GulliverContext>>()))
                {
                    if (context.Hoteis.Any())
                    {
                        return;
                    }

                    context.Hoteis.AddRange
                    (
                        new Hotel
                        {
                            Id = 1,
                            Cidade = "Sao Paulo",
                            Nome = "Ibis",
                        },

                        new Hotel
                        {
                            Id = 2,
                            Cidade = "Sao Paulo",
                            Nome = "West Plaza",
                        }

                    );

                    context.SaveChanges();

                    context.Disponibilidades.AddRange
                    (
                        new Disponibilidade
                        {
                            Id = 11,
                            HotelId = 1,
                            Data = DateTime.Now.AddDays(1),
                            Preco = new Random().Next(100, 300)
                        },
                        new Disponibilidade
                        {
                            Id = 12,
                            HotelId = 2,
                            Data = DateTime.Now.AddDays(2),
                            Preco = new Random().Next(100, 300)
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
