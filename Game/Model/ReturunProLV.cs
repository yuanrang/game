namespace Game.Model
{
    public class ReturunProLV
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; } 
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// 地址
        /// </summary>
        public string HashAddress { get; set; }
        /// <summary>
        /// 返佣金额
        /// </summary>
        public decimal RtnAmount { get; set; }
        /// <summary>
        /// 返佣比例
        /// </summary>
        public string RtnBfb { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 流水
        /// </summary>
        public string UsdtY { get; set; }   
        /// <summary>
        /// 盈利
        /// </summary>
        public string UsdtN { get; set; }
        ///// <summary>
        ///// /流水
        ///// </summary>
        //public decimal TRXY { get; set; }
        ///// <summary>
        ///// 盈利
        ///// </summary>
        //public decimal TRXN { get; set; }
    }
    public class ReturnProLVTypes
    {
        public int IsType { get; set; }
        public long PassportId { get; set; }
        public decimal Price { get; set; }
        public int CoinType { get; set;  }
    }
}
