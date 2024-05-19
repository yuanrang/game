using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("AdminPage")]
    public partial class AdminPage
    {
           public AdminPage(){


           }
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
           /// Desc:页面名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PageName {get;set;}

           /// <summary>
           /// Desc:页面URL
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PageUrl {get;set;}

        /// <summary>
        /// Desc:页面图标
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string PageIcon { get; set; }

        /// <summary>
        /// Desc:上级ID
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int ParentId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ManageUserPassportId {get;set;}

    }
}
