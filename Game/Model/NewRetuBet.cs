using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class NewRetuBet
    {
        /// <summary>
        /// 商户passportid
        /// </summary>
        public string ManageUserPassportId { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public string mylevel { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 赔率
        /// </summary>
        public string BetOdds { get; set; }
        /// <summary>
        /// 游戏ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 游戏ID
        /// </summary>
        public int GameDetailsId { get; set; }
        /// <summary>
        /// hash钱包地址
        /// </summary>
        public string HashAddress { get; set; }
        /// <summary>
        /// 游戏名称
        /// </summary>
        public string GameName { get; set; }
        /// <summary>
        /// 输赢结果
        /// </summary>
        public int BetResult { get; set; }
        /// <summary>
        /// 开奖结果
        /// </summary>
        public string OpenResult { get; set; }
        /// <summary>
        /// 投注金额
        /// </summary>
        public decimal BetCoin{get;set;}
        /// <summary>
        /// 有效投注金额
        /// </summary>
        public decimal VaildBetAmount { get; set; }
        /// <summary>
        /// 无效投注金额
        /// </summary>
        public decimal UnVaildBetAmount { get; set; }
        /// <summary>
        /// 游戏抽水
        /// </summary>
        public decimal GameFee { get; set; }
        /// <summary>
        /// 无效游戏抽水
        /// </summary>
        public decimal InvalidGameFee { get; set; }
        /// <summary>
        /// 中奖金额
        /// </summary>
        public decimal BetWinCoin { get; set; }
        /// <summary>
        /// 投注时间
        /// </summary>
        public DateTime BetTime { get; set; }
        /// <summary>
        /// 结算时间
        /// </summary>
        public string UpdateTime { get; set; }
        /// <summary>
        /// 结算状态
        /// </summary>
        public int SettlementState { get; set; }
        /// <summary>
        /// block_number
        /// </summary>
        public string block_number { get; set; }
        /// <summary>
        /// block_hash
        /// </summary>
        public string block_hash { get; set; }
        /// <summary>
        /// 抽水金额
        /// </summary>
        public decimal gamefeeAmount { get; set; }
        /// <summary>
        /// 无效抽水金额
        /// </summary>
        public decimal unvaildbetfeeAmount { get; set; }
        /// <summary>
        /// 代理
        /// </summary>
        public string agentName { get; set; }
        /// <summary>
        /// 派彩hash
        /// </summary>
        public string cash_block_hash { get; set; }

    }
}
