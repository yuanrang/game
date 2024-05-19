using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class RetuAdminPage:AdminPage
    {
        public List<RetuAdminPage> Childrens { get; set; }
        /// <summary>
        /// Desc:页面图标
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string icon { get; set; }
        public string OpenId { get; set; }
        public int IsGoogle { get; set; }
        public int RoleId { get; set; }
        public int RoleType { get; set; }
    }

}
