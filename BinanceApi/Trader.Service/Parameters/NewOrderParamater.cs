using Trader.Service.Interfaces;

namespace Trader.Service.Parameters
{
    public class NewOrderParamater : IParameter
    {
        public string Symbol { get; set; }
        public string Side { get; set; }
        public string Type { get; set; }
        public string TimeInForce { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal StopPrice { get; set; }
        public decimal IcebergQty { get; set; }
        public long Timestamp { get; set; }
    }
}
