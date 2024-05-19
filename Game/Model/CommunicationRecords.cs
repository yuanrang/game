using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("CommunicationRecords")]
    public partial class CommunicationRecords
    {
           public CommunicationRecords(){


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
           /// Desc:通讯工具的id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ToolsId {get;set;}

           /// <summary>
           /// Desc:图片的地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MsgImg {get;set;}

           /// <summary>
           /// Desc:代理的passportId 全部为空
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PassportId {get;set;}

           /// <summary>
           /// Desc:标题
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string MsgTitle {get;set;}

           /// <summary>
           /// Desc:正文
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string MsgBody {get;set;}

           /// <summary>
           /// Desc:信息状态
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ManageUserPassportId {get;set;}

    }
}
