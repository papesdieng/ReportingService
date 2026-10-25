using ReportingService.Entities;
using ReportingService.Ports;

namespace ReportingService.Domain.Services
{

    public class TradeService(ITradeRepository tradeRepository) : ITradeService
    {
        public async Task<List<Trade>> GetAllTradesAsync(CancellationToken cancellationToken)
        {
            return await tradeRepository.GetAllAsync(cancellationToken);
        }
    }
}
