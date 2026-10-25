using System.Collections.Generic;
using System.Threading.Tasks;
using ReportingService.Entities;

namespace ReportingService.Ports
{
    public interface ITradeRepository
    {
        Task<List<Trade>> GetAllAsync(CancellationToken cancellationToken);
        // Additional repository methods (Add, Update, Delete) can be added later
    }
}
