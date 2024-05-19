namespace Game.Model
{
    public class RtnSumRabate
    {
        /// <summary>
        /// 佣金总金额
        /// </summary>
        public decimal SumU { get; set; } 
        public decimal SumT { get; set; } 
        /// <summary>
        /// 已提现总金额
        /// </summary>
        public decimal WithdrawalU { get; set; } 
        public decimal WithdrawalT { get; set; } 
        /// <summary>
        /// 代提现总金额
        /// </summary>
        public decimal WaitwithdrawalU { get; set; } 
        public decimal WaitwithdrawalT { get; set; } 
    }
}
