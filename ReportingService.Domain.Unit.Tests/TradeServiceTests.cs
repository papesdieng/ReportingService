using NSubstitute;
using ReportingService.Domain.Services;
using ReportingService.Entities;
using ReportingService.Ports;
using TUnit.Assertions;
using TUnit.Core;

namespace ReportingService.Domain.Unit.Tests;

public class TradeServiceTests
{
    [Test]
    public async Task GetAllTradesAsync_ReturnsTradesFromRepository()
    {
        using var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;
        var expectedTrades = new List<Trade>
        {
            new()
            {
                Id = 42,
                Price = 125.50m,
                Currency = "XOF",
                TraderName = "Pape DIENG",
                TradeDate = new DateTime(2026, 1, 15),
                MaturityDate = new DateTime(2027, 1, 15)
            }
        };
        var tradeRepository = Substitute.For<ITradeRepository>();
        tradeRepository.GetAllAsync(cancellationToken).Returns(expectedTrades);
        var tradeService = new TradeService(tradeRepository);

        var result = await tradeService.GetAllTradesAsync(cancellationToken);

        await Assert.That(result.Count).IsEqualTo(1);
        await Assert.That(result[0].Id).IsEqualTo(42);
        await Assert.That(result[0].Price).IsEqualTo(125.50m);
        await Assert.That(result[0].Currency).IsEqualTo("XOF");
        await Assert.That(result[0].TraderName).IsEqualTo("Pape DIENG");
        await tradeRepository.Received(1).GetAllAsync(cancellationToken);
    }
}
