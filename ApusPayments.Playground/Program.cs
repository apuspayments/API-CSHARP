using ApusPayments.Constants;
using ApusPayments.Controller;
using ApusPayments.Domain.Request;
using Newtonsoft.Json;
using System;

namespace ApusPayments.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            ApusPaymentsAPI apusPaymentsAPI = new ApusPaymentsAPI(EnviromentType.SandBox);

            string pan = "9999999999999999"; 
            string password = "1234";

            string vendorKey = "5f5bdaed-f82b-4b82-b3f5-1d562633da5b";
            string vendorPassword = "1234"; 

            // Make a payment
            MakePayment makePayment = new MakePayment();
            makePayment.pan = pan;
            makePayment.password = password;
            makePayment.blockchain = BlockChainType.LTC;
            makePayment.amount = 13.88;
            makePayment.currency = CurrencyType.BRL;
            makePayment.vendorKey = vendorKey;

            var makePaymentReturn = apusPaymentsAPI.MakePayment(makePayment);

            Console.WriteLine("MakePayment: " + JsonConvert.SerializeObject(makePaymentReturn));
            Console.WriteLine("");

            // Make a recurring payment
            MakeRecurringPayment makeRecurringPayment = new MakeRecurringPayment();
            makeRecurringPayment.pan = pan;
            makeRecurringPayment.password = password;
            makeRecurringPayment.blockchain = BlockChainType.LTC;
            makeRecurringPayment.amount = 13.88;
            makeRecurringPayment.currency = CurrencyType.BRL;
            makeRecurringPayment.period = PeriodType.M;
            makeRecurringPayment.vendorKey = vendorKey;

            var makeRecurringPaymentReturn = apusPaymentsAPI.MakeRecurringPayment(makeRecurringPayment);

            Console.WriteLine("Make a Recurring Payment: " + JsonConvert.SerializeObject(makeRecurringPaymentReturn));
            Console.WriteLine("");

            // Search payment
            SearchPayment searchPayment = new SearchPayment();
            searchPayment.vendorKey = vendorKey;
            searchPayment.txId = "";
            searchPayment.timestamp = "";
            searchPayment.blockchain = BlockChainType.LTC;
            searchPayment.currency = CurrencyType.BRL;
            searchPayment.coinAmount = "";
            searchPayment.currencyAmount = "";
            searchPayment.buyer = "";

            var searchPaymentReturn = apusPaymentsAPI.SearchPayment(searchPayment);

            Console.WriteLine("Search Payment: " + JsonConvert.SerializeObject(searchPaymentReturn));
            Console.WriteLine("");

            // Cancel
            CancelPayment cancelPayment = new CancelPayment();
            cancelPayment.txId = "2bf779e2a311c2629df977b0bb105879411fd71f5839972c4ed1d3278f80170f";
            cancelPayment.password = vendorPassword;
            cancelPayment.vendorKey = vendorKey;

            var cancelPaymentReturn = apusPaymentsAPI.CancelPayment(cancelPayment);

            Console.WriteLine("Cancel a Payment: " + JsonConvert.SerializeObject(cancelPaymentReturn));
            Console.WriteLine("");

            RechargeCryptoBalance rechargeCryptoBalance = new RechargeCryptoBalance();
            rechargeCryptoBalance.pan = pan;
            rechargeCryptoBalance.password = password;
            rechargeCryptoBalance.blockchain = BlockChainType.LTC;
            rechargeCryptoBalance.amount = 13.88;
            rechargeCryptoBalance.currency = CurrencyType.BRL;
            rechargeCryptoBalance.vendorKey = vendorKey;

            var rechargeCryptoBalanceReturn = apusPaymentsAPI.RechargeCryptoBalance(rechargeCryptoBalance);

            Console.WriteLine("Recharge of Crypto Balance: " + JsonConvert.SerializeObject(rechargeCryptoBalanceReturn));
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
