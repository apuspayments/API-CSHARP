using System.Collections.Generic;

namespace ApusPayments.Domain.Response
{
    public class Payment
    {
        public Status status { get; set; }
        public List<PaymentDetail> data { get; set; }
    }
}
