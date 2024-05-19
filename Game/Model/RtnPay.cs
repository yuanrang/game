using Newtonsoft.Json;

namespace Game.Model
{
    public class RtnPay
    {
        //"{merchant_no: \"" + pay?.merchant_no + "\",
        //params:\"{\\\"merchant_ref\\\":\\\"" + OrderID + "\\\",\\\"product\\\":\\\"" + product + "\\\",\\\"amount\\\":\\\"" + Amount + "\\\",\\\"extra\\\":{\\\"address\\\":\\\"" + ToHashAddress + "\\\"}}\",sign: \"" + sign + "\",sign_type: \"MD5\",timestamp: " + timestamp + " }";
        public string merchant_no { get; set; }


        public string sign_type { get; set; }
        public int timestamp { get; set; }
        public string sign { get; set; }
    }
    public class PayCash : RtnPay
    {
        [JsonProperty(propertyName: "params")]
        public paramsCash paramss { get; set; }
    }

    public class paramsCash
    {
        public string merchant_ref { get; set; }
        public string product { get; set; }
        public string amount { get; set; }
        public extras extra { get; set; }
        public string extend_params { get; set; }
    }

    public class ShopAddress : RtnPay
    {
        [JsonProperty(propertyName: "params")]
        //public string paramss { get; set; }
        public paramsAddress paramss { get; set; }
    }

    public class paramsAddress
    {
        public string extra { get; set; }
        public string customerid { get; set; }
        public string currency { get; set; }
    }

    public class extras
    {
        public string address { get; set; }
    }
}
