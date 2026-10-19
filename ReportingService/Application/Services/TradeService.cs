using ReportingService.Domain.Entities;
using ReportingService.Domain.Ports;

namespace ReportingService.Application.Services
{

    public class TradeService (ITradeRepository tradeRepository) : ITradeService
    {
        public async Task<List<Trade>> GetAllTradesAsync(CancellationToken cancellationToken)
        {
            return await tradeRepository.GetAllAsync(cancellationToken);
        }
    }
}
