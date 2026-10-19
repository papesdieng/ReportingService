using Microsoft.EntityFrameworkCore;
using ReportingService.Domain.Entities;
using ReportingService.Domain.Ports;
using ReportingService.Infrastructure.Persistence;

namespace ReportingService.Infrastructure.Repositories
{
    public class TradeRepository(ReportingDbContext context) : ITradeRepository
    {
        public async Task<List<Trade>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Trades.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
