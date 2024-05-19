using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class RetuUserInfo : UserInfo
    {
        public new RetuOtherMsg OtherMsg { get; set; }

        public int MyLevel { get; set; }

        public string RoleName { get; set; }

        public string AgentTypeName { get; set; }

        public string AgentPopIsRebate { get; set; }
    }
}
