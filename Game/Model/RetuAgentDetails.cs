using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class RetuAgentDetails:AgentDetails
    {
        /// <summary>
        /// Desc:代理名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Create { get; set; }

        /// <summary>
        /// Desc:代理名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string AgentName { get; set; }

        /// <summary>
        /// Desc:代理描述
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string AgentDesc { get; set; }
    }
}
