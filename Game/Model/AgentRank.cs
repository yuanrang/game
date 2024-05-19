using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("AgentRank")]
    public partial class AgentRank
    {
           public AgentRank(){


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
           /// Desc:代理详情ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int AgentDetailsId {get;set;}

           /// <summary>
           /// Desc:代理层级等级
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int AgentLevel {get;set;}

           /// <summary>
           /// Desc:有效流水
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public decimal AgentValidBet {get;set;}

           /// <summary>
           /// Desc:返佣比例
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public decimal RebateRatio1 {get;set;}

           /// <summary>
           /// Desc:返佣极差
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public decimal RebateRatio2 {get;set;}

           /// <summary>
           /// Desc:返佣上限
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public decimal MaxRebateAmount {get;set;}

           /// <summary>
           /// Desc:反水游戏ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public decimal RebateGameId {get;set;}

           /// <summary>
           /// Desc:额外流水
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public decimal OtherBet {get;set;}

           /// <summary>
           /// Desc:额外返水
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public decimal OtherRebateRatio {get;set;}

           /// <summary>
           /// Desc:额外人数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int OtherRebateNumber {get;set;}

           /// <summary>
           /// Desc:PassportId（创建人）
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long PassportId {get;set;}

    }
}
