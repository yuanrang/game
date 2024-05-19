using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Bet")]
    public partial class Bet
    {
           public Bet(){


           }
           /// <summary>
           /// Desc:编号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int Id {get;set;}

           /// <summary>
           /// Desc:更新IP
           /// Default:127.0.0.1
           /// Nullable:False
           /// </summary>           
           public string Ip {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int Sort {get;set;}

           /// <summary>
           /// Desc:是否有效(0无效 1有效)
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int IsValid {get;set;}

           /// <summary>
           /// Desc:添加时间
           /// Default:DateTime.Now
           /// Nullable:False
           /// </summary>           
           public DateTime AddTime {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:DateTime.Now
           /// Nullable:False
           /// </summary>           
           public DateTime UpdateTime {get;set;}

           /// <summary>
           /// Desc:PassportId
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long PassportId {get;set;}

           /// <summary>
           /// Desc:订单ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OrderID {get;set;}

           /// <summary>
           /// Desc:游戏详情ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int GameDetailsId {get;set;}

           /// <summary>
           /// Desc:投注时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime BetTime {get;set;}

           /// <summary>
           /// Desc:结算时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? SettlementTime {get;set;}

           /// <summary>
           /// Desc:投注金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal BetCoin {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? CoinType {get;set;}

           /// <summary>
           /// Desc:赔率
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal BetOdds {get;set;}

           /// <summary>
           /// Desc:彩金
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal BetWinCoin {get;set;}

           /// <summary>
           /// Desc:结算状态(0未结算 1已结算)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int SettlementState {get;set;}

           /// <summary>
           /// Desc:投注结果(0输 1赢 2未开奖)
           /// Default:2
           /// Nullable:False
           /// </summary>           
           public int BetResult {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OpenResult {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string product_ref {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ManageUserPassportId {get;set;}

    }
}
