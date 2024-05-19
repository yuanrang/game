using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("UserInfo")]
    public partial class UserInfo
    {
           public UserInfo(){


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
           /// Desc:Hash地址
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HashAddress {get;set;}

           /// <summary>
           /// Desc:用户名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:e10adc3949ba59abbe56e057f20f883e
           /// Nullable:False
           /// </summary>           
           public string Pwd {get;set;}

           /// <summary>
           /// Desc:推广码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string TJCode {get;set;}

           /// <summary>
           /// Desc:上级ID
           /// Default:999999999
           /// Nullable:False
           /// </summary>           
           public int ParentId {get;set;}

        /// <summary>
        /// Desc:TgChatId
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public string TgChatId { get;set;}

           /// <summary>
           /// Desc:会员等级
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int AgentTypeID {get;set;}

           /// <summary>
           /// Desc:管理员PassportId
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? ManageUserPassportId {get;set;}

           /// <summary>
           /// Desc:角色ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int RoleId {get;set;}

           /// <summary>
           /// Desc:OpenId
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OpenId {get;set;}

           /// <summary>
           /// Desc:时间戳
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int CurrentTimeStamp {get;set;}

           /// <summary>
           /// Desc:用户语言（0简体中文，1繁体中文，2英文）
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? UserLang {get;set;}

           /// <summary>
           /// Desc:登录错误次数
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? LoginErrorCount {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OtherMsg {get;set;}

    }
}
