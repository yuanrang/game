using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("GameCoinTypeQuota")]
    public partial class GameCoinTypeQuota
    {
           public GameCoinTypeQuota(){


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
           /// Desc:游戏ID
           /// Default:999999999
           /// Nullable:False
           /// </summary>           
           public int GameDetailsId {get;set;}

        /// <summary>
        /// Desc:币种类型ID
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public int CoinTypeId { get; set; }

        /// <summary>
        /// Desc:最小限额
        /// Default:
        /// Nullable:False
        /// </summary>           
        public decimal MinQuota {get;set;}

           /// <summary>
           /// Desc:最大限额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal MaxQuota {get;set;}

           /// <summary>
           /// Desc:管理员PassportId
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long ManageUserPassportId {get;set;}

    }
}
