using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("RetuAdminGameRelation")]
    public partial class RetuAdminGameRelation
    {
           public RetuAdminGameRelation(){


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
           /// Desc:游戏详情ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int GameDetailsId {get;set;}

        /// <summary>
        /// Desc:游戏详情名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string GameDetailsName { get; set; }

        /// <summary>
        /// Desc:收款哈希地址
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string HashAddress {get;set;}

           /// <summary>
           /// Desc:收款币类别(0usdt 1其他)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int CoinType {get;set;}

    }
}
