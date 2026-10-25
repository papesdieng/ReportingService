using ReportingService.Entities;

namespace ReportingService.Domain.Services
{
    public interface ITradeService
    {
        Task<List<Trade>> GetAllTradesAsync(CancellationToken cancellationToken);
    }
}