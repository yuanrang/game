using Game.Common;
using Game.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quartz;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Design
{
    public class GameQuartz : IJob
    {
        private static readonly GameEventWatr _cli;
        static GameQuartz()
        {
            _cli = new GameEventWatr();
        }
       
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("!");
            _cli.Start();
            return Task.CompletedTask;
        }

       
    }

    public class GameEventWatr
    {
        private  static readonly SqlSugar.ISqlSugarClient db;
    

        static GameEventWatr()
        {
            db =  new SqlSugar.SqlSugarClient(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.SqlServer,
                ConnectionString = "data source=.\\sqlexpress;initial catalog=GAME0703;user id=sa;password=sa123456!",
                IsAutoCloseConnection = true,
            });
        }
       public void Start()
        {
            var eventhk = db.Queryable<EventHK>().Where(x => x.UpdateTime > DateTime.Now && x.IsValid == 1).ToList();
            var even = DateTime.Now;
            if (eventhk.Count > 0)
                even = eventhk.Min(d => d.AddTime);
            var bet = db.Queryable<Bet>().Where(d => d.AddTime > even).ToList().GroupBy(d => d.PassportId).ToList();
            var eventrule = db.Queryable<EventRules>().Where(d => eventhk.Select(a => a.GUID).Contains(d.Guid) && d.IsValid == 1).ToList();
            var game = db.Queryable<GameType>().ToList();
            var _info = db.Queryable<UserInfo>().ToList();
            AgentImp agen = new Eve0();
            foreach (var item in eventhk)
            {
                foreach (var sd in bet)
                {
                    if (item.ManageUserPassportId == (sd.ToList().FirstOrDefault().ManageUserPassportId == 0 ? 502423741 : sd.ToList().FirstOrDefault().ManageUserPassportId))
                    {
                        if (item.PassportId != "")
                        {
                            long passportId = 0;

                            var user = _info.First(x => x.PassportId == sd.Key);
                            IsPassport(_info, user, ref passportId);
                            if (!item.PassportId.Contains(passportId.ToString()) || passportId == 0) continue;
                        }
                        var gameid = game.Where(d => item.GameTypeId.Contains(d.Id.ToString())).ToList();
                        var list = sd.ToList().Where(d => gameid.Select(d => d.Id).Contains(d.GameDetailsId) && d.CoinType == item.CoinType).OrderByDescending(d => d.AddTime).ToList();

                        (EventBet, EventDetails) nb = new();
                        if (list.Count == 0) continue;
                        agen.TZJL(list.Where(d => d.AddTime >= item.AddTime).ToList(), item, eventrule.Where(d => d.Guid == item.GUID).ToList(), db, ref nb);
                        if (nb.Item1 != null && nb.Item2 != null)
                        {
                            if (!string.IsNullOrEmpty(nb.Item2.OrderId))
                            {
                                var user = db.Queryable<UserInfo>().First(d => d.PassportId == nb.Item2.PassportId);
                                PaySys paySys = new PaySys();

                                paySys = db.Queryable<PaySys>().Where(d => d.PassportId == (user.ManageUserPassportId == 0 ? 502423741 : user.ManageUserPassportId) && d.product == item.CoinType.ToString()).First();


                                try
                                {
                                    DateTime t = DateTime.Now;
                                    RechargeCashOrder od = new RechargeCashOrder()
                                    {
                                        AddTime = t,
                                        UpdateTime = t,
                                        IsValid = 1,
                                        Sort = 1,
                                        Ip = ".",
                                        PassportId = user.PassportId,
                                        OrderID = nb.Item2.OrderId,
                                        FromHashAddress = "",
                                        ToHashAddress = user.HashAddress,
                                        CoinNumber = nb.Item2.BetAmount,
                                        IsPayment = 0,//是否支付(0未支付，1已支付)
                                        CoinType = 0,//币类别(0usdt 1其他)
                                        RCType = 2,//充值提现(0充值 1提现)
                                        ManageUserPassportId = (long)user.ManageUserPassportId,
                                        block_hash = "",
                                        block_number = ""//存储支付系统编号
                                    };

                                    db.Ado.BeginTran();
                                    db.Insertable(nb.Item1).ExecuteCommand();
                                    db.Insertable(nb.Item2).ExecuteCommand();
                                    db.Insertable(od).ExecuteCommand();
                                    db.Ado.CommitTran();
                                }
                                catch (Exception)
                                {
                                    db.Ado.RollbackTran();
                                    return;
                                }
                                try
                                {

                                    string result = PostWithdraws(nb.Item2.OrderId, nb.Item2.BetAmount, user.HashAddress, paySys.merchant_no, item.CoinType, paySys.apiKey); ;
                                    JObject jo = JObject.Parse(result); ;
                                    int code = jo["code"].Value<int>();
                                    if (code != 200) return;

                                }
                                catch (Exception ex)
                                {
                                    LogHelper.Debug($"PostWithdraw:{ex.Message}   parmas|OrderID:{nb.Item2.OrderId}|Amount:{nb.Item2.BetAmount}|ToHashAddress:{user.HashAddress}|merchant_no:{paySys?.merchant_no}");

                                    PostCashErrorOrder(nb.Item2.OrderId, nb.Item2.BetAmount, user.HashAddress, paySys?.merchant_no, item.CoinType.ToString(), "");

                                }

                            }
                            else
                            {
                                try
                                {
                                    db.Ado.BeginTran();
                                    db.Insertable(nb.Item1).ExecuteCommand();
                                    db.Insertable(nb.Item2).ExecuteCommand();
                                    db.Ado.CommitTran();
                                }
                                catch (Exception)
                                {
                                    db.Ado.RollbackTran();
                                    return;
                                }
                            }


                        }
                    }
                }
            }
        }
        private void IsPassport(List<UserInfo> list, UserInfo info, ref long passportId)
        {
            if (info == null) return;
            if (info.ParentId == 999999999)
            {
                passportId = info.PassportId;
            }
            else
            {
                var result = list.Where(d => d.PassportId == info.ParentId).FirstOrDefault();
                IsPassport(list, result, ref passportId);
            }
        }
        private string PostWithdraws(string OrderID, decimal Amount, string ToHashAddress, string _merchant_no, int product, string apikey)
        {
            var timestamp = convert_time_int_to10(DateTime.Now);
            var pro_duct = (product == 1 ? "USDT-TRC20Payout" : "TRXPayout");
            paramsCash paramss = new paramsCash() { product = pro_duct, amount = Amount.ToString(), merchant_ref = OrderID, extra = new extras() { address = ToHashAddress } };
            var json = JsonConvert.SerializeObject(paramss);
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            valuePairs.Add("merchant_no", _merchant_no);
            valuePairs.Add("timestamp", timestamp.ToString());
            valuePairs.Add("sign_type", "MD5");
            valuePairs.Add("params", json);
            var sg = _merchant_no + json + "MD5" + timestamp + apikey;
            valuePairs.Add("sign", YRHelper.get_md5_32(sg));


            string result = HttpHelper.Helper.PostMothss("https://api.paypptp.com/api/gateway/withdraw", valuePairs);
            return result;

        }
        private int convert_time_int_to10(DateTime time)
        {
            int intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (int)(time - startTime).TotalSeconds;
            return intResult;
        }
        private MsgInfo<string> PostCashErrorOrder(string OrderID, decimal Amount, string ToHashAddress, string _merchant_no, string product, string cash_json)
        {
            MsgInfo<string> info = new();
            DateTime t = DateTime.Now;

            CashErrorOrder cashError = db.Queryable<CashErrorOrder>().First(c => c.OrderID == OrderID);
            if (cashError == null)
            {
                CashErrorOrder od = new CashErrorOrder()
                {
                    AddTime = t,
                    UpdateTime = t,
                    IsValid = 1,
                    Sort = 1,
                    Ip = ".",

                    OrderID = OrderID,
                    Amount = Amount,
                    ToHashAddress = ToHashAddress,
                    merchant_no = _merchant_no,
                    cash_json = cash_json,
                    product = product ?? ""
                };
                int m = db.Insertable(od).ExecuteCommand();
                if (m < 1)
                {
                    info.code = 400;
                    info.msg = "Network Exception";
                    return info;
                }
            }

            info.code = 200;
            info.msg = "success";
            return info;
        }
    }
}
