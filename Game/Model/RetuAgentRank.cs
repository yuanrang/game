using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class RetuAgentRank : AgentRank
    {
        public int AgentTypeId { get; set; }

        /// <summary>
        /// Desc:管理员PassportId
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long? ManageUserPassportId { get; set; }
    }
}
