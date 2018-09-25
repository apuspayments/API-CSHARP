namespace ApusPayments.Domain.Request
{
    public class CancelPayment
    {
        /// <summary>
        /// string Required
        /// Transaction identifier in blockchain
        /// </summary>
        public string txId { get; set; }

        /// <summary>
        /// string
        /// SHA256 seller's administrative password (sent by email). Note: case insensitive
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// string Required
        /// Merchant identification, generated through the merchant account on the https://ApusPayments.com
        /// </summary>
        public string vendorKey { get; set; }
    }
}
