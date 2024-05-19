using System;
using System.Collections.Generic;

namespace Game.Model
{
    public class RtnEvenetHK
    {
        /// <summary>
        /// 
        /// </summary>
        public string OpenId { get; set; }
        public int Id { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// Desc:0自动审核 1 手动
        /// </summary>
        public int IsAudit { get; set; }
        /// <summary>
        /// 是否有效1：有效0无效
        /// </summary>
        public string  IsValid { get; set; }
        /// <summary>
        /// Desc:专属代理 PassportId 
        /// </summary>           
        public string PassportId { get; set; }
        /// <summary>
        /// 货币类型 1：USDT 2:TRX
        /// </summary>
        public int CoinType { get;set; }
        /// <summary>
        /// Desc:游戏ID
        /// </summary>           
        public string GameTypeId { get; set; }
        /// <summary>
        /// Desc:个人每日次数 0无限次
        /// </summary>           
        public int ToDayUserNum { get; set; }

        /// <summary>
        /// Desc:个人所有次数  0无限次
        /// </summary>           
        public int UserNum { get; set; }
        /// <summary>
        /// Desc:个人每日次数 0无限次
        /// </summary>           
        public int ToDayAllUserNum { get; set; }

        /// <summary>
        /// Desc:个人所有次数  0无限次
        /// </summary>           
        public int AllUserNum { get; set; }
        /// <summary>
        /// 启用时间
        /// </summary>
        public DateTime StaTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 活动规则
        /// </summary>
        public List<RtnEventRules> EventRules { get; set; }
        /// <summary>
        /// Desc:0123 0:连胜 1：累计投注 2：负盈利 3：连败
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int RulesType { get; set; }

        public string GoogleCode { get; set; }
    }
    public class RtnEventRules
    {
        public int Id { get; set; }
        /// <summary>
        /// Desc:条件一
        /// Default:
        /// Nullable:False
        /// </summary>           
        public decimal BetAmount { get; set; }

        /// <summary>
        /// Desc:奖励
        /// Default:
        /// Nullable:False
        /// </summary>           
        public decimal Reward { get; set; }

    


    }
    public class RtnEventDetails
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// 活动奖励
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 审核方式
        /// </summary>
        public string AuditType { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Admin { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }

    public class RtnGetEvent: RtnEvenetHK
    {
        /// <summary>
        /// 游戏名称
        /// </summary>
        public string GameName { get; set; }
        /// <summary>
        /// 领取记录
        /// </summary>
        public string GetRecord { get; set; }
        /// <summary>
        /// 优惠总红利
        /// </summary>
        public decimal SumPrice { get; set; }
    }

    public class RtnJBXXDTO
    {
        /// <summary>
        /// 钱包地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 代理人数
        /// </summary>
        public int TOPCOUNT { get; set; }
        /// <summary>
        /// 代理1
        /// </summary>
        public int TOP1 { get; set; }
        /// <summary>
        /// 代理2
        /// </summary>
        public int TOP2 { get; set; }
        /// <summary>
        /// qita代理
        /// </summary>
        public int TOP3 { get; set; }
        public int TOP4 { get; set; }

    }
    public class RtMyWatr
    {
        public decimal SumUWatr { get; set; }
        public decimal SumUProfit { get; set; }
        public decimal SumTWatr { get; set; }
        public decimal SumTProfit { get; set; }
        public List<GameWatr> Yesterday { get;set; }
        public List<GameWatr> Today { get;set; }
    }
    public class GameWatr
    {
        public string GameName { get; set; }
        public decimal GameUWatrs { get; set; }
        public decimal GameUProfit { get; set; }
        public decimal GameTWatrs { get; set; }
        public decimal GameTProfit { get; set; }
    }

}
