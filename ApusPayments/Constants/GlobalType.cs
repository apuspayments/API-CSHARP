namespace ApusPayments.Constants
{
    public class GlobalType
    {
        public const string URL_BASE_DEFAULT = "https://api.ApusPayments.com/v1";

        public const string URL_BASE_SANDBOX = "https://sandbox.ApusPayments.com/v1";

        // POST
        public const string URL_CHECKOUT = "/checkout";

        public const string URL_CHECKOUT_RECURRENT = "/checkout/recurrent";

        public const string URL_CHECKIN = "/checkin";

        // GET
        public const string URL_CHECKOUT_VENDOR = "/checkout/{vendorKey}";

        // DELETE
        public const string URL_CHECKOUT_DELETE = "/checkout/";
    }
}
