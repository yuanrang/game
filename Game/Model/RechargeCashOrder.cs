using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("RechargeCashOrder")]
    public partial class RechargeCashOrder
    {
           public RechargeCashOrder(){


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
           /// Desc:
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
           /// Desc:付款Hash地址
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string FromHashAddress {get;set;}

           /// <summary>
           /// Desc:收款Hash地址
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ToHashAddress {get;set;}

           /// <summary>
           /// Desc:币数量
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal CoinNumber {get;set;}

           /// <summary>
           /// Desc:是否支付(0未支付，1已支付)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int IsPayment {get;set;}

           /// <summary>
           /// Desc:币类别(0usdt 1其他)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int CoinType {get;set;}

           /// <summary>
           /// Desc:充值提现(0充值 1提现)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int RCType {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ManageUserPassportId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string merchant_no {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string sign {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string sign_type {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string timestamp {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string merchant_ref {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string system_ref {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string amount {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pay_amount {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string fee {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? status {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string success_time {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string extend_params {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string product {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string product_ref {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string block_number {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string block_hash {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string from {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string to {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? reversal {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string reason {get;set;}

    }
}
