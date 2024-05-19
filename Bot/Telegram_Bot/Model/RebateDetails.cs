using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("RebateDetails")]
    public partial class RebateDetails
    {
           public RebateDetails(){


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
           /// Desc:PassportId(返佣人)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long PassportId {get;set;}

           /// <summary>
           /// Desc:收款Hash地址
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ToHashAddress {get;set;}

           /// <summary>
           /// Desc:投注Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int BetId {get;set;}

           /// <summary>
           /// Desc:投注金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal BetAmount {get;set;}

           /// <summary>
           /// Desc:返佣金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal RebateAmount {get;set;}

           /// <summary>
           /// Desc:付款Hash地址
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string FromHashAddress {get;set;}

           /// <summary>
           /// Desc:PassportId(投注人)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long BetPassportId {get;set;}

           /// <summary>
           /// Desc:管理员PassportId
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ManageUserPassportId {get;set;}

           /// <summary>
           /// Desc:返佣计算状态(0未计算，1已计算)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int CalculationState {get;set;}

           /// <summary>
           /// Desc:返佣结算状态(0未结算，1已结算)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int SettlementState {get;set;}

    }
}
