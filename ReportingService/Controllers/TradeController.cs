using Microsoft.AspNetCore.Mvc;
using ReportingService.Application.Services;
using ReportingService.Domain.Entities;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/trades")]
    public class TradeController(ITradeService tradeService) : ControllerBase
    {
     
        [HttpGet]
        public async Task<ActionResult<List<Trade>>> GetAll(CancellationToken cancellationToken)
        {
            var trades = await tradeService.GetAllTradesAsync(cancellationToken);
            return Ok(trades);
        }
    }
}
