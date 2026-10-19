using Microsoft.AspNetCore.Mvc;
using ReportingService.Application.Services;
using ReportingService.Domain.Entities;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/trades")]
    public class TradeController : ControllerBase
    {
        private readonly TradeService _tradeService;

        public TradeController(TradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Trade>>> GetAll(CancellationToken cancellationToken)
        {
            var trades = await _tradeService.GetAllTradesAsync(cancellationToken);
            return Ok(trades);
        }
    }
}
