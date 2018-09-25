namespace ApusPayments.Domain.Response
{
    public class Transaction
    {
        public string txId { get; set; }
        public long timestamp { get; set; }
        public string buyer { get; set; }
    }
}
