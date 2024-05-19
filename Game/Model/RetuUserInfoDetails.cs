using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class RetuUserInfoDetails
    {
        /// <summary>
        /// UID
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 游戏笔数
        /// </summary>
        public int? BetCount { get; set; }
        /// <summary>
        /// 流水
        /// </summary>
        public decimal? BetAmount { get; set; }
        /// <summary>
        /// 盈利
        /// </summary>
        public decimal? BetWinLose { get; set; }
        /// <summary>
        /// 返佣
        /// </summary>
        public decimal? RebateAmount { get; set; }
        /// <summary>
        /// 红利
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// 用户基本信息
        /// </summary>
        public UserBasic userBasic { get; set; }

        /// <summary>
        /// 用户订单信息
        /// </summary>
        public List<ReturnBet> userBets { get; set; }

        /// <summary>
        /// 用户优惠红利
        /// </summary>
        public List<RetuEventDetails> userDiscount { get; set; }

        /// <summary>
        /// 用户下级列表
        /// </summary>
        public List<RetuUserInfo> userChilde { get; set; }
    }

    /// <summary>
    /// 用户基本信息
    /// </summary>
    public class UserBasic
    {
        /// <summary>
        /// 钱包地址
        /// </summary>
        public string HashAddress { get; set; }
        /// <summary>
        /// tg
        /// </summary>
        public string Telegram { get; set; }
        /// <summary>
        /// WhatsApp
        /// </summary>
        public string WhatsApp { get; set; }
        /// <summary>
        /// 上级
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public string IsVaild { get; set; }
        /// <summary>
        /// 推广资格
        /// </summary>
        public string PopVaild { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? AddTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }

}
