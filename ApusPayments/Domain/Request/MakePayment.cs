using System;

namespace ApusPayments.Domain.Request
{
    [Serializable]
    public class MakePayment
    {
        /// <summary>
        /// string Required
        /// SHA256 card number.Note: case insensitive
        /// </summary>
        public string pan { get; set; }

        /// <summary>
        /// string Required
        /// SHA256 card password (sent by email). Note: case insensitive
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// string Required
        /// Valid values: "BTC" "DCR" "ETH" "LTC"
        /// It defines which cryptocurrency the transaction will use, 
        /// this determines in which blockchain the transaction will be registered
        /// </summary>
        public string blockchain { get; set; }

        /// <summary>
        /// number<double> Required
        /// Amount to be transferred, the currency used is defined in the "currency" property
        /// </summary>
        public double amount { get; set; }

        /// <summary>
        /// string Required
        /// Valid values: "BLR" "CAD" "CNY" "EUR" "JPY" "USD"
        /// Symbol of the currency used in the transfer, the amount is defined in the property "amount"
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// string Required
        /// Merchant identification, generated through the merchant account on the https://ApusPayments.com
        /// </summary>
        public string vendorKey { get; set; }
    }
}
