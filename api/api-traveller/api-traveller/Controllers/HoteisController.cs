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

        [HttpGet("PorHotel")]
        public IEnumerable<Disponibilidade> GetDisponibilidade(int hotelId)
        {
            return _gulliverContext.Disponibilidades.Where(hotel => hotel.HotelId == hotelId);
        }

        [HttpPost]
        public void PostHotel([FromBody]Disponibilidade disponibilidade)
        {
            _gulliverContext.Disponibilidades.Add(disponibilidade);
            _gulliverContext.SaveChanges();
        }
    }
}
