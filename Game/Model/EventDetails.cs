using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("EventDetails")]
    public partial class EventDetails
    {
           public EventDetails(){


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
           /// Nullable:True
           /// </summary>           
           public DateTime? UpdateTime {get;set;}

           /// <summary>
           /// Desc:投注人
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long PassportId {get;set;}

           /// <summary>
           /// Desc:活动奖励
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal BetAmount {get;set;}

           /// <summary>
           /// Desc:审核状态 0：未审核 1：已审核 2：拒绝审核
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int IsType {get;set;}

           /// <summary>
           /// Desc:连接活动表
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Guid {get;set;}

           /// <summary>
           /// Desc:Auto+单号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OrderId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ManageUserPassportId {get;set;}

    }
}
