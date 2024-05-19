using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class RetuTradeStatis
    {
        /// <summary>
        /// 损益
        /// </summary>
        public decimal AllWinLose { get; set; }
        /// <summary>
        /// 损益同比
        /// </summary>
        public string AllWinLoseTB { get; set; } = "0%";
        /// <summary>
        /// 存款
        /// </summary>
        public decimal AllRecharge { get; set; }
        /// <summary>
        /// 存款同比
        /// </summary>
        public string AllRechargeTB { get; set; } = "0%";
        /// <summary>
        /// 取款
        /// </summary>
        public decimal AllCash { get; set; }
        /// <summary>
        /// 取款同比
        /// </summary>
        public string AllCashTB { get; set; } = "0%";
        /// <summary>
        /// 优惠红利
        /// </summary>
        public decimal AllDiscount { get; set; }
        /// <summary>
        /// 优惠红利同比
        /// </summary>
        public string AllDiscountTB { get; set; } = "0%";
        /// <summary>
        /// 流水分佣
        /// </summary>
        public decimal AllRebate { get; set; }
        /// <summary>
        /// 流水分佣同比
        /// </summary>
        public string AllRebateTB { get; set; } = "0%";
        /// <summary>
        /// 流水手续费
        /// </summary>
        public decimal AllRebateFee { get; set; }
        /// <summary>
        /// 流水手续费同比
        /// </summary>
        public string AllRebateFeeTB { get; set; } = "0%";
        /// <summary>
        /// 无效游戏金额
        /// </summary>
        public decimal AllInvalidAmount { get; set; }
        /// <summary>
        /// 无效游戏金额同比
        /// </summary>
        public string AllInvalidAmountTB { get; set; } = "0%";
        /// <summary>
        /// 投注笔数
        /// </summary>
        public int AllGameCount { get; set; }
        /// <summary>
        /// 投注笔数同比
        /// </summary>
        public string AllGameCountTB { get; set; } = "0%";

        public List<TradeChart> tradeCharts { get; set; }

        public List<GameRatio> gameRatios { get; set; }

        public List<GameRank> gameRanks { get; set; }
        //public int gameRankCount { get; set; }
    }
}
