namespace DATN_ACV_DEV.Constant
{
    public class Constants
    {
        public class AppSettings
        {
            public const string DEFAULT_CONTROLLER_ROUTE = "api/[controller]";
        }
        public class PaymentType
        {
            public static string COD = "COD";
            public static string Paypal = "Paypal";
            public static string VNPAY = "VnPay";
            public static string MOMO = "MoMo";
            public static string STRIPE = "Stripe";
        }
    }
}
