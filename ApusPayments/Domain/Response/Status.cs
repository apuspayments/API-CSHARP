using System.Collections.Generic;

namespace ApusPayments.Domain.Response
{
    public class Status
    {
        public string code { get; set; }
        public string message { get; set; }
        public List<Details> details { get; set; }
    }
}
