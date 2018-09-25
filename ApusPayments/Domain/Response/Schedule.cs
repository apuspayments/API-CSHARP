namespace ApusPayments.Domain.Response
{
    public class Schedule
    {
        public string period { get; set; }
        public int frequency { get; set; }
        public bool execute { get; set; }
        public string id { get; set; }
    }
}
