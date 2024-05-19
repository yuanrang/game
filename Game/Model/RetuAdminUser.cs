using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Game.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("RetuAdminUser")]
    public partial class RetuAdminUser:AdminUser
    {
           public RetuAdminUser(){


           }
           
        public string RoleName { get; set; }
        public string GameAgentDetailsIds { get; set; }

        public List<AdminPower> powers { get; set; }

        public string CurrentAgentCount { get; set; }
        public string CurrentMemberCount { get; set; }


    }
}
