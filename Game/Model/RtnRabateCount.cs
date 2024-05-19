using System;

namespace Game.Model
{
    public class RtnRabateCount
    {
        public string UserName { get; set; }
        public string Address { get; set; }
        public string ChildBate { get; set; }
        public string MyBate { get; set; }
        public string SumPrice { get; set; }
        public bool Status { get; set; } = false;
        public DateTime? StatusTime { get; set; }
        public string ChekBate { get; set; }
    }
}
