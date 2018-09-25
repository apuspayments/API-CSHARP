using System;

namespace ApusPayments.Domain.Response
{
    public class PaymentDetail
    {
        public Buyer buyer { get; set; }
        public Coin coin { get; set; }
        public Currency currency { get; set; }
        public DateTime date { get; set; }
        public string id { get; set; }
        public Seller seller { get; set; }
        public string txId { get; set; }
    }
}
