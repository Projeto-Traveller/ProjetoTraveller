using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return _gulliverContext.Hoteis.Where(hotel => hotel.Cidade.ToUpperInvariant().Contains(cidade.ToUpperInvariant()));
        }

        [HttpPost]
        public void PostHotel([FromBody]Disponibilidade disponibilidade)
        {
            _gulliverContext.Disponibilidades.Add(disponibilidade);
            _gulliverContext.SaveChanges();
        }
    }
}
