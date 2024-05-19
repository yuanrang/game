using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("EventHK")]
    public partial class EventHK
    {
           public EventHK(){


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
           /// Desc:活动名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string EventName {get;set;}

           /// <summary>
           /// Desc:0自动审核 1 手动
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int IsAudit {get;set;}

           /// <summary>
           /// Desc:0123 0:连胜 1：累计投注 2：负盈利 3：连败
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int RulesType {get;set;}

           /// <summary>
           /// Desc:专属代理 PassportId 0为不选择
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PassportId {get;set;}

           /// <summary>
           /// Desc:游戏ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string GameTypeId {get;set;}
        /// <summary>
        /// 货币类型 1：USDT 2:TRX
        /// </summary>
        public int CoinType { get; set; }

        /// <summary>
        /// Desc:个人每日次数 0无限次
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int ToDayUserNum {get;set;}

           /// <summary>
           /// Desc:个人所有次数  0无限次
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int UserNum {get;set;}

        /// <summary>
        /// Desc:个人每日次数 0无限次
        /// </summary>           
        public int ToDayAllUserNum { get; set; }

        /// <summary>
        /// Desc:个人所有次数  0无限次
        /// </summary>           
        public int AllUserNum { get; set; }

        /// <summary>
        /// Desc:GUID连接规则表 生产guid
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string GUID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ManageUserPassportId {get;set;}

           /// <summary>
           /// Desc:操作时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? OperationTime {get;set;}

    }
}
