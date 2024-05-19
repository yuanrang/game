using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    public class Notify
    {

        public string merchant_ref
        {
            get; set;
        }

        public string system_ref
        {
            get; set;
        }

        public string amount
        {
            get; set;
        }

        public string pay_amount
        {
            get; set;
        }

        public string fee
        {
            get; set;
        }

        /// <summary>
        /// 存款订单状态：0：Unpaid；1：Paid；出金订单状态：1：Success；2：Pending；5：Reject
        /// </summary>
        public int status
        {
            get; set;
        }
        /// <summary>
        /// 成功支付时间（时间戳），订单未成功时，该字段值为 null
        /// </summary>
        public string success_time
        {
            get; set;
        }

        public string extend_params
        {
            get; set;
        }
        /// <summary>
        /// 产品订单号 (印度产品[UTR], USDT[Hash])
        /// </summary>
        public string product
        {
            get; set;
        }
        public string product_ref
        {
            get; set;
        }
        public string block_number
        {
            get; set;
        }
        /// <summary>
        /// 区块哈希
        /// </summary>
        public string block_hash
        {
            get; set;
        }
        /// <summary>
        /// 转账地址
        /// </summary>
        public string from
        {
            get; set;
        }
        /// <summary>
        /// 收款地址
        /// </summary>
        public string to
        {
            get; set;
        }

        public int reversal { get; set; }

        public string reason { get; set; }
    }
}
