using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class RetuLoginUser
    {
        /// <summary>
        /// Desc:是否有效(0无效 1有效)
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public int IsValid { get; set; }
        /// <summary>
        /// Desc:PassportId
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string OpenId { get; set; }
        /// <summary>
        /// Desc:PassportId
        /// Default:
        /// Nullable:False
        /// </summary>           
        public long PassportId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string HashAddress { get; set; }
        /// <summary>
        /// Desc:角色ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int RoleId { get; set; }

        /// <summary>
        /// Desc:用户名
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string UserName { get; set; }
        /// <summary>
        /// Desc:游戏详情ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public List<int> GameDetailsIds { get; set; }

        /// <summary>
        /// Desc:代理详情ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public List<int> AgentDetailsIds { get; set; }

        public List<RetuAdminPage> pages { get; set; }
        /// <summary>
        /// 代理类型
        /// </summary>
        public int AgentTypeID { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        public int RoleType { get; set; }
        /// <summary>
        /// Desc:AdminPassportId
        /// Default:
        /// Nullable:False
        /// </summary>           
        public long AdminPassportId { get; set; }
    }
}
