using api_traveller.Database;
using api_traveller.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace api_traveller.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class HoteisController : ControllerBase
    {
        private readonly ILogger<HoteisController> _logger;

        private readonly GulliverContext _gulliverContext;

        public HoteisController(ILogger<HoteisController> logger, GulliverContext gulliverContext)
        {
            _logger = logger;
            _gulliverContext = gulliverContext;
        }

        [HttpGet("PorNome")]
        public IEnumerable<Hotel> GetHotelPorNome(string cidade)
        {
            var hoteis = _gulliverContext.Hoteis.Where(hotel => hotel.Cidade.ToUpperInvariant().Contains(cidade.ToUpperInvariant()));

            if(!hoteis.Any())
            {
                var emptyHotel = new Hotel
                {
                    Cidade = cidade,
                    Nome = "Não Disponivel",
                    Preco = 0,
                    Source = "https://s3.amazonaws.com/assets.stg-apoiase.link/no-image.jpg"
                };

                return new List<Hotel> { emptyHotel, emptyHotel,emptyHotel,emptyHotel };
            }

            return hoteis;
        }

        [HttpPost]
        public void PostHotel([FromBody]Disponibilidade disponibilidade)
        {
            _gulliverContext.Disponibilidades.Add(disponibilidade);
            _gulliverContext.SaveChanges();
        }
    }
}
