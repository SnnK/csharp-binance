using System.Collections.Generic;

namespace Trader.Service.Models
{
    public class ErrorModel
    {
        public ErrorModel()
        {
            this.Errors = new List<string>();
        }

        public List<string> Errors { get; set; }
    }
}
