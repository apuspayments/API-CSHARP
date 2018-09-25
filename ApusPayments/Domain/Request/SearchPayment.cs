using System;

namespace ApusPayments.Domain.Request
{
    [Serializable]
    public class SearchPayment
    {
        /// <summary>
        /// string Required
        /// Merchant identification, generated through the merchant account on the https://ApusPayments.com
        /// </summary>
        public string vendorKey { get; set; }

        /// <summary>
        /// string
        /// Transaction identifier
        /// </summary>
        public string txId { get; set; }

        /// <summary>
        /// string Required
        /// Date in timestamp format
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// string Required
        /// Payment blockchain identifier
        /// </summary>
        public string blockchain { get; set; }

        /// <summary>
        /// string
        /// Currency symbol
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// string Required
        /// Amount in the crypto format
        /// </summary>
        public string coinAmount { get; set; }

        /// <summary>
        /// string Required
        /// Amount in the currency format
        /// </summary>
        public string currencyAmount { get; set; }

        /// <summary>
        /// string
        /// Buyer identifier
        /// </summary>
        public string buyer { get; set; }
    }
}
