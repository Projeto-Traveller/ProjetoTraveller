using Microsoft.AspNetCore.Mvc;
using static api_traveller.Controllers.HoteisController;

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

        [HttpGet]
        public IEnumerable<Hotel> GetTodos()
        {
            return _gulliverContext.Hoteis;
        }

        [HttpGet("PorNome")]
        public IEnumerable<Hotel> GetHotelPorNome(string cidade)
        {
            return _gulliverContext.Hoteis.Where(hotel => hotel.Cidade.ToUpperInvariant().Contains(cidade.ToUpperInvariant()));
        }

        [HttpPost]
        public void PostHotel([FromBody] Hotel hotel)
        {
            _gulliverContext.Hoteis.Add(hotel);
            _gulliverContext.SaveChanges();
        }
    }
}
