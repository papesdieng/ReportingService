using ReportingService.Domain.Entities;

namespace ReportingService.Application.Services
{
    public interface ITradeService
    {
        Task<List<Trade>> GetAllTradesAsync(CancellationToken cancellationToken);
    }
}