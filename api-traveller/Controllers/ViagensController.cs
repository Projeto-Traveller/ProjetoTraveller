﻿using api_traveller.Database;
using api_traveller.Entidades;
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

        [HttpGet()]
        public IEnumerable<Viagem> GetViagemPorNome()
        {
            return _gulliverContext.Viagens;
        }
    }
}
