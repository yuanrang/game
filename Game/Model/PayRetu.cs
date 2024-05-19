using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class PayRetu
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int system_id { get; set; }
        public string customerid { get; set; }
        public string currency { get; set; }
        public extra Extra { get; set; }
        public CashRetu Cash { get; set; }
    }

    public class extra
    { 
        public string trc20 { get; set; }
    }

    public class CashRetu
    {
        public string merchant_ref { get; set; }
        public string system_ref { get; set; }
        public string amount { get; set; }
        public string pay_amount { get; set; }
        public string fee { get; set; }
        public int status { get; set; }
        public string success_time { get; set; }
        public string extend_params { get; set; }
        public string product { get; set; }
        public string product_ref { get; set; }
        public int reversal { get; set; }
        public string reason { get; set; }
    }


    public class PayTheGold
    {
        /*
         * 
code:200
message:""
params:"{"merchant_ref":"10000420227194152","system_ref":"P1658217658VKAW5","amount":"1.000000","pay_amount":"1.000000","fee":"0.000000","status":2,"success_time":null,"extend_params":"","product":"TRXPayout","product_ref":null,"reversal":0,"reason":""}"
timestamp:1658217658
         * 
         * 
         */

        public string code { get; set; }
        public int timestamp { get; set; }
        public string message { get; set; }
        [JsonProperty(propertyName: "params")]
        public PayParams paramss { get; set; }
    }

    public class PayParams
    {
        public string merchant_ref { get; set; }
        public string system_ref { get; set; }
        public string amount { get; set; }
        public string fee { get; set; }
        public int status { get; set; }
        public int success_time { get; set; }
        public string extend_params { get; set; }
        public string product { get; set; }
        public string product_ref { get; set; }
        public string reason { get; set; }
        public int reversal { get; set; }
    }
}
