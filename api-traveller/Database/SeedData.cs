﻿using Microsoft.EntityFrameworkCore;

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
                            Preco = new Random().Next(100, 300)
                        },

                        new Hotel
                        {
                            Id = 2,
                            Cidade = "Sao Paulo",
                            Nome = "West Plaza",
                            Preco = new Random().Next(100, 300)
                        },

                        new Hotel
                        {
                            Id = 3,
                            Cidade = "Sao Paulo",
                            Nome = "Tokyo Drift",
                            Preco = new Random().Next(100, 300)
                        },

                        new Hotel
                        {
                            Id = 4,
                            Cidade = "Sao Paulo",
                            Nome = "International 12",
                            Preco = new Random().Next(100, 300)
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
                        },
                        new Disponibilidade
                        {
                            Id = 12,
                            HotelId = 2,
                            Data = DateTime.Now.AddDays(2),
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
    public partial class ViagensController
    {
        public static class SeedData
        {
            public static void Initialize2(IServiceProvider serviceProvider)
            {
                using (var context = new GulliverContext(serviceProvider.GetRequiredService<DbContextOptions<GulliverContext>>()))
                {
                    if (context.Viagens.Any())
                    {
                        return;
                    }

                    context.Viagens.AddRange
                    (
                        new Viagem
                        {
                            Id = 1,
                            Tipo = "Aviao",
                            Origem = "Sao Paulo",
                            Data = DateTime.Now.AddDays(1),
                            Destino = "Nova York",
                            Preco = new Random().Next(1000, 3000)
                        },
                         new Viagem
                         {
                             Id = 2,
                             Tipo = "Aviao",
                             Origem = "Sao Paulo",
                             Data = DateTime.Now.AddDays(1),
                             Destino = "Mexico",
                             Preco = new Random().Next(1000, 3000)
                         },
                          new Viagem
                          {
                              Id = 3,
                              Tipo = "Aviao",
                              Origem = "Sao Paulo",
                              Data = DateTime.Now.AddDays(1),
                              Destino = "Tokyo",
                              Preco = new Random().Next(1000, 3000)
                          },
                           new Viagem
                           {
                               Id = 4,
                               Tipo = "Onibus",
                               Origem = "Sao Paulo",
                               Data = DateTime.Now.AddDays(1),
                               Destino = "Rio de Janeiro",
                               Preco = new Random().Next(1000, 3000)
                           }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
