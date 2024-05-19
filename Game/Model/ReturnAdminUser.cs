using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class ReturnAdminUser
    {
        public string UserName { get; set; }
        public decimal Price { get; set; }
    }
    public class ReturunUserIfon : ReturnAdminUser
    {
        public long PassportId { get; set; }
    }
}
