using Microsoft.EntityFrameworkCore;
using ReportingService.Domain.Entities;
using ReportingService.Domain.Ports;
using ReportingService.Infrastructure.Persistence;

namespace ReportingService.Infrastructure.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly ReportingDbContext _context;

        public TradeRepository(ReportingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Trade>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Trades.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
