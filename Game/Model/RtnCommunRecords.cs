using System;

namespace Game.Model
{
    public class RtnCommunRecords
    {
        public string ToolName { get; set; }
        public int id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Ststus { get; set; }
        public DateTime? UpdateTime { get; set; } 
        public string OperationName { get; set; }
    }
}
