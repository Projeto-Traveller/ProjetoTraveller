using api_traveller.Database;
using api_traveller.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace api_traveller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class DisponibilidadeController : ControllerBase
    {
        private readonly ILogger<DisponibilidadeController> _logger;

        private readonly GulliverContext _gulliverContext;

        public DisponibilidadeController(ILogger<DisponibilidadeController> logger, GulliverContext gulliverContext)
        {
            _logger = logger;
            _gulliverContext = gulliverContext;
        }

        [HttpGet("PorHotel")]
        public IEnumerable<Disponibilidade> GetDisponibilidade(int hotelId)
        {
            return _gulliverContext.Disponibilidades.Where(hotel => hotel.HotelId == hotelId);
        }

        [HttpGet]
        public IEnumerable<Hotel> GetTodos()
        {
            return _gulliverContext.Hoteis;
        }

        [HttpPost]
        public void PostHotel([FromBody] Hotel hotel)
        {
            _gulliverContext.Hoteis.Add(hotel);
            _gulliverContext.SaveChanges();
        }
    }
}

