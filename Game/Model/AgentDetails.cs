using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("AgentDetails")]
    public partial class AgentDetails
    {
           public AgentDetails(){


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
           /// Desc:代理类别ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int AgentId {get;set;}

           /// <summary>
           /// Desc:代理层级
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int AgentLevel {get;set;}

           /// <summary>
           /// Desc:代理自投返佣(0关闭，1开启)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int AgentBetIsRebate {get;set;}

           /// <summary>
           /// Desc:代理自投返佣比例
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public decimal AgentBetRebateRatio {get;set;}

           /// <summary>
           /// Desc:推广返佣
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int AgentPopIsRebate {get;set;}

           /// <summary>
           /// Desc:推广单价
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public decimal AgentPopAmount {get;set;}

           /// <summary>
           /// Desc:推广限额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int AgentPopCount {get;set;}

           /// <summary>
           /// Desc:提现方式(0手动，1自动)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int AgentCashMethod {get;set;}

           /// <summary>
           /// Desc:提现冻结时间
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int AgentRebateFrozenTime {get;set;}

           /// <summary>
           /// Desc:提现支付方式
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int AgentPayMethod {get;set;}

           /// <summary>
           /// Desc:提现最小金额
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public decimal? AgentCashMinAmount {get;set;}

           /// <summary>
           /// Desc:提现手续费
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public decimal? AgentCashFee {get;set;}

           /// <summary>
           /// Desc:PassportId
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long PassportId {get;set;}

    }
}
