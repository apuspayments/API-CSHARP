using ApusPayments.Constants;
using ApusPayments.Domain.Request;
using ApusPayments.Domain.Response;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace ApusPayments.Controller
{
    public class ApusPaymentsAPI
    {
        #region [ Properties ]

        public bool SandBox { get; set; }

        #endregion

        #region [ Constructor ]

        public ApusPaymentsAPI()
        {
            this.SandBox = false;
        }

        public ApusPaymentsAPI(EnviromentType sandBox)
        {
            if (sandBox == EnviromentType.SandBox)
                this.SandBox = true;
            else
                this.SandBox = false;
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Make a payment
        /// It is with this resource that we carry out our purchases. 
        /// The checkout resource is used when we want to make a payment from A (buyer) to B (seller) and its validation depends on the stimulus of A.
        /// A checkout has a monetary value in currency (value), acronym for currency (currency), blockchain for transaction (blockchain), 
        /// card number (pan), card password (password) and vendor identifier (vendorKey)
        /// </summary>
        /// <param name="makePayment"></param>
        /// <returns>Checkout</returns>
        public Checkout MakePayment(MakePayment makePayment)
        {
            try
            {
                string urlBase = this.SandBox ? GlobalType.URL_BASE_SANDBOX : GlobalType.URL_BASE_DEFAULT;

                string strJson = JsonConvert.SerializeObject(makePayment);

                byte[] buffer = Encoding.UTF8.GetBytes(strJson);

                HttpWebRequest httpWebRequest = HttpWebRequest.CreateHttp(urlBase + GlobalType.URL_CHECKOUT);
                httpWebRequest.Method = "POST";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.ContentLength = buffer.Length;
                httpWebRequest.GetRequestStream().Write(buffer, 0, buffer.Length);

                using (HttpWebResponse objResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader strReader = new StreamReader(objResponse.GetResponseStream()))
                        return JsonConvert.DeserializeObject<Checkout>(strReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                return new Checkout() { status = new Status() { code = "-1", message = ex.Message } };
            }
        }

        /// <summary>
        /// Make a recurring payment
        /// It is with this resource that we carry out our purchases on a recurring basis. 
        /// The checkout resource is used when we want to make a payment or schedule a recurring payment from A (buyer) to B (seller).
        /// A checkout has a monetary value in currency (value), acronym for currency (currency), blockchain for transaction (blockchain),
        /// card number (pan), card password (password), period for execution (period), a frequency in numeral (frequency),
        /// a boolean to execute or not the payment at the time (execute) and a vendor identifier (vendorKey)
        /// </summary>
        /// <param name="makeRecurringPayment"></param>
        /// <returns>Checkout</returns>
        public Checkout MakeRecurringPayment(MakeRecurringPayment makeRecurringPayment)
        {
            try
            {
                string urlBase = this.SandBox ? GlobalType.URL_BASE_SANDBOX : GlobalType.URL_BASE_DEFAULT;

                string strJson = JsonConvert.SerializeObject(makeRecurringPayment);

                byte[] buffer = Encoding.UTF8.GetBytes(strJson);

                HttpWebRequest httpWebRequest = HttpWebRequest.CreateHttp(urlBase + GlobalType.URL_CHECKOUT_RECURRENT);
                httpWebRequest.Method = "POST";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.ContentLength = buffer.Length;
                httpWebRequest.GetRequestStream().Write(buffer, 0, buffer.Length);

                using (HttpWebResponse objResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader strReader = new StreamReader(objResponse.GetResponseStream()))
                        return JsonConvert.DeserializeObject<Checkout>(strReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                return new Checkout() { status = new Status() { code = "-1", message = ex.Message } };
            }
        }

        /// <summary>
        /// Search payments
        /// Feature used to consult payments through the available filters
        /// </summary>
        /// <param name="searchPayment"></param>
        /// <returns>Payment</returns>
        public Payment SearchPayment(SearchPayment searchPayment)
        {
            try
            {
                string urlBase = this.SandBox ? GlobalType.URL_BASE_SANDBOX : GlobalType.URL_BASE_DEFAULT;

                urlBase += GlobalType.URL_CHECKOUT_VENDOR.Replace("{vendorKey}", searchPayment.vendorKey) + "?";

                if (!string.IsNullOrWhiteSpace(searchPayment.txId))
                    urlBase += "&txId=" + searchPayment.txId;

                if (!string.IsNullOrWhiteSpace(searchPayment.timestamp))
                    urlBase += "&timestamp=" + searchPayment.timestamp;

                if (!string.IsNullOrWhiteSpace(searchPayment.blockchain))
                    urlBase += "&blockchain=" + searchPayment.blockchain;

                if (!string.IsNullOrWhiteSpace(searchPayment.currency))
                    urlBase += "&currency=" + searchPayment.currency;

                if (!string.IsNullOrWhiteSpace(searchPayment.coinAmount))
                    urlBase += "&coinAmount=" + searchPayment.coinAmount;

                if (!string.IsNullOrWhiteSpace(searchPayment.currencyAmount))
                    urlBase += "&currencyAmount=" + searchPayment.currencyAmount;

                if (!string.IsNullOrWhiteSpace(searchPayment.buyer))
                    urlBase += "&buyer=" + searchPayment.buyer;

                HttpWebRequest httpWebRequest = HttpWebRequest.CreateHttp(urlBase);
                httpWebRequest.Method = "GET";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.ContentType = "application/json";

                using (HttpWebResponse objResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader strReader = new StreamReader(objResponse.GetResponseStream()))
                        return JsonConvert.DeserializeObject<Payment>(strReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                return new Payment() { status = new Status() { code = "-1", message = ex.Message } };
            }
        }

        /// <summary>
        /// Cancel a payment
        /// It is with this resource that we cancel a payment. 
        /// The feature is used when we want to make a payment cancellation (charge-back) 
        /// by performing the reverse transaction of the same type previously sent from A (seller) to B(buyer). 
        /// A checkout cancellation has a transaction identifier(txId), 
        /// seller's administrative password (password) and a vendor identifier (vendorKey)
        /// </summary>
        /// <param name="cancelPayment"></param>
        /// <returns></returns>
        public Checkout CancelPayment(CancelPayment cancelPayment)
        {
            try
            {
                string urlBase = this.SandBox ? GlobalType.URL_BASE_SANDBOX : GlobalType.URL_BASE_DEFAULT;

                string strJson = JsonConvert.SerializeObject(cancelPayment);

                byte[] buffer = Encoding.UTF8.GetBytes(strJson);

                HttpWebRequest httpWebRequest = HttpWebRequest.CreateHttp(urlBase + GlobalType.URL_CHECKOUT_DELETE);
                httpWebRequest.Method = "DELETE";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.ContentLength = buffer.Length;
                httpWebRequest.GetRequestStream().Write(buffer, 0, buffer.Length);

                using (HttpWebResponse objResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader strReader = new StreamReader(objResponse.GetResponseStream()))
                        return JsonConvert.DeserializeObject<Checkout>(strReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                return new Checkout() { status = new Status() { code = "-1", message = ex.Message } };
            }
        }

        /// <summary>
        /// Recharge of crypto balance
        /// It is with this resource that we carry out a recharge of balance on the buyer's card with the seller's cryptocurrencies.
        /// The checkin feature is used when we want to recharge cryptocurrency from A (seller) to B (buyer). 
        /// A checkin has a monetary value in currency (amount), acronym for currency (currency), 
        /// blockchain for transaction (blockchain), card number (pan), 
        /// seller's administrative password (password) and vendor identifier (vendorKey)
        /// </summary>
        /// <param name="rechargeCryptoBalance"></param>
        /// <returns></returns>
        public Checkout RechargeCryptoBalance(RechargeCryptoBalance rechargeCryptoBalance)
        {
            try
            {
                string urlBase = this.SandBox ? GlobalType.URL_BASE_SANDBOX : GlobalType.URL_BASE_DEFAULT;

                string strJson = JsonConvert.SerializeObject(rechargeCryptoBalance);

                byte[] buffer = Encoding.UTF8.GetBytes(strJson);

                HttpWebRequest httpWebRequest = HttpWebRequest.CreateHttp(urlBase + GlobalType.URL_CHECKOUT);
                httpWebRequest.Method = "POST";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.ContentLength = buffer.Length;
                httpWebRequest.GetRequestStream().Write(buffer, 0, buffer.Length);

                using (HttpWebResponse objResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader strReader = new StreamReader(objResponse.GetResponseStream()))
                        return JsonConvert.DeserializeObject<Checkout>(strReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                return new Checkout() { status = new Status() { code = "-1", message = ex.Message } };
            }
        }

        #endregion
    }
}
