using Trader.BussinessProcess.Interfaces;

namespace Trader.BussinessProcess.Parameters
{
    public class CancelOrderParameter : IParameter
    {
        public string Symbol { get; set; }
        public long OrderId { get; set; }
        public string OrigClientOrderId { get; set; }
        public long Timestamp { get; set; }
        public string Type { get; set; }
    }
}
