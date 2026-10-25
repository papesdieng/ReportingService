using System;

namespace ReportingService.Entities
{
    public class Trade
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string TraderName { get; set; } = string.Empty;
        public DateTime TradeDate { get; set; }
        public DateTime MaturityDate { get; set; }
    }
}
