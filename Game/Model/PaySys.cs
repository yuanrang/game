using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("PaySys")]
    public partial class PaySys
    {
           public PaySys(){


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
           /// Desc:支付商户号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string merchant_no {get;set;}

           /// <summary>
           /// Desc:商户名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string merchant_name {get;set;}

           /// <summary>
           /// Desc:产品类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string product {get;set;}

           /// <summary>
           /// Desc:apiKey
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string apiKey {get;set;}

           /// <summary>
           /// Desc:直系上级返佣比例（%）
           /// Default:1
           /// Nullable:True
           /// </summary>           
           public decimal? RebateRatio {get;set;}

           /// <summary>
           /// Desc:直系上级的上级返佣比例（%）
           /// Default:50
           /// Nullable:True
           /// </summary>           
           public decimal? RebateParentRatio {get;set;}

           /// <summary>
           /// Desc:结算手续费（%）
           /// Default:5
           /// Nullable:True
           /// </summary>           
           public decimal? SettlemnetFeeRatio {get;set;}

           /// <summary>
           /// Desc:请求入金接口
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string request_url1 {get;set;}

           /// <summary>
           /// Desc:请求出金接口
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string request_url2 {get;set;}

           /// <summary>
           /// Desc:请求绑定商户接口
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string request_url3 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string request_url4 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string request_url5 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string request_url6 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string request_url7 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string request_url8 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string request_url9 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string request_url10 {get;set;}

           /// <summary>
           /// Desc:PassportId
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long PassportId {get;set;}

           /// <summary>
           /// Desc:管理员PassportId
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ManageUserPassportId {get;set;}

    }
}
