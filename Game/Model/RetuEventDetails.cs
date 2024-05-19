using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class RetuEventDetails:EventDetails
    {

        /// <summary>
        /// Desc:产品类型ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string GameTypeId { get; set; }
        /// <summary>
        /// Desc:活动名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string EventName { get; set; }

        /// <summary>
        /// Desc:产品名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string GameName { get; set; }

        /// <summary>
        /// Desc:操作时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime? OperationTime { get; set; }

        /// <summary>
        /// Desc:0自动审核 1 手动
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int IsAudit { get; set; }

        /// <summary>
        /// Desc:0123 0:连胜 1：累计投注 2：负盈利 3：连败
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int RulesType { get; set; }
    }
}
