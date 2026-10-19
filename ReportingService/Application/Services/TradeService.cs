using ReportingService.Domain.Entities;
using ReportingService.Domain.Ports;

namespace ReportingService.Application.Services
{
    public class TradeService
    {
        private readonly ITradeRepository _tradeRepository;

        public TradeService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public Task<List<Trade>> GetAllTradesAsync(CancellationToken cancellationToken)
        {
            return _tradeRepository.GetAllAsync(cancellationToken);
        }
    }
}
