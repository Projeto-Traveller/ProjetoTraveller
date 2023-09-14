using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_traveller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ViagensController : ControllerBase
    {
        private readonly ILogger<HoteisController> _logger;

        private readonly GulliverContext _gulliverContext;

        public ViagensController(ILogger<HoteisController> logger, GulliverContext gulliverContext)
        {
            _logger = logger;
            _gulliverContext = gulliverContext;
        }

        [HttpGet("PorNome")]
        public IEnumerable<Viagem> GetViagemPorNome(string origem)
        {
            return _gulliverContext.Viagens.Where(viagem => viagem.Origem.ToUpperInvariant().Contains(origem.ToUpperInvariant()));
        }
    }
}
