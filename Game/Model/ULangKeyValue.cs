using SqlSugar;
using System;

namespace Game.Model
{
    [SugarTable("UserInfo")]
    public partial class ULangKeyValue
    {
        public ULangKeyValue()
        {


        }
        /// <summary>
        /// Desc:编号
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// Desc:更新IP
        /// Default:127.0.0.1
        /// Nullable:False
        /// </summary>           
        public string Ip { get; set; }

        /// <summary>
        /// Desc:排序
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public int Sort { get; set; }

        /// <summary>
        /// Desc:是否有效(0无效 1有效)
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public int IsValid { get; set; }

        /// <summary>
        /// Desc:添加时间
        /// Default:DateTime.Now
        /// Nullable:False
        /// </summary>           
        public DateTime AddTime { get; set; }

        /// <summary>
        /// Desc:更新时间
        /// Default:DateTime.Now
        /// Nullable:False
        /// </summary>           
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Desc:键
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ULangKey { get; set; }

        /// <summary>
        /// Desc:值
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ULangValue { get; set; }
    }
}
