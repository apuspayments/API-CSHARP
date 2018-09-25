namespace ApusPayments.Domain.Response
{
    public class Checkout
    {
        public Status status { get; set; }
        public Transaction transaction { get; set; }
        public Coin coin { get; set; }
        public Schedule schedule { get; set; }
        public Currency currency { get; set; }
    }
}
