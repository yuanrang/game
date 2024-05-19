using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("BotSys")]
    public partial class BotSys
    {
           public BotSys(){


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
           /// Desc:机器人token
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BotToken {get;set;}

           /// <summary>
           /// Desc:描述
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Details {get;set;}

           /// <summary>
           /// Desc:是否启动（0启动，1关闭）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int IsStart {get;set;}
            public string ShopName { get;set;}
            public string BotName { get;set;}
            public string UnBindHashAddress { get; set; }

           /// <summary>
           /// Desc:管理员PassportId
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ManageUserPassportId {get;set;}

    }
}
