using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("FeeOrder")]
    public partial class FeeOrder
    {
           public FeeOrder(){


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
           /// Desc:手续费类型（0游戏 1返佣 2红利 ）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int FeeType {get;set;}

           /// <summary>
           /// Desc:手续费来源订单
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string SourceOrder {get;set;}

           /// <summary>
           /// Desc:手续费金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal FeeAmount {get;set;}

           /// <summary>
           /// Desc:管理员PassportId
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ManageUserPassportId {get;set;}

    }
}
