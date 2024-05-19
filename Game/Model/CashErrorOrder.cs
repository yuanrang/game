using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("CashErrorOrder")]
    public partial class CashErrorOrder
    {
           public CashErrorOrder(){


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
           /// Desc:提现订单号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OrderID {get;set;}

           /// <summary>
           /// Desc:提现金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal Amount {get;set;}

           /// <summary>
           /// Desc:提现地址
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ToHashAddress {get;set;}

           /// <summary>
           /// Desc:商户号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string merchant_no {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string product {get;set;}

           /// <summary>
           /// Desc:提现json参数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string cash_json {get;set;}

    }
}
