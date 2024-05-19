using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    ///实体类
    public class ReturnProWater : ReturnProPrice
    {
        /// <summary>
        /// adminUser表id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户地址
        /// </summary>
        public string UserUrl { get; set; }
        /// <summary>
        /// 商户数量
        /// </summary>
        public string UseMerNum { get; set; }
        /// <summary>
        /// 代理数量
        /// </summary>
        public int UseProNum { get; set; }
        /// <summary>
        /// 游戏类型的流水及盈利，一般会根据数据库的id来排序
        /// </summary>
        public List<ReturnProPrices> GameType { get; set; }
    }

    public class ReturnProPrice
    {
        /// <summary>
        /// 流水
        /// </summary>
        public decimal PriceUY { get; set; }
        /// <summary>
        /// 盈利
        /// </summary>
        public decimal PriceUN { get; set; }   
        /// <summary>
        /// 流水
        /// </summary>
        public decimal PriceTY { get; set; }
        /// <summary>
        /// 盈利
        /// </summary>
        public decimal PriceTN { get; set; }
    }
    public class ReturnProPrices : ReturnProPrice
    {
        public string GameName { get; set; }
    }

    public class RetunBotWatr : ReturnProWater
    {
        public string TGname { get; set; }
    }
    public class ProWatrBot : LV
    {

        public List<ReturnProPrices> GameType { get; set; }
    }
    public class ProWatrDetails: ProWatrBot
    {
        public string TGname { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
       
    }
    public class LV
    {
        /// <summary>
        /// 代理人数
        /// </summary>
        public int LV1 { get; set; }
        /// <summary>
        /// 二级代理人数
        /// </summary>
        public int LV2 { get; set; }
        public int LV3 { get; set; }
        public int LV4 { get; set; }
    }
    public class RtnReba : LV
    {
        /// <summary>
        /// 一级代理共下注
        /// </summary>
        public decimal LV1UBetPri { get; set; }
        public decimal LV0UBetPri { get; set; }
        public decimal LV3UBetPri { get; set; }
        /// <summary>
        /// 2级代理共下注
        /// </summary>
        public decimal LV2UBetPri { get; set; }
        /// <summary>
        /// 一级反用
        /// </summary>
        public decimal LV1URate { get; set; }
        public decimal LV2URate { get; set; }
        public decimal LV0URate { get; set; }
        public decimal LV3URate { get; set; }
        /// <summary>
        /// 一级代理共下注
        /// </summary>
        public decimal LV1TBetPri { get; set; }
        public decimal LV0TBetPri { get; set; }
        public decimal LV3TBetPri { get; set; }
        /// <summary>
        /// 2级代理共下注
        /// </summary>
        public decimal LV2TBetPri { get; set; }
        /// <summary>
        /// 一级反用
        /// </summary>
        public decimal LV1TRate { get; set; }
        public decimal LV2TRate { get; set; }
        public decimal LV0TRate { get; set; }
        public decimal LV3TRate { get; set; }

        /// <summary>
        /// 返佣总额
        /// </summary>
        public decimal SumURate { get; set; }
        /// <summary>
        /// 提现总额
        /// </summary>
        public decimal TXURate { get; set; }
        /// <summary>
        /// 代提现总额
        /// </summary>
        public decimal WURate { get; set; }
        /// <summary>
        /// 返佣总额
        /// </summary>
        public decimal SumTRate { get; set; }
        /// <summary>
        /// 提现总额
        /// </summary>
        public decimal TXTRate { get; set; }
        /// <summary>
        /// 代提现总额
        /// </summary>
        public decimal WTRate { get; set; }
    }
    public class ReturnMerDetail
    {
        /// <summary>
        /// 俱乐部总人数
        /// </summary>
        public int PeoNum { get; set; }
        /// <summary>
        /// 俱乐部今日新增人数
        /// </summary>
        public int TodayPeoNum { get; set; }
        /// <summary>
        /// 商户总人数
        /// </summary>
        public int MerNum { get; set; }
        /// <summary>
        /// 商户今日新增人数
        /// </summary>
        public int TodayMerNum { get; set; }
        /// <summary>
        /// 代理总人数
        /// </summary>
        public int ProNum { get; set; }
        /// <summary>
        /// 代理今日新增人数
        /// </summary>
        public int TodayProNum { get; set; }
        /// <summary>
        /// 今日投注
        /// </summary>
        public decimal TodayUsdt { get; set; }

        /// <summary>
        /// 盈利
        /// </summary>
        public decimal TodayUsdtY { get; set; }

        /// <summary>
        /// 当日游戏笔数
        /// </summary>
        public int TodayGameNum { get; set; }
        /// <summary>
        /// 当日游戏人数
        /// </summary>
        public int TodayNum { get; set; }
        /// <summary>
        /// 昨日投注
        /// </summary>
        public decimal YesterdayUsdt { get; set; }

        /// <summary>
        /// 盈利
        /// </summary>
        public decimal YesterdayUsdtY { get; set; }

        /// <summary>
        /// 昨日游戏笔数
        /// </summary>
        public int YesterdayGameNum { get; set; }
        /// <summary>
        /// 昨日游戏人数
        /// </summary>
        public int YesterdayNum { get; set; }

    }
}
