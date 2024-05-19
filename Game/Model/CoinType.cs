using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("CoinType")]
    public partial class CoinType
    {
           public CoinType(){


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
           /// Desc:创建人（0默认系统）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long CreatePassportId {get;set;}

           /// <summary>
           /// Desc:创建人（0默认系统）
           /// Default:system
           /// Nullable:False
           /// </summary>           
           public string CreateName {get;set;}

           /// <summary>
           /// Desc:修改人（0默认系统）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long UpdatePassportId {get;set;}

           /// <summary>
           /// Desc:修改人（0默认系统）
           /// Default:system
           /// Nullable:False
           /// </summary>           
           public string UpdateName {get;set;}

           /// <summary>
           /// Desc:游戏名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CoinName {get;set;}

           /// <summary>
           /// Desc:入金产品绑定
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CoinKey {get;set;}

           /// <summary>
           /// Desc:出金产品绑定
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CoinValue {get;set;}

           /// <summary>
           /// Desc:游戏描述
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CoinDesc {get;set;}

    }
}
