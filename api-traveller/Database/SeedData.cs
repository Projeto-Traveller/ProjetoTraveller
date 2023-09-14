using api_traveller.Entidades;
using Microsoft.EntityFrameworkCore;

namespace api_traveller.Database
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
                        Preco = new Random().Next(100, 300),
                        Source = "https://s3.amazonaws.com/assets.stg-apoiase.link/no-image.jpg"
                    },

                    new Hotel
                    {
                        Id = 2,
                        Cidade = "Sao Paulo",
                        Nome = "West Plaza",
                        Preco = new Random().Next(100, 300),
                        Source = "https://s3.amazonaws.com/assets.stg-apoiase.link/no-image.jpg"
                    },

                    new Hotel
                    {
                        Id = 3,
                        Cidade = "Sao Paulo",
                        Nome = "Tokyo Drift",
                        Preco = new Random().Next(100, 300),
                        Source = "https://s3.amazonaws.com/assets.stg-apoiase.link/no-image.jpg"
                    },

                    new Hotel
                    {
                        Id = 4,
                        Cidade = "Sao Paulo",
                        Nome = "International 12",
                        Preco = new Random().Next(100, 300),
                        Source = "https://s3.amazonaws.com/assets.stg-apoiase.link/no-image.jpg"
                    },

                    new Hotel
                    {
                        Id = 5,
                        Cidade = "Atibaia",
                        Nome = "Taua Resort",
                        Source = "https://d18m3re1tsq8hv.cloudfront.net/wp-content/uploads/2020/02/viajar-resorts-area-externa-taua-hotel-atibaia-05.jpg",
                        Preco = new Random().Next(100, 300)
                    },

                    new Hotel
                    {
                        Id = 6,
                        Cidade = "Atibaia",
                        Nome = "Bourbon",
                        Source = "https://viajeseumundo.com/wp-content/uploads/2019/04/hotel-bourbon-atibaia-all-inclusive.jpg",
                        Preco = new Random().Next(100, 300)
                    },

                    new Hotel
                    {
                        Id = 7,
                        Cidade = "Atibaia",
                        Nome = "Eldorado",
                        Source = "https://cdn.panrotas.com.br/portal-panrotas-statics/media-files-cache/317322/90839c16ae77de8e0db976a02da35c92eldoradoatibaiaaerea2/0,68,1920,1146/1206,720,0.35/0/default.jpg",
                        Preco = new Random().Next(100, 300)
                    },

                    new Hotel
                    {
                        Id = 8,
                        Cidade = "Atibaia",
                        Nome = "Residence Resort",
                        Source = "https://s2-g1.glbimg.com/CWeltAPgWjOSb4DkegW83pnq904=/0x0:5760x3840/1008x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_59edd422c0c84a879bd37670ae4f538a/internal_photos/bs/2019/m/A/O4IR53QBSnn8ue1ffSxA/k9a3001.jpg",
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