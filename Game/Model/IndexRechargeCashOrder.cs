using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("IndexRechargeCashOrder")]
    public partial class IndexRechargeCashOrder
    {
        public IndexRechargeCashOrder()
        {


        }
        /// <summary>
        /// Desc:添加时间
        /// Default:DateTime.Now
        /// Nullable:False
        /// </summary>           
        public DateTime AddTime { get; set; }
        /// <summary>
        /// Desc:收款Hash地址
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ToHashAddress { get; set; }

        /// <summary>
        /// Desc:产品
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string product { get; set; }

        /// <summary>
        /// Desc:币数量
        /// Default:
        /// Nullable:False
        /// </summary>           
        public decimal CoinNumber { get; set; }

        /// <summary>
        /// 充值提现(0充值 1提现)
        /// </summary>
        public int RCType { get; set; }


    }
}
