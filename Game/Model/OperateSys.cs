using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("OperateSys")]
    public partial class OperateSys
    {
           public OperateSys(){


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
           /// Desc:商户域名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ShopDomain {get;set;}

           /// <summary>
           /// Desc:代理域名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string AgentDomain {get;set;}

           /// <summary>
           /// Desc:默认代理类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int AgentType {get;set;}

           /// <summary>
           /// Desc:运营地区
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime AreaTime {get;set;}

           /// <summary>
           /// Desc:google验证码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int GoogleVaild {get;set;}

           /// <summary>
           /// Desc:PassportId
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long PassportId {get;set;}

    }
}
