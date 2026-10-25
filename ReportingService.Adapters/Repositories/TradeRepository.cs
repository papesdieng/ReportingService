using Microsoft.EntityFrameworkCore;
using ReportingService.Entities;
using ReportingService.Ports;
using ReportingService.Adapters.Persistence;

namespace ReportingService.Adapters.Repositories
{
    public class TradeRepository(ReportingDbContext context) : ITradeRepository
    {
        public async Task<List<Trade>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Trades.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
